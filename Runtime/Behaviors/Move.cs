using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Moves an object in space by a given speed.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Move")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/Move")]
    public sealed class Move : UpdateBehaviour
    {
        /// <summary>
        /// The coordinate space in which the object moves.
        /// </summary>
        [Tooltip("The coordinate space in which the object moves.")]
        public Space space = Space.World;

        /// <summary>
        /// The speed at which the object moves.
        /// </summary>
        [Tooltip("The speed at which the object moves.")]
        public Vector3 speed = Vector3.zero;

        /// <inheritdoc/>
        protected override void OnUpdate(float deltaTime)
        {
            transform.Translate(speed * deltaTime, space);
        }

    }

}
