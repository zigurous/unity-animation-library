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
        /// <inheritdoc />
        /// <param name="target">The target value.</param>
        public override Vector3 Update(Vector3 target)
        {
            this.value = Vector3.SmoothDamp(this.value, target,
                ref _velocity,
                this.smoothTime,
                this.maxSpeed);

            return this.value;
        }

        /// <inheritdoc />
        /// <param name="target">The target value.</param>
        public override Vector3 Update(Vector3 target, float deltaTime)
        {
            this.value = Vector3.SmoothDamp(this.value, target,
                ref _velocity,
                this.smoothTime,
                this.maxSpeed,
                deltaTime);

            return this.value;
        }

    }

}
