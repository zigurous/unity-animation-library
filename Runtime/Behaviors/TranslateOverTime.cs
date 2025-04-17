using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Translates an object over time by a given speed.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Translate Over Time")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/TranslateOverTime")]
    public sealed class TranslateOverTime : UpdateBehaviour
    {
        /// <summary>
        /// The coordinate space in which the object moves.
        /// </summary>
        [Tooltip("The coordinate space in which the object moves.")]
        public Space space = Space.Self;

        /// <summary>
        /// The axis in which the object moves.
        /// </summary>
        [Tooltip("The axis in which the object moves.")]
        public Vector3 axis = Vector3.forward;

        /// <summary>
        /// The speed at which the object moves.
        /// </summary>
        [Tooltip("The speed at which the object moves.")]
        public float speed = 1f;

        /// <inheritdoc/>
        protected override void OnUpdate(float deltaTime)
        {
            transform.Translate(speed * deltaTime * axis, space);
        }

    }

}
