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

        private void Update()
        {
            this.transform.Rotate(this.speed * Time.deltaTime, this.space);
        }

    }

}
