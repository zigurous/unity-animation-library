using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Scales an object over time by a given speed.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Scale")]
    public sealed class Scale : UpdateBehaviour
    {
        /// <summary>
        /// The speed at which the object's scale changes.
        /// </summary>
        [Tooltip("The speed at which the object's scale changes.")]
        public Vector3 speed = Vector3.zero;

        /// <inheritdoc/>
        protected override void OnUpdate(float deltaTime)
        {
            transform.localScale += speed * deltaTime;
        }

    }

}
