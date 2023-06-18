using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Gradually changes a value over time using a spring-damper function,
    /// which will never overshoot.
    /// </summary>
    /// <typeparam name="T">The type of value to be animated.</typeparam>
    [System.Serializable]
    public abstract class SmoothDamp<T>
    {
        private T m_Value;
        private T m_Velocity;

        /// <summary>
        /// The current value (Read only).
        /// </summary>
        public T value
        {
            get { return m_Value; }
            protected set { m_Value = value; }
        }

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
        /// Smoothes the current value to the target value.
        /// </summary>
        /// <param name="target">The target value to animate towards.</param>
        /// <returns>The new current value.</returns>
        public abstract T Update(T target);

        /// <summary>
        /// Smoothes the current value to the target value with the given delta time.
        /// </summary>
        /// <param name="target">The target value to animate towards.</param>
        /// <param name="deltaTime">The time since the last call to this function.</param>
        /// <returns>The new current value.</returns>
        public abstract T Update(T target, float deltaTime);
    }

}
