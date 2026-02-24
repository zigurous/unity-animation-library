using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Fades out an object by animating its alpha shader property.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Fade Out")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/FadeOut")]
    public sealed class FadeOut : MonoBehaviour
    {
        private static readonly ShaderProperty _Color = "_Color";
        private static readonly ShaderProperty _BaseColor = "_BaseColor";

        [SerializeField]
        [Tooltip("The renderer to fade out.")]
        private Renderer m_Renderer;

        /// <summary>
        /// The shader property that controls the alpha value.
        /// </summary>
        [Tooltip("The shader property that controls the alpha value. ")]
        public ShaderProperty shaderProperty = "_Alpha";

        /// <summary>
        /// The amount of seconds it takes to fade out.
        /// </summary>
        [Tooltip("The amount of seconds it takes to fade out.")]
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

        private void OnEnable()
        {
            startTime = Time.time;
            properties ??= new MaterialPropertyBlock();

            if (shaderProperty == _Color) {
                SetColorAlpha(_Color, 1f);
            } else if (shaderProperty == _BaseColor) {
                SetColorAlpha(_BaseColor, 1f);
            } else {
                properties.SetFloat(shaderProperty, 1f);
            }

            m_Renderer.SetPropertyBlock(properties);
        }

        private void Update()
        {
            float elapsed = Time.time - startTime;

            if (fadeDelay <= float.Epsilon || elapsed >= fadeDelay)
            {
                elapsed -= fadeDelay;
                float alpha = ease.ValueAt(1f - Mathf.Clamp01(elapsed / fadeDuration));

                if (shaderProperty.Equals(_Color)) {
                    SetColorAlpha(_Color, alpha);
                } else if (shaderProperty.Equals(_BaseColor)) {
                    SetColorAlpha(_BaseColor, alpha);
                } else {
                    properties.SetFloat(shaderProperty, alpha);
                }

                m_Renderer.SetPropertyBlock(properties);
            }
        }

        private void SetColorAlpha(ShaderProperty property, float alpha)
        {
            Color color = properties.GetColor(property);
            color.a = alpha;
            properties.SetColor(property, color);
        }

    }

}
