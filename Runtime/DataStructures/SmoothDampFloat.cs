using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Gradually changes a float over time using a spring-damper function,
    /// which will never overshoot.
    /// </summary>
    [System.Serializable]
    public class SmoothDampFloat : SmoothDamp<float>
    {
        /// <summary>
        /// Smoothes the current value to the target value.
        /// </summary>
        /// <param name="target">The target value.</param>
        /// <returns>The new current value.</returns>
        public override float Update(float target)
        {
            value = Mathf.SmoothDamp(value, target, ref m_Velocity, smoothTime, maxSpeed);
            return value;
        }

        /// <summary>
        /// Smoothes the current value to the target value
        /// with the given delta time.
        /// </summary>
        /// <param name="target">The target value.</param>
        /// <param name="deltaTime">The time since the last call to this function.</param>
        /// <returns>The new current value.</returns>
        public override float Update(float target, float deltaTime)
        {
            value = Mathf.SmoothDamp(value, target, ref m_Velocity, smoothTime, maxSpeed, deltaTime);
            return value;
        }

    }

}
