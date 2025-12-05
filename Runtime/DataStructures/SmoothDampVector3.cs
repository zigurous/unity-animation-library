using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Gradually changes a Vector3 over time using a spring-damper function,
    /// which will never overshoot.
    /// </summary>
    [System.Serializable]
    public class SmoothDampVector3 : SmoothDamp<Vector3>
    {
        /// <summary>
        /// Smoothes the current value to the target value.
        /// </summary>
        /// <param name="target">The target value to animate towards.</param>
        /// <returns>The new current value.</returns>
        public override Vector3 Update(Vector3 target)
        {
            Vector3 currentVelocity = velocity;
            value = Vector3.SmoothDamp(value, target, ref currentVelocity, smoothTime, maxSpeed);
            velocity = currentVelocity;
            return value;
        }

        /// <summary>
        /// Smoothes the current value to the target value
        /// with the given delta time.
        /// </summary>
        /// <param name="target">The target value to animate towards.</param>
        /// <param name="deltaTime">The amount of seconds elapsed since the last update.</param>
        /// <returns>The new current value.</returns>
        public override Vector3 Update(Vector3 target, float deltaTime)
        {
            Vector3 currentVelocity = velocity;
            value = Vector3.SmoothDamp(value, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
            velocity = currentVelocity;
            return value;
        }

    }

}
