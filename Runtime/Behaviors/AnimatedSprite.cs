using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Animates a series of sprites over time.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Animated Sprite")]
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class AnimatedSprite : MonoBehaviour
    {
        /// <summary>
        /// The sprite renderer component for the animation (Read only).
        /// </summary>
        public SpriteRenderer spriteRenderer { get; private set; }

        /// <summary>
        /// The sprites that are rendered throughout the animation, in order.
        /// </summary>
        [Tooltip("The sprites that are rendered throughout the animation, in order.")]
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
        /// Animates the sprites in reverse order.
        /// </summary>
        [Tooltip("Animates the sprites in reverse order.")]
        public bool reversed;

        /// <summary>
        /// Whether the animation should loop back to the start after cycling
        /// through each sprite.
        /// </summary>
        [Tooltip("Whether the animation should loop back to the start after cycling through each sprite.")]
        public bool loop = true;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
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
                spriteRenderer.sprite = sprites[frame];
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
