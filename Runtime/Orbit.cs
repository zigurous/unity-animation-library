using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Orbits an object around another object with a given speed and radius.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Orbit")]
    public sealed class Orbit : MonoBehaviour
    {
        /// <summary>
        /// The transform the object orbits around.
        /// </summary>
        [Tooltip("The transform the object orbits around.")]
        public Transform center;

        /// <summary>
        /// The speed at which the object orbits.
        /// </summary>
        [Tooltip("The speed at which the object orbits.")]
        public float speed = 45f;

        /// <summary>
        /// The distance from the center of the object being orbited.
        /// </summary>
        [Tooltip("The distance from the center of the object being orbited.")]
        public float radius = 1f;

        /// <summary>
        /// The initial angle in degrees of the orbiting object.
        /// </summary>
        [Tooltip("The initial angle in degrees of the orbiting object.")]
        [Range(0f, 360f)]
        public float startAngle = 0f;

        /// <summary>
        /// The current angle in degrees of the orbiting object.
        /// </summary>
        public float angle { get; private set; }

        /// <summary>
        /// The update mode during which the object orbits.
        /// </summary>
        [Tooltip("The update mode during which the object orbits.")]
        public UpdateMode updateMode = UpdateMode.Update;

        private void Start()
        {
            this.angle = this.startAngle;
        }

        private void Update()
        {
            if (this.center != null && this.updateMode == UpdateMode.Update)
            {
                this.angle += this.speed * Time.deltaTime;
                SetPosition(this.angle);
            }
        }

        private void LateUpdate()
        {
            if (this.center != null && this.updateMode == UpdateMode.LateUpdate)
            {
                this.angle += this.speed * Time.deltaTime;
                SetPosition(this.angle);
            }
        }

        private void FixedUpdate()
        {
            if (this.center != null && this.updateMode == UpdateMode.FixedUpdate)
            {
                this.angle += this.speed * Time.fixedDeltaTime;
                SetPosition(this.angle);
            }
        }

        private void SetPosition(float angle)
        {
            float radians = angle * Mathf.Deg2Rad;

            this.transform.position = new Vector3(
                x: this.center.position.x + (Mathf.Cos(radians) * this.radius),
                y: this.center.position.y,
                z: this.center.position.z + (Mathf.Sin(radians) * this.radius));
        }

    }

}
