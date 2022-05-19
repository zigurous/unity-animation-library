using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Rotates an object around a point by a given speed.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Rotate Around")]
    public sealed class RotateAround : UpdateBehavior
    {
        /// <summary>
        /// The point to rotate around.
        /// </summary>
        [Tooltip("The point to rotate around.")]
        public Transform point;

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

        /// <inheritdoc/>
        protected override void OnUpdate(float deltaTime)
        {
            transform.RotateAround(point.position, axis, speed * deltaTime);
        }

    }

}
