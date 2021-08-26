using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Gradually changes a Vector2 over time using a spring-damper function,
    /// which will never overshoot.
    /// </summary>
    [System.Serializable]
    public class SmoothDampVector2 : SmoothDamp<Vector2>
    {
        /// <summary>
        /// Smoothes the current value to the target value.
        /// </summary>
        /// <param name="target">The target value.</param>
        /// <returns>The new current value.</returns>
        public override Vector2 Update(Vector2 target)
        {
            this.value = Vector2.SmoothDamp(this.value, target,
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
        public override Vector2 Update(Vector2 target, float deltaTime)
        {
            this.value = Vector2.SmoothDamp(this.value, target,
                ref _velocity,
                this.smoothTime,
                this.maxSpeed,
                deltaTime);

            return this.value;
        }

    }

}
