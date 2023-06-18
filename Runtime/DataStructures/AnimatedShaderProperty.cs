using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// A shader property that can be animated.
    /// </summary>
    [System.Serializable]
    public abstract class AnimatedShaderProperty
    {
        /// <summary>
        /// The shader property to animate.
        /// </summary>
        [Tooltip("The shader property to animate.")]
        public ShaderProperty property;

        /// <summary>
        /// Creates a new animated shader property.
        /// </summary>
        /// <param name="property">The shader property to animate.</param>
        public AnimatedShaderProperty(ShaderProperty property)
        {
            this.property = property;
        }

        /// <summary>
        /// Animates the shader property on the material.
        /// </summary>
        /// <param name="material">The material to animate.</param>
        /// <param name="time">The time of the animation to evaluate.</param>
        public abstract void Animate(Material material, float time);

        /// <summary>
        /// Animates the shader property on the material property block.
        /// </summary>
        /// <param name="materialPropertyBlock">The material property block to animate.</param>
        /// <param name="time">The time of the animation to evaluate.</param>
        public abstract void Animate(MaterialPropertyBlock materialPropertyBlock, float time);
    }

}
