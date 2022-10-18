using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Locks the transform properties to specified values.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Lock Transform")]
    public sealed class LockTransform : MonoBehaviour
    {
        /// <summary>
        /// The transform properties to lock.
        /// </summary>
        [Tooltip("The transform properties to lock.")]
        public TransformConstraint constraints = (TransformConstraint)~0;

        /// <summary>
        /// Sets the locked values to the transform's values at startup.
        /// </summary>
        [Tooltip("Sets the locked values to the transform's values at startup.")]
        public bool useTransformValues = true;

        /// <summary>
        /// The locked position of the transform.
        /// </summary>
        [Tooltip("The locked position of the transform.")]
        public Vector3 lockedPosition = Vector3.zero;

        /// <summary>
        /// The locked rotation of the transform.
        /// </summary>
        [Tooltip("The locked rotation of the transform.")]
        public Vector3 lockedRotation = Vector3.zero;

        /// <summary>
        /// The locked scale of the transform.
        /// </summary>
        [Tooltip("The locked scale of the transform.")]
        public Vector3 lockedScale = Vector3.one;

        private void Start()
        {
            if (useTransformValues)
            {
                lockedPosition = transform.position;
                lockedRotation = transform.eulerAngles;
                lockedScale = transform.localScale;
            }
        }

        private void LateUpdate()
        {
            if (constraints.Contains(TransformConstraint.Position)) {
                transform.position = lockedPosition;
            }

            if (constraints.Contains(TransformConstraint.Rotation)) {
                transform.eulerAngles = lockedRotation;
            }

            if (constraints.Contains(TransformConstraint.Scale)) {
                transform.localScale = lockedScale;
            }
        }

    }

}
