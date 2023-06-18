using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Locks the rotation of the transform to a specified value.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Lock Rotation")]
    public sealed class LockRotation : MonoBehaviour
    {
        /// <summary>
        /// The rotation axes to lock.
        /// </summary>
        [Tooltip("The rotation axes to lock.")]
        public AxisConstraint constraints = (AxisConstraint)~0;

        /// <summary>
        /// Sets the locked rotation to the transform's rotation at startup.
        /// </summary>
        [Tooltip("Sets the locked rotation to the transform's rotation at startup.")]
        public bool useTransformRotation = true;

        /// <summary>
        /// The locked rotation of the transform.
        /// </summary>
        [Tooltip("The locked rotation of the transform.")]
        public Vector3 lockedRotation = Vector3.zero;

        private void Start()
        {
            if (useTransformRotation) {
                lockedRotation = transform.eulerAngles;
            }
        }

        private void LateUpdate()
        {
            Vector3 eulerAngles = transform.eulerAngles;

            if (constraints.Contains(AxisConstraint.X)) {
                eulerAngles.x = lockedRotation.x;
            }

            if (constraints.Contains(AxisConstraint.Y)) {
                eulerAngles.y = lockedRotation.y;
            }

            if (constraints.Contains(AxisConstraint.Z)) {
                eulerAngles.z = lockedRotation.z;
            }

            transform.eulerAngles = eulerAngles;
        }

    }

}
