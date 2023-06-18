using System.Collections.Generic;
using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Extension methods for <see cref="AnimatedShaderProperty"/>.
    /// </summary>
    public static class AnimatedShaderPropertyExtensions
    {
        /// <summary>
        /// Animates an array of shader properties.
        /// </summary>
        /// <param name="properties">The shader properties to animate.</param>
        /// <param name="material">The material to animate.</param>
        /// <param name="time">The time of the animation to evaluate.</param>
        public static void Animate(this AnimatedShaderProperty[] properties, Material material, float time)
        {
            for (int i = 0; i < properties.Length; i++) {
                properties[i].Animate(material, time);
            }
        }

        /// <summary>
        /// Animates an array of shader properties.
        /// </summary>
        /// <param name="properties">The shader properties to animate.</param>
        /// <param name="materialPropertyBlock">The material property block to animate.</param>
        /// <param name="time">The time of the animation to evaluate.</param>
        public static void Animate(this AnimatedShaderProperty[] properties, MaterialPropertyBlock materialPropertyBlock, float time)
        {
            for (int i = 0; i < properties.Length; i++) {
                properties[i].Animate(materialPropertyBlock, time);
            }
        }

        /// <summary>
        /// Animates an array of shader properties.
        /// </summary>
        /// <param name="properties">The shader properties to animate.</param>
        /// <param name="material">The material to animate.</param>
        /// <param name="time">The time of the animation to evaluate.</param>
        public static void Animate(this List<AnimatedShaderProperty> properties, Material material, float time)
        {
            foreach (AnimatedShaderProperty property in properties) {
                property.Animate(material, time);
            }
        }

        /// <summary>
        /// Animates an array of shader properties.
        /// </summary>
        /// <param name="properties">The shader properties to animate.</param>
        /// <param name="materialPropertyBlock">The material property block to animate.</param>
        /// <param name="time">The time of the animation to evaluate.</param>
        public static void Animate(this List<AnimatedShaderProperty> properties, MaterialPropertyBlock materialPropertyBlock, float time)
        {
            foreach (AnimatedShaderProperty property in properties) {
                property.Animate(materialPropertyBlock, time);
            }
        }

    }

}
