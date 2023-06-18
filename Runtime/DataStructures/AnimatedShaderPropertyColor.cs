using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// A shader color property that can be animated.
    /// </summary>
    [System.Serializable]
    public class AnimatedShaderPropertyColor : AnimatedShaderProperty
    {
        /// <summary>
        /// The color over time of the shader property.
        /// </summary>
        [Tooltip("The color over time of the shader property.")]
        public Gradient colorOverTime;

        /// <summary>
        /// Creates a new animated shader color property.
        /// </summary>
        /// <param name="property">The shader property to animate.</param>
        /// <param name="colorOverTime">The color over time of the shader property.</param>
        public AnimatedShaderPropertyColor(ShaderProperty property, Gradient colorOverTime) : base(property)
        {
            this.colorOverTime = colorOverTime;
        }

        /// <inheritdoc/>
        public override void Animate(Material material, float time)
        {
            material.SetColor(property, colorOverTime.Evaluate(time));
        }

        /// <inheritdoc/>
        public override void Animate(MaterialPropertyBlock materialPropertyBlock, float time)
        {
            materialPropertyBlock.SetColor(property, colorOverTime.Evaluate(time));
        }

    }

}
