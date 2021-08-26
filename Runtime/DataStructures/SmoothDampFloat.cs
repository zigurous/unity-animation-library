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
            this.value = Mathf.SmoothDamp(this.value, target,
                ref _velocity,
                this.smoothTime,
                this.maxSpeed);

            return this.value;
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
            this.value = Mathf.SmoothDamp(this.value, target,
                ref _velocity,
                this.smoothTime,
                this.maxSpeed,
                deltaTime);

            return this.value;
        }

    }

}
