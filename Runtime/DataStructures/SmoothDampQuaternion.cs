using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Gradually changes a Quaternion over time using a spring-damper function,
    /// which will never overshoot.
    /// </summary>
    [System.Serializable]
    public class SmoothDampQuaternion : SmoothDamp<Quaternion>
    {
        /// <summary>
        /// Smoothes the current value to the target value.
        /// </summary>
        /// <param name="target">The target value.</param>
        /// <returns>The new current value.</returns>
        public override Quaternion Update(Quaternion target)
        {
            Quaternion currentVelocity = velocity;
            value = Processors.SmoothDamp(value, target, ref currentVelocity, smoothTime, maxSpeed, Time.deltaTime);
            velocity = currentVelocity;
            return value;
        }

        /// <summary>
        /// Smoothes the current value to the target value
        /// with the given delta time.
        /// </summary>
        /// <param name="target">The target value.</param>
        /// <param name="deltaTime">The time since the last call to this function.</param>
        /// <returns>The new current value.</returns>
        public override Quaternion Update(Quaternion target, float deltaTime)
        {
            Quaternion currentVelocity = velocity;
            value = Processors.SmoothDamp(value, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
            velocity = currentVelocity;
            return value;
        }

    }

}
