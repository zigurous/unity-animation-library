using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Scales an object over time by a given speed.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Scale")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/Scale")]
    public sealed class Scale : UpdateBehaviour
    {
        /// <summary>
        /// The speed at which the object's scale changes.
        /// </summary>
        [Tooltip("The speed at which the object's scale changes.")]
        public Vector3 speed = Vector3.zero;

        /// <summary>
        /// Clamps the scale to a minimum value.
        /// </summary>
        [Tooltip("Clamps the scale to a minimum value.")]
        public Vector3 minScale = new(Mathf.NegativeInfinity, Mathf.NegativeInfinity, Mathf.NegativeInfinity);

        /// <summary>
        /// Clamps the scale to a maximum value.
        /// </summary>
        [Tooltip("Clamps the scale to a maximum value.")]
        public Vector3 maxScale = new(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity);

        /// <inheritdoc/>
        protected override void OnUpdate(float deltaTime)
        {
            Vector3 scale = transform.localScale;
            scale += speed * deltaTime;
            scale.x = Mathf.Clamp(scale.x, minScale.x, maxScale.x);
            scale.y = Mathf.Clamp(scale.y, minScale.y, maxScale.y);
            scale.z = Mathf.Clamp(scale.z, minScale.z, maxScale.z);
            transform.localScale = scale;
        }

    }

}
