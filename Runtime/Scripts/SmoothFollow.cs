using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Moves toward the position of another transform
    /// using a smooth damping function.
    /// </summary>
    public sealed class SmoothFollow : MonoBehaviour
    {
        /// <summary>
        /// The transform to follow.
        /// </summary>
        [Tooltip("The transform to follow.")]
        public Transform target;

        /// <summary>
        /// The local offset position from the target's position
        /// that the camera moves toward.
        /// </summary>
        [Tooltip("The local offset position from the target's position that the camera moves toward.")]
        public Vector3 offset = Vector3.zero;

        /// <summary>
        /// How quickly the transform moves toward the
        /// target's position. Small numbers make the
        /// transform more responsive. Larger numbers make
        /// the transform respond more slowly.
        /// </summary>
        [Tooltip("How quickly the transform moves toward target's position. Small numbers make the transform more responsive. Larger numbers make the transform respond more slowly.")]
        public float damping = 0.3f;

        /// <summary>
        /// The maximum amount of units the transform can
        /// move per tick.
        /// </summary>
        [Tooltip("The maximum amount of units the transform can move per tick.")]
        public float maxSpeed = Mathf.Infinity;

        /// <summary>
        /// The velocity of the transform as it moves toward
        /// the target's position.
        /// </summary>
        private Vector3 _velocity;

        private void OnDestroy()
        {
            this.target = null;
        }

        private void Update()
        {
            if (this.target != null)
            {
                // Calculate the offset position from the follow target
                // accounting for the rotation of the object
                Vector3 targetPosition = this.target.position;
                targetPosition += this.target.rotation * this.offset;

                // Move the transform to the target's position
                this.transform.position = Vector3.SmoothDamp(
                    current: this.transform.position,
                    target: targetPosition,
                    currentVelocity: ref _velocity,
                    smoothTime: this.damping,
                    maxSpeed: this.maxSpeed);
            }
        }

    }

}
