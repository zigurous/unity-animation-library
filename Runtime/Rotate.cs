using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Rotates an object in space by a given speed.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Rotate")]
    public sealed class Rotate : MonoBehaviour
    {
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
            if (updateMode == UpdateMode.Update) {
                transform.Rotate(axis * speed * Time.deltaTime, space);
            }
        }

        private void LateUpdate()
        {
            if (updateMode == UpdateMode.LateUpdate) {
                transform.Rotate(axis * speed * Time.deltaTime, space);
            }
        }

        private void FixedUpdate()
        {
            if (updateMode == UpdateMode.FixedUpdate) {
                transform.Rotate(axis * speed * Time.fixedDeltaTime, space);
            }
        }

    }

}
