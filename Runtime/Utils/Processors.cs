using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Functions for processing input values.
    /// </summary>
    internal static class Processors
    {
        /// <summary>
        /// Gradually changes a quaternion towards a desired goal over time.
        /// </summary>
        /// <param name="current">The current rotation.</param>
        /// <param name="target">The rotation we are trying to reach.</param>
        /// <param name="velocity">The current velocity, this value is modified by the function every time you call it.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        /// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
        /// <returns>The smooth damped value.</returns>
        internal static Quaternion SmoothDamp(Quaternion current, Quaternion target, ref Quaternion velocity, float smoothTime, float maxSpeed, float deltaTime)
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

        /// <summary>
        /// Gradually changes a quaternion towards a desired goal over time.
        /// </summary>
        /// <param name="current">The current rotation.</param>
        /// <param name="target">The rotation we are trying to reach.</param>
        /// <param name="velocity">The current velocity, this value is modified by the function every time you call it.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        /// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
        internal static void SmoothDamp(this ref Quaternion current, Quaternion target, ref Quaternion velocity, float smoothTime, float maxSpeed = Mathf.Infinity)
        {
            current = SmoothDamp(current, target, ref velocity, smoothTime, maxSpeed, Time.deltaTime);
        }

        /// <summary>
        /// Gradually changes a vector towards a desired goal over time.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="target">The position we are trying to reach.</param>
        /// <param name="velocity">The current velocity, this value is modified by the function every time you call it.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        /// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
        internal static void SmoothDamp(this ref Vector3 current, Vector3 target, ref Vector3 velocity, float smoothTime, float maxSpeed = Mathf.Infinity)
        {
            current = Vector3.SmoothDamp(current, target, ref velocity, smoothTime, maxSpeed);
        }

    }

}
