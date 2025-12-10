using UnityEngine;
using UnityEngine.UI;

namespace Zigurous.Animation
{
    /// <summary>
    /// Animates a series of sprites over time on a UI image component.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Animated UI Image")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/AnimatedUIImage")]
    [RequireComponent(typeof(Image))]
    public sealed class AnimatedUIImage : MonoBehaviour
    {
        /// <summary>
        /// The UI image component for the animation (Read only).
        /// </summary>
        public Image image { get; private set; }

        /// <summary>
        /// The sprites that are rendered with the animation, in order.
        /// </summary>
        [Tooltip("The sprites that are rendered with the animation, in order.")]
        public Sprite[] sprites = new Sprite[0];

        /// <summary>
        /// The amount of frames per second that are rendered.
        /// </summary>
        [Tooltip("The amount of frames per second that are rendered.")]
        public float frameRate = 24f;

        /// <summary>
        /// The time at which the next frame will begin (Read only).
        /// </summary>
        public float nextFrameTime { get; private set; }

        /// <summary>
        /// The current frame index (Read only).
        /// </summary>
        public int frame { get; private set; }

        /// <summary>
        /// Whether the animation should loop back to the start after cycling
        /// through each sprite.
        /// </summary>
        [Tooltip("Whether the animation should loop back to the start after cycling through each sprite.")]
        public bool loop = true;

        /// <summary>
        /// Animates the sprites in reverse order.
        /// </summary>
        [Tooltip("Animates the sprites in reverse order.")]
        public bool reversed;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void Start()
        {
            Restart();
        }

        /// <summary>
        /// Restarts the animation to the first frame.
        /// </summary>
        public void Restart()
        {
            frame = 0;
            SetSprite();
        }

        private void Update()
        {
            if (Time.time >= nextFrameTime && frameRate != 0f) {
                NextFrame();
            }
        }

        private void NextFrame()
        {
            if (reversed) {
                frame--;
            } else {
                frame++;
            }

            if (frame < 0 || frame >= sprites.Length)
            {
                if (loop) {
                    frame = reversed ? sprites.Length - 1 : 0;
                } else {
                    frame = Mathf.Clamp(frame, 0, sprites.Length - 1);
                }
            }

            SetSprite();
            SetNextFrameTime();
        }

        private void SetSprite()
        {
            if (frame >= 0 && frame < sprites.Length) {
                image.sprite = sprites[frame];
            }
        }

        private void SetNextFrameTime()
        {
            if (frameRate != 0f)
            {
                float timing = 1f / frameRate;
                nextFrameTime = Time.time + timing;
            }
        }

    }

}
