using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Gradually changes a shader property color value over time on a material
    /// using a spring-damper function, which will never overshoot.
    /// </summary>
    [System.Serializable]
    public class SmoothDampShaderPropertyColor : SmoothDampShaderProperty<Color>
    {
        /// <inheritdoc/>
        public SmoothDampShaderPropertyColor() : base() {}

        /// <inheritdoc/>
        public SmoothDampShaderPropertyColor(ShaderProperty property) : base(property) {}

        /// <inheritdoc/>
        public SmoothDampShaderPropertyColor(ShaderProperty property, float smoothTime, float maxSpeed) : base(property, smoothTime, maxSpeed) {}

        /// <summary>
        /// Smoothes the current value to the target value.
        /// </summary>
        /// <param name="material">The material to animate.</param>
        /// <param name="target">The target value to animate towards.</param>
        /// <returns>The new property value.</returns>
        public override Color Update(Material material, Color target)
        {
            Color value = material.GetColor(property);
            Color currentVelocity = velocity;

            value.r = Mathf.SmoothDamp(value.r, target.r, ref currentVelocity.r, smoothTime, maxSpeed);
            value.g = Mathf.SmoothDamp(value.g, target.g, ref currentVelocity.g, smoothTime, maxSpeed);
            value.b = Mathf.SmoothDamp(value.b, target.b, ref currentVelocity.b, smoothTime, maxSpeed);
            value.a = Mathf.SmoothDamp(value.a, target.a, ref currentVelocity.a, smoothTime, maxSpeed);

            velocity = currentVelocity;
            material.SetColor(property, value);

            return value;
        }

        /// <summary>
        /// Smoothes the current value to the target value with the given delta time.
        /// </summary>
        /// <param name="material">The material to animate.</param>
        /// <param name="target">The target value to animate towards.</param>
        /// <param name="deltaTime">The time since the last call to this function.</param>
        /// <returns>The new property value.</returns>
        public override Color Update(Material material, Color target, float deltaTime)
        {
            Color value = material.GetColor(property);
            Color currentVelocity = velocity;

            value.r = Mathf.SmoothDamp(value.r, target.r, ref currentVelocity.r, smoothTime, maxSpeed, deltaTime);
            value.g = Mathf.SmoothDamp(value.g, target.g, ref currentVelocity.g, smoothTime, maxSpeed, deltaTime);
            value.b = Mathf.SmoothDamp(value.b, target.b, ref currentVelocity.b, smoothTime, maxSpeed, deltaTime);
            value.a = Mathf.SmoothDamp(value.a, target.a, ref currentVelocity.a, smoothTime, maxSpeed, deltaTime);

            velocity = currentVelocity;
            material.SetColor(property, value);

            return value;
        }

    }

}
