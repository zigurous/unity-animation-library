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
        /// <inheritdoc />
        /// <param name="target">The target value.</param>
        public override Vector2 Update(Vector2 target)
        {
            this.value = Vector2.SmoothDamp(this.value, target,
                ref _velocity,
                this.smoothTime,
                this.maxSpeed);

            return this.value;
        }

        /// <inheritdoc />
        /// <param name="target">The target value.</param>
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
