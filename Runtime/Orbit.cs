using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Rotates an object around another object with a given speed and radius.
    /// </summary>
    public sealed class Orbit : MonoBehaviour
    {
        /// <summary>
        /// The transform the object rotates around.
        /// </summary>
        [Tooltip("The transform the object rotates around.")]
        public Transform center;

        /// <summary>
        /// The speed at which the object orbits.
        /// </summary>
        [Tooltip("The speed at which the object orbits.")]
        public float speed = 1.0f;

        /// <summary>
        /// The distance from the center of the object being orbited.
        /// </summary>
        [Tooltip("The distance from the center of the object being orbited.")]
        public float radius = 1.0f;

        /// <summary>
        /// The initial angle in degrees of the orbiting object.
        /// </summary>
        [Tooltip("The initial angle in degrees of the orbiting object.")]
        [Range(0.0f, 360.0f)]
        public float startAngle = 0.0f;

        /// <summary>
        /// The current angle in degrees of the orbiting object.
        /// </summary>
        public float angle { get; private set; }

        private void Start()
        {
            this.angle = this.startAngle;
        }

        private void LateUpdate()
        {
            if (this.center == null) {
                return;
            }

            this.angle += this.speed * Time.deltaTime;
            float radians = this.angle * Mathf.Deg2Rad;

            this.transform.position = new Vector3(
                x: this.center.position.x + (Mathf.Cos(radians) * this.radius),
                y: this.center.position.y,
                z: this.center.position.z + (Mathf.Sin(radians) * this.radius)
            );
        }

    }

}
