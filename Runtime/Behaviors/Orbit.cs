using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Orbits an object around another object with a given speed and radius.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Orbit")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/Orbit")]
    public sealed class Orbit : UpdateBehaviour
    {
        /// <summary>
        /// The coordinate space in which the object rotates.
        /// </summary>
        [Tooltip("The coordinate space in which the object rotates.")]
        public Space space = Space.World;

        /// <summary>
        /// The transform the object orbits around. If not assigned, the
        /// transform orbits around the origin of the specified coordinate
        /// space.
        /// </summary>
        [Tooltip("The transform the object orbits around. If not assigned, the transform orbits around the origin of the specified coordinate space.")]
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
        /// The current angle of the orbiting object in degrees.
        /// </summary>
        public float angle { get; set; }

        /// <inheritdoc/>
        protected override void OnUpdate(float deltaTime)
        {
            angle += speed * deltaTime;

            SetPosition(angle);
        }

        private void SetPosition(float angle)
        {
            float radians = angle * Mathf.Deg2Rad;

            Vector3 centerPosition = Vector3.zero;

            if (space == Space.World)
            {
                if (center != null) {
                    centerPosition = center.position;
                }

                transform.position = new Vector3(
                    x: centerPosition.x + (Mathf.Cos(radians) * radius),
                    y: centerPosition.y,
                    z: centerPosition.z + (Mathf.Sin(radians) * radius));
            }
            else
            {
                if (center != null) {
                    centerPosition = center.localPosition;
                }

                transform.localPosition = new Vector3(
                    x: centerPosition.x + (Mathf.Cos(radians) * radius),
                    y: centerPosition.y,
                    z: centerPosition.z + (Mathf.Sin(radians) * radius));
            }
        }

        private void Start()
        {
            angle = startAngle;
        }

    }

}
