using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Rotates toward the position of another transform
    /// using a smooth damping function.
    /// </summary>
    public sealed class SmoothLookAt : MonoBehaviour
    {
        /// <summary>
        /// The transform to look at.
        /// </summary>
        [Tooltip("The transform to look at.")]
        public Transform target;

        /// <summary>
        /// The local offset position from the target's position
        /// that the camera looks at.
        /// </summary>
        [Tooltip("The local offset position from the target's position that the camera looks at.")]
        public Vector3 offset = Vector3.zero;

        /// <summary>
        /// How quickly the transform rotates toward the
        /// target's position. Small numbers make the
        /// transform more responsive. Larger numbers make
        /// the transform respond more slowly.
        /// </summary>
        [Tooltip("How quickly the transform rotates toward the target's position. Small numbers make the transform more responsive. Larger numbers make the transform respond more slowly.")]
        public float damping = 0.3f;

        /// <summary>
        /// The maximum amount of degrees the transform
        /// can rotate per update.
        /// </summary>
        [Tooltip("The maximum amount of degrees the transform can rotate per update.")]
        public float maxSpeed = Mathf.Infinity;

        /// <summary>
        /// The velocity of the transform as it rotates toward
        /// the target's position.
        /// </summary>
        private Quaternion _velocity;

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

                // Calculate the rotation direction to the target
                Quaternion targetRotation = Quaternion.LookRotation(targetPosition - this.transform.position);

                // Rotate the camera to the target direction
                this.transform.rotation = SmoothDamp(
                    current: this.transform.rotation,
                    target: targetRotation,
                    currentVelocity: ref _velocity,
                    smoothTime: this.damping,
                    maxSpeed: this.maxSpeed);
            }
        }

        private Quaternion SmoothDamp(Quaternion current, Quaternion target, ref Quaternion currentVelocity, float smoothTime, float maxSpeed = Mathf.Infinity)
        {
            float dot = Quaternion.Dot(current, target);
            float direction = dot > 0.0f ? 1.0f : -1.0f;
            target.x *= direction;
            target.y *= direction;
            target.z *= direction;
            target.w *= direction;

            Vector4 result = new Vector4(
                x: Mathf.SmoothDamp(current.x, target.x, ref currentVelocity.x, smoothTime, maxSpeed),
                y: Mathf.SmoothDamp(current.y, target.y, ref currentVelocity.y, smoothTime, maxSpeed),
                z: Mathf.SmoothDamp(current.z, target.z, ref currentVelocity.z, smoothTime, maxSpeed),
                w: Mathf.SmoothDamp(current.w, target.w, ref currentVelocity.w, smoothTime, maxSpeed)).normalized;

            Vector4 error = Vector4.Project(new Vector4(currentVelocity.x, currentVelocity.y, currentVelocity.z, currentVelocity.w), result);
            currentVelocity.x -= error.x;
            currentVelocity.y -= error.y;
            currentVelocity.z -= error.z;
            currentVelocity.w -= error.w;

            return new Quaternion(result.x, result.y, result.z, result.w);
        }

    }

}
