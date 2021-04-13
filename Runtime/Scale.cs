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
        public Vector3 speed = Vector3.one;

        private void Update()
        {
            this.transform.localScale += this.speed * Time.deltaTime;
        }

    }

}
