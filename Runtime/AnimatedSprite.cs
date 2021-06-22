﻿using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Animates a series of sprites over time.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class AnimatedSprite : MonoBehaviour
    {
        /// <summary>
        /// The sprite renderer component for the animation.
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
        public float frameRate = 24.0f;

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

        /// <summary>
        /// The time at which the next frame will begin.
        /// </summary>
        public float nextFrameTime { get; private set; }

        /// <summary>
        /// The current frame index.
        /// </summary>
        public int frame { get; private set; }

        private void Awake()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            Restart();
        }

        public void Restart()
        {
            this.frame = 0;
            SetSprite();
        }

        private void Update()
        {
            if (Time.time >= this.nextFrameTime && this.frameRate != 0.0f) {
                NextFrame();
            }
        }

        private void NextFrame()
        {
            if (this.reversed) {
                this.frame--;
            } else {
                this.frame++;
            }

            if (this.frame < 0 || this.frame >= this.sprites.Length)
            {
                if (this.loop) {
                    this.frame = this.reversed ? this.sprites.Length - 1 : 0;
                } else {
                    this.frame = Mathf.Clamp(this.frame, 0, this.sprites.Length - 1);
                }
            }

            SetSprite();
            SetNextFrameTime();
        }

        private void SetSprite()
        {
            if (this.frame >= 0 && this.frame < this.sprites.Length) {
                this.spriteRenderer.sprite = this.sprites[this.frame];
            }
        }

        private void SetNextFrameTime()
        {
            if (this.frameRate != 0.0f)
            {
                float timing = 1.0f / this.frameRate;
                this.nextFrameTime = Time.time + timing;
            }
        }

    }

}
