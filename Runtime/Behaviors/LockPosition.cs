using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Locks the position of the transform to a specified value.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Lock Position")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/LockPosition")]
    [DefaultExecutionOrder(100)]
    public sealed class LockPosition : MonoBehaviour
    {
        /// <summary>
        /// The position axes to lock.
        /// </summary>
        [Tooltip("The position axes to lock.")]
        public AxisConstraint constraints = (AxisConstraint)~0;

        /// <summary>
        /// Sets the locked position to the transform's position at startup.
        /// </summary>
        [Tooltip("Sets the locked position to the transform's position at startup.")]
        public bool useTransformPosition = true;

        /// <summary>
        /// The locked position of the transform.
        /// </summary>
        [Tooltip("The locked position of the transform.")]
        public Vector3 lockedPosition = Vector3.zero;

        private void Start()
        {
            if (useTransformPosition) {
                lockedPosition = transform.position;
            }
        }

        private void LateUpdate()
        {
            Vector3 position = transform.position;

            if (constraints.Contains(AxisConstraint.X)) {
                position.x = lockedPosition.x;
            }

            if (constraints.Contains(AxisConstraint.Y)) {
                position.y = lockedPosition.y;
            }

            if (constraints.Contains(AxisConstraint.Z)) {
                position.z = lockedPosition.z;
            }

            transform.position = position;
        }

    }

}
