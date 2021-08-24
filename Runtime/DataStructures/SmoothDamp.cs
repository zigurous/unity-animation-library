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
        protected T _value;
        protected T _velocity;

        /// <summary>
        /// The current value.
        /// </summary>
        public T value
        {
            get { return _value; }
            protected set { _value = value; }
        }

        /// <summary>
        /// The current velocity, this value is modified by the function every
        /// time you call it.
        /// </summary>
        public T velocity
        {
            get { return _velocity; }
            protected set { _velocity = value; }
        }

        /// <summary>
        /// Approximately the time it will take to reach the target. A smaller
        /// value will reach the target faster.
        /// </summary>
        [Tooltip("Approximately the time it will take to reach the target. A smaller value will reach the target faster.")]
        public float smoothTime = 0.1f;

        /// <summary>
        /// Optionally allows you to clamp the maximum speed.
        /// </summary>
        [Tooltip("Optionally allows you to clamp the maximum speed.")]
        public float maxSpeed = Mathf.Infinity;

        /// <summary>
        /// Smoothes the current value to the <paramref name="target"/> value.
        /// </summary>
        /// <param name="target">The target value.</param>
        /// <returns>The new current value.</returns>
        public abstract T Update(T target);

        /// <summary>
        /// Smoothes the current value to the <paramref name="target"/> value
        /// with the given <paramref name="deltaTime"/>.
        /// </summary>
        /// <param name="target">The target value.</param>
        /// <param name="deltaTime">The time since the last call to this function.</param>
        /// <returns>The new current value.</returns>
        public abstract T Update(T target, float deltaTime);

    }

}
