using UnityEngine;

namespace Zigurous.Animation
{
    [RequireComponent(typeof(Renderer))]
    public sealed class MaterialFlash : MonoBehaviour
    {
        public Renderer[] sharedRenderers;
        private Renderer _renderer;

        public Material flashOn;
        public Material flashOff;

        [Range(0.0f, 1.0f)]
        public float flashChance = 1.0f;
        public TimingRange flashDuration = new TimingRange(1.0f, 1.0f);
        public TimingRange flashCooldown = new TimingRange(1.0f, 1.0f); 

        public float updateInterval = 1.0f;
        private float _nextUpdateTime = 0.0f;

        private bool _flashing = false;
        private bool _cooldown = false;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void OnDestroy()
        {
            this.sharedRenderers = null;
            this.flashOn = null;
            this.flashOff = null;

            _renderer = null;
        }

        private void OnEnable()
        {
            _flashing = false;
        }

        private void Update()
        {
            if (Time.time >= _nextUpdateTime)
            {
                if (Random.value < this.flashChance) {
                    Flash();
                }

                _nextUpdateTime = Time.time + this.updateInterval;
            }
        }

        public void Flash()
        {
            if (_flashing || _cooldown) {
                return;
            }

            _flashing = true;
            _renderer.material = this.flashOn;

            if (this.sharedRenderers != null)
            {
                for (int i = 0; i < this.sharedRenderers.Length; i++) {
                    this.sharedRenderers[i].material = _renderer.material;
                }
            }

            Invoke(nameof(FlashComplete), this.flashDuration.Random());
        }

        private void FlashComplete()
        {
            _flashing = false;
            _renderer.material = this.flashOff;

            if (this.sharedRenderers != null)
            {
                for (int i = 0; i < this.sharedRenderers.Length; i++) {
                    this.sharedRenderers[i].material = _renderer.material;
                }
            }

            Cooldown();
        }

        private void Cooldown()
        {
            float duration = this.flashCooldown.Random();

            if (duration > 0.0f)
            {
                _cooldown = true;
                Invoke(nameof(CooldownComplete), this.flashCooldown.Random());
            }
        }

        private void CooldownComplete() => _cooldown = false;

    }

}
