using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Gradually changes a shader property over time on a material using a
    /// spring-damper function, which will never overshoot.
    /// </summary>
    /// <typeparam name="T">The type of value to be animated.</typeparam>
    [System.Serializable]
    public abstract class SmoothDampShaderProperty<T>
    {
        private T m_Velocity;

        /// <summary>
        /// The current velocity, this value is modified by the function every
        /// time you call it (Read only).
        /// </summary>
        public T velocity
        {
            get { return m_Velocity; }
            protected set { m_Velocity = value; }
        }

        /// <summary>
        /// The shader property to animate.
        /// </summary>
        [Tooltip("The shader property to animate.")]
        public ShaderProperty property;

        /// <summary>
        /// Approximately the time it will take to reach the target. A smaller
        /// value will reach the target faster.
        /// </summary>
        [Tooltip("Approximately the time it will take to reach the target. A smaller value will reach the target faster.")]
        public float smoothTime = 0.2f;

        /// <summary>
        /// Optionally allows the maximum speed to be clamped.
        /// </summary>
        [Tooltip("Optionally allows the maximum speed to be clamped.")]
        public float maxSpeed = Mathf.Infinity;

        /// <summary>
        /// Creates a new smooth-damped shader property.
        /// </summary>
        /// <param name="property">The shader property to animate.</param>
        public SmoothDampShaderProperty() {}

        /// <summary>
        /// Creates a new smooth-damped shader property.
        /// </summary>
        /// <param name="property">The shader property to animate.</param>
        public SmoothDampShaderProperty(ShaderProperty property)
        {
            this.property = property;
        }

        /// <summary>
        /// Creates a new smooth-damped shader property.
        /// </summary>
        /// <param name="property">The shader property to animate.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        /// <param name="maxSpeed">Optionally allows the maximum speed to be clamped.</param>
        public SmoothDampShaderProperty(ShaderProperty property, float smoothTime, float maxSpeed)
        {
            this.property = property;
            this.smoothTime = smoothTime;
            this.maxSpeed = maxSpeed;
        }

        /// <summary>
        /// Smoothes the current value to the target value.
        /// </summary>
        /// <param name="material">The material to animate.</param>
        /// <param name="target">The target value to animate towards.</param>
        /// <returns>The new property value.</returns>
        public abstract T Update(Material material, T target);

        /// <summary>
        /// Smoothes the current value to the target value with the given delta time.
        /// </summary>
        /// <param name="material">The material to animate.</param>
        /// <param name="target">The target value to animate towards.</param>
        /// <param name="deltaTime">The time since the last call to this function.</param>
        /// <returns>The new property value.</returns>
        public abstract T Update(Material material, T target, float deltaTime);
    }

}
