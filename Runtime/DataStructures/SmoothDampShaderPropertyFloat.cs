using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Gradually changes a shader property float value over time on a material
    /// using a spring-damper function, which will never overshoot.
    /// </summary>
    [System.Serializable]
    public class SmoothDampShaderPropertyFloat : SmoothDampShaderProperty<float>
    {
        /// <inheritdoc/>
        public SmoothDampShaderPropertyFloat() : base() {}

        /// <inheritdoc/>
        public SmoothDampShaderPropertyFloat(ShaderProperty property) : base(property) {}

        /// <inheritdoc/>
        public SmoothDampShaderPropertyFloat(ShaderProperty property, float smoothTime, float maxSpeed) : base(property, smoothTime, maxSpeed) {}

        /// <summary>
        /// Smoothes the current value to the target value.
        /// </summary>
        /// <param name="material">The material to animate.</param>
        /// <param name="target">The target value to animate towards.</param>
        /// <returns>The new property value.</returns>
        public override float Update(Material material, float target)
        {
            float value = material.GetFloat(property);
            float currentVelocity = velocity;
            value = Mathf.SmoothDamp(value, target, ref currentVelocity, smoothTime, maxSpeed);
            velocity = currentVelocity;
            material.SetFloat(property, value);
            return value;
        }

        /// <summary>
        /// Smoothes the current value to the target value with the given delta time.
        /// </summary>
        /// <param name="material">The material to animate.</param>
        /// <param name="target">The target value to animate towards.</param>
        /// <param name="deltaTime">The time since the last call to this function.</param>
        /// <returns>The new property value.</returns>
        public override float Update(Material material, float target, float deltaTime)
        {
            float value = material.GetFloat(property);
            float currentVelocity = velocity;
            value = Mathf.SmoothDamp(value, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
            velocity = currentVelocity;
            material.SetFloat(property, value);
            return value;
        }

    }

}
