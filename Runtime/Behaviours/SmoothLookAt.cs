using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Rotates toward the position of another transform using a smooth damping
    /// function.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Smooth Look At")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/SmoothLookAt")]
    [DefaultExecutionOrder(100)]
    public sealed class SmoothLookAt : MonoBehaviour
    {
        /// <summary>
        /// The transform to look at.
        /// </summary>
        [Tooltip("The transform to look at.")]
        public Transform target;

        /// <summary>
        /// The local offset position from the target's position that the camera
        /// looks at.
        /// </summary>
        [Tooltip("The local offset position from the target's position that the camera looks at.")]
        public Vector3 offset;

        /// <summary>
        /// The coordinate space in which the object rotates.
        /// </summary>
        [Tooltip("The coordinate space in which the object rotates.")]
        public Space space = Space.World;

        /// <summary>
        /// Prevents rotation around the specified axes.
        /// </summary>
        [Tooltip("Prevents rotation around the specified axes.")]
        public AxisConstraint constraints = 0;

        /// <summary>
        /// How quickly the transform rotates toward the target's position.
        /// Small numbers make the transform more responsive. Larger numbers
        /// make the transform respond more slowly.
        /// </summary>
        [Tooltip("How quickly the transform rotates toward the target's position. Small numbers make the transform more responsive. Larger numbers make the transform respond more slowly.")]
        public float damping = 0.25f;

        /// <summary>
        /// The maximum amount the transform can rotate per update.
        /// </summary>
        [Tooltip("The maximum amount the transform can rotate per update.")]
        public float maxSpeed = 1f;

        /// <summary>
        /// The velocity of the transform as it rotates toward the target's
        /// position.
        /// </summary>
        private Quaternion velocity;

        private void LateUpdate()
        {
            if (target == null) {
                return;
            }

            Vector3 targetPosition = target.position + (target.rotation * offset);
            Vector3 targetDirection = targetPosition - transform.position;

            if (constraints.Contains(AxisConstraint.X)) targetDirection.x = 0f;
            if (constraints.Contains(AxisConstraint.Y)) targetDirection.y = 0f;
            if (constraints.Contains(AxisConstraint.Z)) targetDirection.z = 0f;

            Quaternion targetRotation = targetDirection != Vector3.zero ?
                Quaternion.LookRotation(targetDirection) :
                Quaternion.identity;

            if (space == Space.World) {
                transform.rotation = SmoothDamp(transform.rotation, targetRotation, ref velocity, damping, maxSpeed);
            } else {
                transform.localRotation = SmoothDamp(transform.localRotation, targetRotation, ref velocity, damping, maxSpeed);
            }
        }

        private static Quaternion SmoothDamp(Quaternion current, Quaternion target, ref Quaternion velocity, float smoothTime, float maxSpeed)
        {
            float dot = Quaternion.Dot(current, target);
            float direction = dot > 0f ? 1f : -1f;
            target.x *= direction;
            target.y *= direction;
            target.z *= direction;
            target.w *= direction;

            Vector4 result = new Vector4(
                x: Mathf.SmoothDamp(current.x, target.x, ref velocity.x, smoothTime, maxSpeed),
                y: Mathf.SmoothDamp(current.y, target.y, ref velocity.y, smoothTime, maxSpeed),
                z: Mathf.SmoothDamp(current.z, target.z, ref velocity.z, smoothTime, maxSpeed),
                w: Mathf.SmoothDamp(current.w, target.w, ref velocity.w, smoothTime, maxSpeed)).normalized;

            Vector4 error = Vector4.Project(new Vector4(velocity.x, velocity.y, velocity.z, velocity.w), result);
            velocity.x -= error.x;
            velocity.y -= error.y;
            velocity.z -= error.z;
            velocity.w -= error.w;

            return new Quaternion(result.x, result.y, result.z, result.w);
        }

    }

}
