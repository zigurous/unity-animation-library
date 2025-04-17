using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Rotates an object over time by a given speed.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Rotate Over Time")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/RotateOverTime")]
    public sealed class RotateOverTime : UpdateBehaviour
    {
        /// <summary>
        /// The coordinate space in which the object rotates.
        /// </summary>
        [Tooltip("The coordinate space in which the object rotates.")]
        public Space space = Space.Self;

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
            transform.Rotate(deltaTime * speed * axis, space);
        }

    }

}
