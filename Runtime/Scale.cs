using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Scales an object over time by a given speed.
    /// </summary>
    public sealed class Scale : MonoBehaviour
    {
        /// <summary>
        /// The speed at which the object's scale changes.
        /// </summary>
        [Tooltip("The speed at which the object's scale changes.")]
        public Vector3 speed = Vector3.zero;

        /// <summary>
        /// The update mode during which the object's scale changes.
        /// </summary>
        [Tooltip("The update mode during which the object's scale changes.")]
        public UpdateMode updateMode = UpdateMode.Update;

        private void Update()
        {
            if (this.updateMode == UpdateMode.Update) {
                this.transform.localScale += this.speed * Time.deltaTime;
            }
        }

        private void LateUpdate()
        {
            if (this.updateMode == UpdateMode.LateUpdate) {
                this.transform.localScale += this.speed * Time.deltaTime;
            }
        }

        private void FixedUpdate()
        {
            if (this.updateMode == UpdateMode.FixedUpdate) {
                this.transform.localScale += this.speed * Time.fixedDeltaTime;
            }
        }

    }

}
