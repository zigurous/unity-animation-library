using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Locks the scale of the transform to a specified value.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Lock Scale")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/LockScale")]
    [DefaultExecutionOrder(100)]
    public sealed class LockScale : MonoBehaviour
    {
        /// <summary>
        /// The scale axes to lock.
        /// </summary>
        [Tooltip("The scale axes to lock.")]
        public AxisConstraint constraints = (AxisConstraint)~0;

        /// <summary>
        /// Sets the locked scale to the transform's scale at startup.
        /// </summary>
        [Tooltip("Sets the locked scale to the transform's scale at startup.")]
        public bool useTransformScale = true;

        /// <summary>
        /// The locked scale of the transform.
        /// </summary>
        [Tooltip("The locked scale of the transform.")]
        public Vector3 lockedScale = Vector3.one;

        private void Start()
        {
            if (useTransformScale) {
                lockedScale = transform.eulerAngles;
            }
        }

        private void LateUpdate()
        {
            Vector3 scale = transform.localScale;

            if (constraints.Contains(AxisConstraint.X)) {
                scale.x = lockedScale.x;
            }

            if (constraints.Contains(AxisConstraint.Y)) {
                scale.y = lockedScale.y;
            }

            if (constraints.Contains(AxisConstraint.Z)) {
                scale.z = lockedScale.z;
            }

            transform.localScale = scale;
        }

    }

}
