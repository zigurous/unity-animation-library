using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Moves toward the position of another transform using a smooth damping
    /// function.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Smooth Follow")]
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
        public Vector3 offset = Vector3.zero;

        /// <summary>
        /// How quickly the transform moves toward the target's position. Small
        /// numbers make the transform more responsive. Larger numbers make the
        /// transform respond more slowly.
        /// </summary>
        [Tooltip("How quickly the transform moves toward target's position. Small numbers make the transform more responsive. Larger numbers make the transform respond more slowly.")]
        public float damping = 0.3f;

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

            // Calculate the offset position from the follow target
            // accounting for the rotation of the object
            Vector3 targetPosition = target.position;
            targetPosition += target.rotation * offset;

            // Move the transform to the target's position
            transform.position = Vector3.SmoothDamp(
                current: transform.position,
                target: targetPosition,
                currentVelocity: ref velocity,
                smoothTime: damping,
                maxSpeed: maxSpeed);
        }

    }

}
