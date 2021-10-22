using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Scales an object over time by a given speed.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Scale")]
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
            if (updateMode == UpdateMode.Update) {
                transform.localScale += speed * Time.deltaTime;
            }
        }

        private void LateUpdate()
        {
            if (updateMode == UpdateMode.LateUpdate) {
                transform.localScale += speed * Time.deltaTime;
            }
        }

        private void FixedUpdate()
        {
            if (updateMode == UpdateMode.FixedUpdate) {
                transform.localScale += speed * Time.fixedDeltaTime;
            }
        }

    }

}
