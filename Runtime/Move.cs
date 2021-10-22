using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Moves an object in space by a given speed.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Move")]
    public sealed class Move : MonoBehaviour
    {
        /// <summary>
        /// The speed at which the object moves.
        /// </summary>
        [Tooltip("The speed at which the object moves.")]
        public Vector3 speed = Vector3.zero;

        /// <summary>
        /// The coordinate space in which the object moves.
        /// </summary>
        [Tooltip("The coordinate space in which the object moves.")]
        public Space space = Space.World;

        /// <summary>
        /// The update mode during which the object moves.
        /// </summary>
        [Tooltip("The update mode during which the object moves.")]
        public UpdateMode updateMode = UpdateMode.Update;

        private void Update()
        {
            if (updateMode == UpdateMode.Update) {
                transform.Translate(speed * Time.deltaTime, space);
            }
        }

        private void LateUpdate()
        {
            if (updateMode == UpdateMode.LateUpdate) {
                transform.Translate(speed * Time.deltaTime, space);
            }
        }

        private void FixedUpdate()
        {
            if (updateMode == UpdateMode.FixedUpdate) {
                transform.Translate(speed * Time.fixedDeltaTime, space);
            }
        }

    }

}
