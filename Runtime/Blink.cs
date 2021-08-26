using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Switches a material on and off on an object at a variable rate.
    /// </summary>
    [RequireComponent(typeof(Renderer))]
    [AddComponentMenu("Zigurous/Animation/Blink")]
    public sealed class Blink : MonoBehaviour
    {
        /// <summary>
        /// A reference to the main blinking object's renderer.
        /// </summary>
        public new Renderer renderer { get; private set; }

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
        [Space(10f)]
        [Range(0f, 1f)]
        public float blinkChance = 1f;

        /// <summary>
        /// The amount of seconds the material stays blinking.
        /// </summary>
        [Tooltip("The amount of seconds the material stays blinking.")]
        public TimingRange blinkDuration = new TimingRange(1f, 1f);

        /// <summary>
        /// The amount of seconds before the material can blink a subsequent
        /// time.
        /// </summary>
        [Tooltip("The amount of seconds before the material can blink a subsequent time.")]
        public TimingRange blinkCooldown = new TimingRange(1f, 1f);

        /// <summary>
        /// How frequently in seconds the script will execute as a way to
        /// optimize the code performance.
        /// </summary>
        [Tooltip("How frequently in seconds the script will execute as a way to optimize the code performance.")]
        public float updateInterval = 1f;

        /// <summary>
        /// The time the next update will be performed.
        /// </summary>
        public float nextUpdateTime { get; private set; }

        /// <summary>
        /// Whether the object is currently blinking.
        /// </summary>
        public bool blinking { get; private set; }

        /// <summary>
        /// Whether the blinking is currently on cooldown.
        /// </summary>
        public bool cooldown { get; private set; }

        private void Awake()
        {
            this.renderer = GetComponent<Renderer>();
        }

        private void OnEnable()
        {
            this.blinking = false;
            this.cooldown = false;
        }

        private void Update()
        {
            if (Time.time >= this.nextUpdateTime)
            {
                if (Random.value < this.blinkChance) {
                    BlinkOnce();
                }

                this.nextUpdateTime = Time.time + this.updateInterval;
            }
        }

        /// <summary>
        /// Blinks the material for one cycle.
        /// </summary>
        public void BlinkOnce()
        {
            if (this.blinking || this.cooldown) {
                return;
            }

            this.blinking = true;

            AssignMaterial(this.blinkingMaterial);
            Invoke(nameof(FinishBlink), this.blinkDuration.Random());
        }

        private void FinishBlink()
        {
            this.blinking = false;

            AssignMaterial(this.notBlinkingMaterial);
            Cooldown();
        }

        private void AssignMaterial(Material material)
        {
            this.renderer.material = material;

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

            if (duration > 0f)
            {
                this.cooldown = true;
                Invoke(nameof(CooldownComplete), this.blinkCooldown.Random());
            }
        }

        private void CooldownComplete()
        {
            this.cooldown = false;
        }

    }

}
