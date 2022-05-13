using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Rotates toward the position of another transform using a smooth damping
    /// function.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Smooth Look At")]
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
        /// How quickly the transform rotates toward the target's position.
        /// Small numbers make the transform more responsive. Larger numbers
        /// make the transform respond more slowly.
        /// </summary>
        [Tooltip("How quickly the transform rotates toward the target's position. Small numbers make the transform more responsive. Larger numbers make the transform respond more slowly.")]
        public float damping = 0.25f;

        /// <summary>
        /// The maximum amount of degrees the transform can rotate per update.
        /// </summary>
        [Tooltip("The maximum amount of degrees the transform can rotate per update.")]
        public float maxSpeed = Mathf.Infinity;

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

            // Calculate the offset position from the follow target accounting
            // for the rotation of the object
            Vector3 targetPosition = target.position;
            targetPosition += target.rotation * offset;

            // Calculate the rotation direction to the target
            Vector3 targetDirection = targetPosition - transform.position;
            Quaternion targetRotation = targetDirection != Vector3.zero ?
                Quaternion.LookRotation(targetDirection) :
                Quaternion.identity;

            // Rotate the camera to the target direction
            Quaternion rotation = transform.rotation;
            rotation.SmoothDamp(targetRotation, ref velocity, damping, maxSpeed);
            transform.rotation = rotation;
        }

    }

}
