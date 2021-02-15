﻿using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Switches a material on and off on an object at a variable rate.
    /// </summary>
    [RequireComponent(typeof(Renderer))]
    public sealed class Blink : MonoBehaviour
    {
        /// <summary>
        /// A reference to the main blinking object's renderer.
        /// </summary>
        private Renderer _renderer;

        /// <summary>
        /// An array of other renderers whos material will be changed to match
        /// the blinking object.
        /// </summary>
        [Tooltip("An array of other renderers whos material will be changed to match the blinking object.")]
        public Renderer[] sharedRenderers;

        /// <summary>
        /// The material applied to the object when blinking.
        /// </summary>
        [Tooltip("The material applied to the object when blinking.")]
        public Material blinkingMaterial;

        /// <summary>
        /// The material applied to the object when not blinking.
        /// </summary>
        [Tooltip("The material applied to the object when not blinking.")]
        public Material notBlinkingMaterial;

        /// <summary>
        /// The random chance that the object will blink.
        /// </summary>
        [Tooltip("The random chance that the object will blink.")]
        [Space(10.0f)]
        [Range(0.0f, 1.0f)]
        public float blinkChance = 1.0f;

        /// <summary>
        /// The amount of seconds the material stays blinking.
        /// </summary>
        [Tooltip("The amount of seconds the material stays blinking.")]
        public TimingRange blinkDuration = new TimingRange(1.0f, 1.0f);

        /// <summary>
        /// The amount of seconds before the material can blink a subsequent
        /// time.
        /// </summary>
        [Tooltip("The amount of seconds before the material can blink a subsequent time.")]
        public TimingRange blinkCooldown = new TimingRange(1.0f, 1.0f);

        /// <summary>
        /// How frequently in seconds the script will execute as a way to
        /// optimize the code performance.
        /// </summary>
        [Tooltip("How frequently in seconds the script will execute as a way to optimize the code performance.")]
        public float updateInterval = 1.0f;

        /// <summary>
        /// The time the next update will be performed.
        /// </summary>
        private float _nextUpdateTime = 0.0f;

        /// <summary>
        /// Whether the object is currently blinking.
        /// </summary>
        private bool _blinking = false;

        /// <summary>
        /// Whether the blinking is currently on cooldown.
        /// </summary>
        private bool _cooldown = false;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void OnDestroy()
        {
            this.sharedRenderers = null;
            this.blinkingMaterial = null;
            this.notBlinkingMaterial = null;

            _renderer = null;
        }

        private void OnEnable()
        {
            _blinking = false;
            _cooldown = false;
        }

        private void Update()
        {
            if (Time.time >= _nextUpdateTime)
            {
                if (Random.value < this.blinkChance) {
                    BlinkOnce();
                }

                _nextUpdateTime = Time.time + this.updateInterval;
            }
        }

        public void BlinkOnce()
        {
            if (_blinking || _cooldown) {
                return;
            }

            _blinking = true;

            AssignMaterial(this.blinkingMaterial);
            Invoke(nameof(FinishBlinking), this.blinkDuration.Random());
        }

        private void FinishBlinking()
        {
            _blinking = false;

            AssignMaterial(this.notBlinkingMaterial);
            Cooldown();
        }

        private void AssignMaterial(Material material)
        {
            _renderer.material = material;

            if (this.sharedRenderers != null)
            {
                for (int i = 0; i < this.sharedRenderers.Length; i++) {
                    this.sharedRenderers[i].material = material;
                }
            }
        }

        private void Cooldown()
        {
            float duration = this.blinkCooldown.Random();

            if (duration > 0.0f)
            {
                _cooldown = true;
                Invoke(nameof(CooldownComplete), this.blinkCooldown.Random());
            }
        }

        private void CooldownComplete()
        {
            _cooldown = false;
        }

    }

}
