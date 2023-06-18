using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Gradually changes a color over time using a spring-damper function,
    /// which will never overshoot.
    /// </summary>
    [System.Serializable]
    public class SmoothDampColor : SmoothDamp<Color>
    {
        /// <summary>
        /// Smoothes the current value to the target value.
        /// </summary>
        /// <param name="target">The target value to animate towards.</param>
        /// <returns>The new current value.</returns>
        public override Color Update(Color target)
        {
            Color currentVelocity = velocity;
            Color currentValue = value;

            currentValue.r = Mathf.SmoothDamp(currentValue.r, target.r, ref currentVelocity.r, smoothTime, maxSpeed);
            currentValue.g = Mathf.SmoothDamp(currentValue.g, target.g, ref currentVelocity.g, smoothTime, maxSpeed);
            currentValue.b = Mathf.SmoothDamp(currentValue.b, target.b, ref currentVelocity.b, smoothTime, maxSpeed);
            currentValue.a = Mathf.SmoothDamp(currentValue.a, target.a, ref currentVelocity.a, smoothTime, maxSpeed);

            value = currentValue;
            velocity = currentVelocity;

            return value;
        }

        /// <summary>
        /// Smoothes the current value to the target value with the given delta time.
        /// </summary>
        /// <param name="target">The target value to animate towards.</param>
        /// <param name="deltaTime">The time since the last call to this function.</param>
        /// <returns>The new current value.</returns>
        public override Color Update(Color target, float deltaTime)
        {
            Color currentVelocity = velocity;
            Color currentValue = value;

            currentValue.r = Mathf.SmoothDamp(currentValue.r, target.r, ref currentVelocity.r, smoothTime, maxSpeed, deltaTime);
            currentValue.g = Mathf.SmoothDamp(currentValue.g, target.g, ref currentVelocity.g, smoothTime, maxSpeed, deltaTime);
            currentValue.b = Mathf.SmoothDamp(currentValue.b, target.b, ref currentVelocity.b, smoothTime, maxSpeed, deltaTime);
            currentValue.a = Mathf.SmoothDamp(currentValue.a, target.a, ref currentVelocity.a, smoothTime, maxSpeed, deltaTime);

            value = currentValue;
            velocity = currentVelocity;

            return value;
        }

    }

}
