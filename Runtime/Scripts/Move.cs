using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Moves an object in space by a given speed.
    /// </summary>
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

        private void Update()
        {
            this.transform.Translate(this.speed * Time.deltaTime, this.space);
        }

    }

}
