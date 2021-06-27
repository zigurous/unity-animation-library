using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Rotates an object around a point by a given speed.
    /// </summary>
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
        public float speed = 45.0f;

        /// <summary>
        /// The update mode during which the object rotates.
        /// </summary>
        [Tooltip("The update mode during which the object rotates.")]
        public UpdateMode updateMode = UpdateMode.Update;

        private void Update()
        {
            if (this.point != null && this.updateMode == UpdateMode.Update) {
                this.transform.RotateAround(this.point.position, this.axis, this.speed * Time.deltaTime);
            }
        }

        private void LateUpdate()
        {
            if (this.point != null && this.updateMode == UpdateMode.LateUpdate) {
                this.transform.RotateAround(this.point.position, this.axis, this.speed * Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (this.point != null && this.updateMode == UpdateMode.FixedUpdate) {
                this.transform.RotateAround(this.point.position, this.axis, this.speed * Time.fixedDeltaTime);
            }
        }

    }

}
