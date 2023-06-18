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
        /// <param name="target">The target value to animate towards.</param>
        /// <returns>The new current value.</returns>
        public override Quaternion Update(Quaternion target)
        {
            Quaternion currentVelocity = velocity;
            value = SmoothDamp(value, target, ref currentVelocity, smoothTime, maxSpeed, Time.deltaTime);
            velocity = currentVelocity;
            return value;
        }

        /// <summary>
        /// Smoothes the current value to the target value with the given delta time.
        /// </summary>
        /// <param name="target">The target value to animate towards.</param>
        /// <param name="deltaTime">The time since the last call to this function.</param>
        /// <returns>The new current value.</returns>
        public override Quaternion Update(Quaternion target, float deltaTime)
        {
            Quaternion currentVelocity = velocity;
            value = SmoothDamp(value, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
            velocity = currentVelocity;
            return value;
        }

        /// <summary>
        /// Gradually changes a quaternion towards a desired goal over time.
        /// </summary>
        /// <param name="current">The current rotation.</param>
        /// <param name="target">The rotation we are trying to reach.</param>
        /// <param name="velocity">The current velocity, this value is modified by the function every time you call it.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        /// <param name="maxSpeed">Clamps the maximum speed of the damping.</param>
        /// <param name="deltaTime">The time since the last call to this function.</param>
        /// <returns>The smooth damped value.</returns>
        private static Quaternion SmoothDamp(Quaternion current, Quaternion target, ref Quaternion velocity, float smoothTime, float maxSpeed, float deltaTime)
        {
            float dot = Quaternion.Dot(current, target);
            float direction = dot > 0f ? 1f : -1f;
            target.x *= direction;
            target.y *= direction;
            target.z *= direction;
            target.w *= direction;

            Vector4 result = new Vector4(
                x: Mathf.SmoothDamp(current.x, target.x, ref velocity.x, smoothTime, maxSpeed, deltaTime),
                y: Mathf.SmoothDamp(current.y, target.y, ref velocity.y, smoothTime, maxSpeed, deltaTime),
                z: Mathf.SmoothDamp(current.z, target.z, ref velocity.z, smoothTime, maxSpeed, deltaTime),
                w: Mathf.SmoothDamp(current.w, target.w, ref velocity.w, smoothTime, maxSpeed, deltaTime)).normalized;

            Vector4 error = Vector4.Project(new Vector4(velocity.x, velocity.y, velocity.z, velocity.w), result);
            velocity.x -= error.x;
            velocity.y -= error.y;
            velocity.z -= error.z;
            velocity.w -= error.w;

            return new Quaternion(result.x, result.y, result.z, result.w);
        }

    }

}
