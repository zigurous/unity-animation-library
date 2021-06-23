using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Rotates an object in space by a given speed.
    /// </summary>
    public sealed class Rotate : MonoBehaviour
    {
        /// <summary>
        /// The speed at which the object rotates.
        /// </summary>
        [Tooltip("The speed at which the object rotates.")]
        public Vector3 speed = Vector3.up;

        /// <summary>
        /// The coordinate space in which the object rotates.
        /// </summary>
        [Tooltip("The coordinate space in which the object rotates.")]
        public Space space = Space.World;

        /// <summary>
        /// The update mode during which the object rotates.
        /// </summary>
        [Tooltip("The update mode during which the object rotates.")]
        public UpdateMode updateMode = UpdateMode.Update;

        private void Update()
        {
            if (this.updateMode == UpdateMode.Update) {
                this.transform.Rotate(this.speed * Time.deltaTime, this.space);
            }
        }

        private void LateUpdate()
        {
            if (this.updateMode == UpdateMode.LateUpdate) {
                this.transform.Rotate(this.speed * Time.deltaTime, this.space);
            }
        }

        private void FixedUpdate()
        {
            if (this.updateMode == UpdateMode.FixedUpdate) {
                this.transform.Rotate(this.speed * Time.fixedDeltaTime, this.space);
            }
        }

    }

}
