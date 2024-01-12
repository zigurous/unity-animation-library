using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Switches an object's material on and off at a variable rate.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Blink")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/Blink")]
    [RequireComponent(typeof(Renderer))]
    public sealed class Blink : MonoBehaviour
    {
        /// <summary>
        /// A reference to the main blinking object's renderer (Read only).
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
        public TimingRange blinkDuration = new(1f, 1f);

        /// <summary>
        /// The amount of seconds before the material can blink a subsequent
        /// time.
        /// </summary>
        [Tooltip("The amount of seconds before the material can blink a subsequent time.")]
        public TimingRange blinkCooldown = new(1f, 1f);

        /// <summary>
        /// How frequently in seconds the script will execute as a way to
        /// optimize the code performance.
        /// </summary>
        [Tooltip("How frequently in seconds the script will execute as a way to optimize the code performance.")]
        public float updateInterval = 1f;

        /// <summary>
        /// The time the next update will be performed (Read only).
        /// </summary>
        public float nextUpdateTime { get; private set; }

        /// <summary>
        /// Whether the object is currently blinking (Read only).
        /// </summary>
        public bool blinking { get; private set; }

        /// <summary>
        /// Whether the blinking is currently on cooldown (Read only).
        /// </summary>
        public bool cooldown { get; private set; }

        private void Awake()
        {
            renderer = GetComponent<Renderer>();
        }

        private void OnEnable()
        {
            blinking = false;
            cooldown = false;
        }

        private void Update()
        {
            if (Time.time >= nextUpdateTime)
            {
                if (Random.value < blinkChance) {
                    BlinkOnce();
                }

                nextUpdateTime = Time.time + updateInterval;
            }
        }

        /// <summary>
        /// Blinks the material for one cycle.
        /// </summary>
        public void BlinkOnce()
        {
            if (blinking || cooldown) {
                return;
            }

            blinking = true;

            AssignMaterial(blinkingMaterial);
            Invoke(nameof(FinishBlink), blinkDuration.Random());
        }

        private void FinishBlink()
        {
            blinking = false;

            AssignMaterial(notBlinkingMaterial);
            Cooldown();
        }

        private void AssignMaterial(Material material)
        {
            renderer.material = material;

            if (sharedRenderers != null)
            {
                for (int i = 0; i < sharedRenderers.Length; i++) {
                    sharedRenderers[i].material = material;
                }
            }
        }

        private void Cooldown()
        {
            float duration = blinkCooldown.Random();

            if (duration > 0f)
            {
                cooldown = true;
                Invoke(nameof(CooldownComplete), blinkCooldown.Random());
            }
        }

        private void CooldownComplete()
        {
            cooldown = false;
        }

    }

}
