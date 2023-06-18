using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// A shader int property that can be animated.
    /// </summary>
    [System.Serializable]
    public class AnimatedShaderPropertyInt : AnimatedShaderProperty
    {
        /// <summary>
        /// The value over time of the shader property.
        /// </summary>
        [Tooltip("The value over time of the shader property.")]
        public AnimationCurve valueOverTime;

        /// <summary>
        /// Creates a new animated shader int property.
        /// </summary>
        /// <param name="property">The shader property to animate.</param>
        /// <param name="valueOverTime">The value over time of the shader property.</param>
        public AnimatedShaderPropertyInt(ShaderProperty property, AnimationCurve valueOverTime) : base(property)
        {
            this.valueOverTime = valueOverTime;
        }

        /// <inheritdoc/>
        public override void Animate(Material material, float time)
        {
            material.SetInt(property, (int)valueOverTime.Evaluate(time));
        }

        /// <inheritdoc/>
        public override void Animate(MaterialPropertyBlock materialPropertyBlock, float time)
        {
            materialPropertyBlock.SetInt(property, (int)valueOverTime.Evaluate(time));
        }

    }

}
