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
        /// <inheritdoc />
        /// <param name="target">The target value.</param>
        public override float Update(float target)
        {
            this.value = Mathf.SmoothDamp(this.value, target,
                ref _velocity,
                this.smoothTime,
                this.maxSpeed);

            return this.value;
        }

        /// <inheritdoc />
        /// <param name="target">The target value.</param>
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
