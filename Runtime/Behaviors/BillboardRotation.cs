using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Rotates the object so it is always facing the camera.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Billboard Rotation")]
    public sealed class BillboardRotation : MonoBehaviour
    {
        /// <summary>
        /// The camera to look at. The main camera will be used if not assigned.
        /// </summary>
        [Tooltip("The camera to look at. The main camera will be used if not assigned.")]
        public Camera lookCamera;

        /// <summary>
        /// Restricts rotation around the specified axes.
        /// </summary>
        [Tooltip("Restricts rotation around the specified axes.")]
        public AxisConstraint constraints = 0;

        /// <summary>
        /// The world up vector.
        /// </summary>
        [Tooltip("The world up vector.")]
        public Vector3 worldUp = Vector3.up;

        /// <summary>
        /// How quickly the transform rotates to look at the camera. Small
        /// numbers make the transform more responsive. Larger numbers make the
        /// transform respond more slowly.
        /// </summary>
        [Tooltip("How quickly the transform rotates to look at the camera. Small numbers make the transform more responsive. Larger numbers make the transform respond more slowly.")]
        public float damping = 0f;

        /// <summary>
        /// The maximum amount the transform can rotate per update.
        /// </summary>
        [Tooltip("The maximum amount the transform can rotate per update.")]
        public float maxSpeed = Mathf.Infinity;

        /// <summary>
        /// The velocity of the transform as it rotates toward the camera.
        /// </summary>
        private Quaternion velocity;

        private void Reset()
        {
            lookCamera = Camera.main;
        }

        private void LateUpdate()
        {
            // Auto-assign camera if not set
            if (lookCamera == null)
            {
                lookCamera = Camera.main;

                if (lookCamera == null) {
                    return;
                }
            }

            // Calculate the rotation direction to the target
            Vector3 lookDirection = lookCamera.transform.position - transform.position;

            // Constrain the look direction if specified
            if (constraints.Contains(AxisConstraint.X)) lookDirection.x = 0f;
            if (constraints.Contains(AxisConstraint.Y)) lookDirection.y = 0f;
            if (constraints.Contains(AxisConstraint.Z)) lookDirection.z = 0f;

            // Only set the look rotation if the direction vector is not zero
            // otherwise an error is triggered
            Quaternion lookRotation = lookDirection != Vector3.zero ?
                Quaternion.LookRotation(lookDirection) :
                Quaternion.identity;

            // Rotate the object to look at the camera
            Quaternion rotation = transform.rotation;
            rotation = SmoothDamp(rotation, lookRotation, ref velocity, damping, maxSpeed);
            transform.rotation = rotation;
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
