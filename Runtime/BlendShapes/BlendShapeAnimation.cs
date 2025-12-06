using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Animation data for a blend shape animation.
    /// </summary>
    public sealed class BlendShapeAnimation
    {
        /// <summary>
        /// The global frame rate for all blend shape animations (default=50).
        /// </summary>
        public static int FrameRate = 50;

        /// <summary>
        /// The length of a single subframe for all blend shape animations (default=1/50).
        /// </summary>
        public static float FrameDuration => 1f / FrameRate;

        /// <summary>
        /// The identifier of the animation.
        /// </summary>
        public readonly AnimationId id;

        /// <summary>
        /// The keyframe data for the animation.
        /// </summary>
        public readonly BlendShapeKeyframe[] keyframes;

        /// <summary>
        /// The amount of subframes for each keyframe. For example, a length of
        /// 5 means the keyframe would last 100ms at 50fps (1000ms/50*5). This
        /// allows for custom keyframe timing to create different animation
        /// curves / easing.
        /// </summary>
        public readonly short[] frameLengths;

        /// <summary>
        /// The number of frames of the animation.
        /// </summary>
        public int frames => keyframes.Length;

        /// <summary>
        /// The entire duration of the animation in seconds.
        /// </summary>
        public readonly float duration;

        /// <summary>
        /// Loops the animation continuously.
        /// </summary>
        public readonly bool loop;

        /// <summary>
        /// The current frame of the animation.
        /// </summary>
        public int frame { get; private set; }

        /// <summary>
        /// Whether the animation is currently playing.
        /// </summary>
        public bool playing { get; private set; }

        /// <summary>
        /// Whether the animation is finished playing.
        /// </summary>
        public bool finished { get; private set; }

        /// <summary>
        /// Whether the animation is currently playing and looping.
        /// </summary>
        public bool looping => playing && loop && keyframes.Length > 1;

        /// <summary>
        /// The amount of seconds elapsed since the start of the current keyframe.
        /// </summary>
        private float elapsed;

        /// <summary>
        /// Create a new blend shape animation.
        /// </summary>
        /// <param name="id">The identifier of the animation.</param>
        /// <param name="loop">Whether the animation loops continuously.</param>
        /// <param name="blendShapes">All of the blend shapes of the renderer being animated.</param>
        /// <param name="blendShapeIndex">The starting blend shape index for the first frame of the animation.</param>
        public BlendShapeAnimation(AnimationId id, bool loop, short[] frameLengths, BlendShapeKeyframe[] blendShapes, int blendShapeIndex)
        {
            this.id = id;
            this.loop = loop;
            this.frameLengths = frameLengths;

            int frames = frameLengths.Length;
            int frameLengthsIndex = 0;
            keyframes = new BlendShapeKeyframe[frames];

            for (int i = 0; i < keyframes.Length; i++)
            {
                BlendShapeKeyframe keyframe = blendShapes[blendShapeIndex + i];
                keyframe.length = frameLengths[frameLengthsIndex + i];
                keyframe.frame = i + 1;
                keyframes[i] = keyframe;
                duration += keyframe.length * FrameDuration;
            }
        }

        /// <summary>
        /// Create a new blend shape animation from the animation clip data.
        /// </summary>
        /// <param name="clip">The animation clip data.</param>
        /// <param name="blendShapes">All of the blend shapes of the renderer being animated.</param>
        /// <param name="blendShapeIndex">The starting blend shape index for the first frame of the animation.</param>
        public BlendShapeAnimation(BlendShapeAnimationClip clip, BlendShapeKeyframe[] blendShapes, int blendShapeIndex) :
            this(clip.id, clip.loop, clip.frameLengths, blendShapes, blendShapeIndex) {}

        /// <summary>
        /// Plays the animation.
        /// </summary>
        public void Play()
        {
            frame = 0;
            elapsed = 0f;
            playing = true;
            finished = false;
        }

        /// <summary>
        /// Stops the animation.
        /// </summary>
        public void Stop()
        {
            playing = false;
            finished = true;

            if (keyframes != null)
            {
                for (int i = 0; i < keyframes.Length; i++) {
                    keyframes[i].targetWeight = 0f;
                }
            }
        }

        /// <summary>
        /// Updates the animation state on the renderer.
        /// </summary>
        /// <param name="renderer">The renderer to set the blend shapes on.</param>
        /// <param name="deltaTime">The amount of seconds elapsed since the last frame.</param>
        /// <param name="smoothing">Whether to apply smoothing interpolation between blend shapes.</param>
        public void Update(SkinnedMeshRenderer renderer, float deltaTime, bool smoothing)
        {
            if (playing && frame < keyframes.Length)
            {
                BlendShapeKeyframe currentKeyframe = keyframes[frame];
                elapsed += deltaTime;

                if (smoothing)
                {
                    float t = Mathf.InverseLerp(0f, currentKeyframe.duration, elapsed);
                    currentKeyframe.targetWeight = (1f - t) * 100f;

                    if (frame < keyframes.Length - 1) {
                        keyframes[frame + 1].targetWeight = 100f - currentKeyframe.targetWeight;
                    } else if (loop) {
                        keyframes[0].targetWeight = 100f - currentKeyframe.targetWeight;
                    }
                }

                if (elapsed >= currentKeyframe.duration) {
                    NextKeyframe();
                }
            }

            for (int i = 0; i < keyframes.Length; i++)
            {
                BlendShapeKeyframe keyframe = keyframes[i];

                if (!smoothing) {
                    keyframe.targetWeight = playing && i == frame ? 100f : 0f;
                }

                if (keyframe.weight != keyframe.targetWeight)
                {
                    keyframe.weight = keyframe.targetWeight;

                    if (keyframe.index >= 0) {
                        renderer.SetBlendShapeWeight(keyframe.index, keyframe.weight);
                    }
                }
            }
        }

        private void NextKeyframe()
        {
            elapsed = 0f;
            frame++;

            if (frame >= keyframes.Length)
            {
                if (loop) {
                    frame = 0;
                } else {
                    Stop();
                }
            }
        }

        /// <summary>
        /// Sets the blend shape weights to 0 for every keyframe of the animation.
        /// </summary>
        /// <param name="renderer">The renderer to set the blend shape weights on.</param>
        public void ClearBlendWeights(SkinnedMeshRenderer renderer)
        {
            for (int i = 0; i < keyframes.Length; i++)
            {
                BlendShapeKeyframe keyframe = keyframes[i];

                if (keyframe.weight != 0f)
                {
                    keyframe.weight = 0f;
                    keyframe.targetWeight = 0f;

                    if (keyframe.index >= 0) {
                        renderer.SetBlendShapeWeight(keyframe.index, 0f);
                    }
                }
            }
        }

    }

    /// <summary>
    /// Serialized blend shape animation data.
    /// </summary>
    [System.Serializable]
    public sealed class BlendShapeAnimationClip
    {
        /// <summary>
        /// The identifier of the animation.
        /// </summary>
        public AnimationId id;

        /// <summary>
        /// Loops the animation continuously.
        /// </summary>
        public bool loop;

        /// <summary>
        /// The amount of subframes for each keyframe. For example, a length of
        /// 5 means the keyframe would last 100ms at 50fps (1000ms/50*5). This
        /// allows for custom keyframe timing to create different animation
        /// curves / easing.
        /// </summary>
        public short[] frameLengths;
    }

}
