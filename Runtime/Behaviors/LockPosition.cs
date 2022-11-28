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
        /// The coordinate space the transform is updated in.
        /// </summary>
        [Tooltip("The coordinate space the transform is updated in.")]
        public Space space = Space.World;

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
            if (useTransformPosition)
            {
                if (space == Space.World) {
                    lockedPosition = transform.position;
                } else {
                    lockedPosition = transform.localPosition;
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

        private void LockLocalSpace()
        {
            Vector3 position = transform.localPosition;

            if (constraints.Contains(AxisConstraint.X)) {
                position.x = lockedPosition.x;
            }

            if (constraints.Contains(AxisConstraint.Y)) {
                position.y = lockedPosition.y;
            }

            if (constraints.Contains(AxisConstraint.Z)) {
                position.z = lockedPosition.z;
            }

            transform.localPosition = position;
        }

    }

}
