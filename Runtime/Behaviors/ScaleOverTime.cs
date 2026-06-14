using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Scales an object over time by a given speed.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Scale Over Time")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/ScaleOverTime")]
    public sealed class ScaleOverTime : MonoBehaviour
    {
        /// <summary>
        /// The axis in which the object is scaled.
        /// </summary>
        [Tooltip("The axis in which the object is scaled.")]
        public Vector3 axis = Vector3.one;

        /// <summary>
        /// The speed at which the object is scaled.
        /// </summary>
        [Tooltip("The speed at which the object is scaled.")]
        public float speed = 1f;

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

        private void Update()
        {
            Vector3 scale = transform.localScale;
            scale += speed * Time.deltaTime * axis;
            scale.x = Mathf.Clamp(scale.x, minScale.x, maxScale.x);
            scale.y = Mathf.Clamp(scale.y, minScale.y, maxScale.y);
            scale.z = Mathf.Clamp(scale.z, minScale.z, maxScale.z);
            transform.localScale = scale;
        }

    }

}
