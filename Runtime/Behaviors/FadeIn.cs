using UnityEngine;

namespace Zigurous.Animation
{
    [AddComponentMenu("Zigurous/Animation/Fade In")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/FadeIn")]
    public sealed class FadeIn : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The renderer to fade in.")]
        private Renderer m_Renderer;

        /// <summary>
        /// The shader property that controls the alpha value.
        /// </summary>
        [Tooltip("The shader property that controls the alpha value. ")]
        public ShaderProperty shaderProperty = "_Alpha";

        /// <summary>
        /// The amount of seconds it takes to fade in.
        /// </summary>
        [Tooltip("The amount of seconds it takes to fade in.")]
        public float fadeDuration = 0.6f;

        /// <summary>
        /// The amount of seconds before the fade starts.
        /// </summary>
        [Tooltip("The amount of seconds before the fade starts.")]
        public float fadeDelay = 0f;

        /// <summary>
        /// The easing function to use when fading.
        /// </summary>
        [Tooltip("The easing function to use when fading.")]
        public Ease ease = Ease.QuadOut;

        private MaterialPropertyBlock properties;
        private float startTime;

        private void Reset()
        {
            m_Renderer = GetComponentInChildren<Renderer>();
        }

        private void Start()
        {
            properties = new MaterialPropertyBlock();
        }

        private void OnEnable()
        {
            startTime = Time.time;
        }

        private void Update()
        {
            float elapsed = Time.time - startTime;

            if (fadeDelay <= float.Epsilon || elapsed >= fadeDelay)
            {
                elapsed -= fadeDelay;
                float alpha = ease.ValueAt(Mathf.Clamp01(elapsed / fadeDuration));
                properties.SetFloat(shaderProperty, alpha);
                m_Renderer.SetPropertyBlock(properties);
            }
        }

    }

}
