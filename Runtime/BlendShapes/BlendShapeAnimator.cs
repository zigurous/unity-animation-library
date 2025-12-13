using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Animates a skinned mesh renderer via its blend shapes.
    /// </summary>
    [DefaultExecutionOrder(1)]
    [AddComponentMenu("Zigurous/Animation/Blend Shape Animator")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/BlendShapeAnimator")]
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public sealed class BlendShapeAnimator : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The animation clips that can be played.")]
        private BlendShapeAnimationClip[] clips = null;

        /// <summary>
        /// The default animation to play every time an animation is finished.
        /// This is useful to automatically transition to idle animations.
        /// </summary>
        [Tooltip("The default animation to play every time an animation is finished. This is useful to automatically transition to idle animations.")]
        public AnimationId defaultAnimationId = null;

        /// <summary>
        /// Applies smoothing interpolation between blend shapes.
        /// </summary>
        [Tooltip("Applies smoothing interpolation between blend shapes.")]
        public bool smoothing = true;

        /// <summary>
        /// The skinned mesh renderer being animated.
        /// </summary.
        public SkinnedMeshRenderer skinnedMeshRenderer { get; private set; }

        /// <summary>
        /// The current animation being played.
        /// </summary>
        public AnimationId currentAnimationId => currentAnimation?.id;

        /// <summary>
        /// Whether the animator can be interrupted to transition to another animation.
        /// </summary>
        public bool transitionable => currentAnimation == null || currentAnimation.finished || currentAnimation.looping;

        private BlendShapeKeyframe[] blendShapes;
        private BlendShapeAnimation[] animations;
        private BlendShapeAnimation currentAnimation;

        private void Awake()
        {
            if (skinnedMeshRenderer == null) {
                skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
            }
        }

        private void InitializeBlendShapes()
        {
            if (skinnedMeshRenderer == null) {
                skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
            }

            if (skinnedMeshRenderer.sharedMesh != null)
            {
                blendShapes = new BlendShapeKeyframe[skinnedMeshRenderer.sharedMesh.blendShapeCount + 1];

                for (int i = 0; i < blendShapes.Length; i++) {
                    blendShapes[i] = new BlendShapeKeyframe(i-1);
                }
            }
        }

        /// <summary>
        /// Assigns the animation clips to the animator.
        /// </summary>
        /// <param name="clips">The animation clips to assign.</param>
        public void SetAnimations(BlendShapeAnimationClip[] clips)
        {
            if (clips == null) return;

            this.clips = clips;
            animations = new BlendShapeAnimation[clips.Length];

            if (blendShapes == null || blendShapes.Length == 0) {
                InitializeBlendShapes();
            }

            int blendShapeIndex = 0;

            for (int i = 0; i < animations.Length; i++)
            {
                BlendShapeAnimationClip clip = clips[i];
                BlendShapeAnimation animation = new(clip, blendShapes, blendShapeIndex);
                animations[i] = animation;
                blendShapeIndex += animation.frames;
            }
        }

        private void Start()
        {
            if (animations == null || animations.Length == 0)
            {
                if (clips != null) {
                    SetAnimations(clips);
                } else {
                    animations = new BlendShapeAnimation[0];
                }
            }
        }

        private void OnEnable()
        {
            if (defaultAnimationId != null) {
                PlayAnimation(defaultAnimationId);
            }
        }

        private void OnDisable()
        {
            StopAnimation();
            ClearAllBlendShapes();
        }

        private void Update()
        {
            if (currentAnimation == null || currentAnimation.finished)
            {
                currentAnimation?.Stop();
                currentAnimation = null;

                if (TryGetAnimation(defaultAnimationId, out currentAnimation)) {
                    currentAnimation.Play();
                }
            }

            float deltaTime = Time.deltaTime;

            for (int i = 0; i < animations.Length; i++) {
                animations[i].Update(skinnedMeshRenderer, deltaTime, smoothing);
            }
        }

        /// <summary>
        /// Plays the animation with the given id.
        /// </summary>
        /// <param name="id">The id of the animation to play.</param>
        /// <returns>The animation that is played, or null if the animation could not be played.</returns>
        public BlendShapeAnimation PlayAnimation(AnimationId id)
        {
            if (animations == null || animations.Length == 0) {
                return null;
            }

            if (id == null)
            {
                StopAnimation();
                return null;
            }

            if (TryGetAnimation(id, out BlendShapeAnimation animation))
            {
                if (animation == currentAnimation && !animation.finished) {
                    return animation;
                }

                StopAnimation();
                currentAnimation = animation;
                currentAnimation.Play();
                return animation;
            }

            return null;
        }

        /// <summary>
        /// Plays the animation with the given id only if the animator is
        /// currently transitionable.
        /// </summary>
        /// <param name="id">The id of the animation to play.</param>
        /// <returns>The animation that is played, or null if the animation could not be played.</returns>
        public BlendShapeAnimation PlayAnimationIfTransitionable(AnimationId id)
        {
            if (transitionable) {
                return PlayAnimation(id);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Stops the current animation playing.
        /// </summary>
        public void StopAnimation()
        {
            currentAnimation?.Stop();
            currentAnimation = null;
        }

        /// <summary>
        /// Sets the default animation to be played using the given id. The
        /// default animation is automatically played every time an animation is
        /// finished. This is useful for transitioning to idle animations.
        /// </summary>
        /// <param name="id">The id of the animation to set as the default.</param>
        public void SetDefaultAnimation(AnimationId id)
        {
            if (defaultAnimationId != id)
            {
                defaultAnimationId = id;

                if (currentAnimation == null || currentAnimation.looping || currentAnimation.finished) {
                    PlayAnimation(defaultAnimationId);
                }
            }
        }

        private BlendShapeAnimation GetAnimation(AnimationId id)
        {
            if (animations == null || id == null) return null;

            for (int i = 0; i < animations.Length; i++)
            {
                if (animations[i].id == id) {
                    return animations[i];
                }
            }

            return null;
        }

        private bool TryGetAnimation(AnimationId id, out BlendShapeAnimation animation)
        {
            animation = GetAnimation(id);
            return animation != null;
        }

        private void ClearAllBlendShapes()
        {
            if (blendShapes != null)
            {
                for (int i = 1; i < blendShapes.Length; i++)
                {
                    BlendShapeKeyframe keyframe = blendShapes[i];
                    skinnedMeshRenderer.SetBlendShapeWeight(keyframe.index, 0f);
                }
            }
        }

    }

}
