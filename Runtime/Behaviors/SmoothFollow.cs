using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Moves toward the position of another transform using a smooth damping
    /// function.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Smooth Follow")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/SmoothFollow")]
    [DefaultExecutionOrder(100)]
    public sealed class SmoothFollow : MonoBehaviour
    {
        /// <summary>
        /// The transform to follow.
        /// </summary>
        [Tooltip("The transform to follow.")]
        public Transform target;

        /// <summary>
        /// The local offset position from the target's position that the camera
        /// moves toward.
        /// </summary>
        [Tooltip("The local offset position from the target's position that the camera moves toward.")]
        public Vector3 offset;

        /// <summary>
        /// The coordinate space in which the object moves.
        /// </summary>
        [Tooltip("The coordinate space in which the object moves.")]
        public Space space = Space.World;

        /// <summary>
        /// Prevents movement around the specified axes.
        /// </summary>
        [Tooltip("Prevents movement around the specified axes.")]
        public AxisConstraint constraints = 0;

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

            Vector3 currentPosition = space == Space.World ? transform.position : transform.localPosition;
            Vector3 targetPosition = target.position + (target.rotation * offset);

            if (constraints.Contains(AxisConstraint.X)) targetPosition.x = currentPosition.x;
            if (constraints.Contains(AxisConstraint.Y)) targetPosition.y = currentPosition.y;
            if (constraints.Contains(AxisConstraint.Z)) targetPosition.z = currentPosition.z;

            if (space == Space.World) {
                transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, damping, maxSpeed);
            } else {
                transform.localPosition = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, damping, maxSpeed);
            }
        }

    }

}
