using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Rotates an object around a point by a given speed.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Rotate Around")]
    public sealed class RotateAround : MonoBehaviour
    {
        /// <summary>
        /// The point to rotate around.
        /// </summary>
        [Tooltip("The point to rotate around.")]
        public Transform point;

        /// <summary>
        /// The axis in which the object rotates.
        /// </summary>
        [Tooltip("The axis in which the object rotates.")]
        public Vector3 axis = Vector3.up;

        /// <summary>
        /// The speed at which the object rotates.
        /// </summary>
        [Tooltip("The speed at which the object rotates.")]
        public float speed = 45f;

        /// <summary>
        /// The update mode during which the object rotates.
        /// </summary>
        [Tooltip("The update mode during which the object rotates.")]
        public UpdateMode updateMode = UpdateMode.Update;

        private void Update()
        {
            if (point != null && updateMode == UpdateMode.Update) {
                transform.RotateAround(point.position, axis, speed * Time.deltaTime);
            }
        }

        private void LateUpdate()
        {
            if (point != null && updateMode == UpdateMode.LateUpdate) {
                transform.RotateAround(point.position, axis, speed * Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (point != null && updateMode == UpdateMode.FixedUpdate) {
                transform.RotateAround(point.position, axis, speed * Time.fixedDeltaTime);
            }
        }

    }

}
