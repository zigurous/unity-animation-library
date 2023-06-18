using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Moves toward the position of another transform using a smooth damping
    /// function.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Smooth Follow")]
    [DefaultExecutionOrder(100)]
    public sealed class SmoothFollow : MonoBehaviour
    {
        /// <summary>
        /// The transform to follow.
        /// </summary>
        [Tooltip("The transform to follow.")]
        public Transform target;

        /// <summary>
        /// Prevents movement around the specified axes.
        /// </summary>
        [Tooltip("Prevents movement around the specified axes.")]
        public AxisConstraint constraints = 0;

        /// <summary>
        /// The local offset position from the target's position that the camera
        /// moves toward.
        /// </summary>
        [Tooltip("The local offset position from the target's position that the camera moves toward.")]
        public Vector3 offset;

        /// <summary>
        /// How quickly the transform moves toward the target's position. Small
        /// numbers make the transform more responsive. Larger numbers make the
        /// transform respond more slowly.
        /// </summary>
        [Tooltip("How quickly the transform moves toward target's position. Small numbers make the transform more responsive. Larger numbers make the transform respond more slowly.")]
        public float damping = 0.25f;

        /// <summary>
        /// The maximum amount of units the transform can move per tick.
        /// </summary>
        [Tooltip("The maximum amount of units the transform can move per tick.")]
        public float maxSpeed = Mathf.Infinity;

        /// <summary>
        /// The velocity of the transform as it moves toward the target's
        /// position.
        /// </summary>
        private Vector3 velocity;

        private void LateUpdate()
        {
            if (target == null) {
                return;
            }

            Vector3 currentPosition = transform.position;

            // Calculate the offset position from the follow target while
            // accounting for the rotation of the object
            Vector3 targetPosition = target.position;
            targetPosition += target.rotation * offset;

            // Constrain the position if specified
            if (constraints.Contains(AxisConstraint.X)) targetPosition.x = currentPosition.x;
            if (constraints.Contains(AxisConstraint.Y)) targetPosition.y = currentPosition.y;
            if (constraints.Contains(AxisConstraint.Z)) targetPosition.z = currentPosition.z;

            // Move the transform to the target's position
            currentPosition = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, damping, maxSpeed);
            transform.position = currentPosition;
        }

    }

}
