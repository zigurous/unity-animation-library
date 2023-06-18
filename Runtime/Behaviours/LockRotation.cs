using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Locks the rotation of the transform to a specified value.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Lock Rotation")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/LockRotation")]
    [DefaultExecutionOrder(100)]
    public sealed class LockRotation : MonoBehaviour
    {
        /// <summary>
        /// The coordinate space the transform is updated in.
        /// </summary>
        [Tooltip("The coordinate space the transform is updated in.")]
        public Space space = Space.World;

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
            if (useTransformRotation)
            {
                if (space == Space.World) {
                    lockedRotation = transform.eulerAngles;
                } else {
                    lockedRotation = transform.localEulerAngles;
                }
            }
        }

        private void LateUpdate()
        {
            if (space == Space.World) {
                LockWorldSpace();
            } else {
                LockLocalSpace();
            }
        }

        private void LockWorldSpace()
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

        private void LockLocalSpace()
        {
            Vector3 eulerAngles = transform.localEulerAngles;

            if (constraints.Contains(AxisConstraint.X)) {
                eulerAngles.x = lockedRotation.x;
            }

            if (constraints.Contains(AxisConstraint.Y)) {
                eulerAngles.y = lockedRotation.y;
            }

            if (constraints.Contains(AxisConstraint.Z)) {
                eulerAngles.z = lockedRotation.z;
            }

            transform.localEulerAngles = eulerAngles;
        }

    }

}
