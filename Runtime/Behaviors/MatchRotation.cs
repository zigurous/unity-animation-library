using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Matches the rotation of the transform to another.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Match Rotation")]
    public sealed class MatchRotation : MonoBehaviour
    {
        /// <summary>
        /// The rotation axes to match.
        /// </summary>
        public AxisConstraint constraints = (AxisConstraint)~0;

        /// <summary>
        /// The target transform to match the rotation to.
        /// </summary>
        public Transform matchedTransform;

        private void LateUpdate()
        {
            if (matchedTransform == null) {
                return;
            }

            Vector3 eulerAngles = transform.eulerAngles;

            if (constraints.Contains(AxisConstraint.X)) {
                eulerAngles.x = matchedTransform.eulerAngles.x;
            }

            if (constraints.Contains(AxisConstraint.Y)) {
                eulerAngles.y = matchedTransform.eulerAngles.y;
            }

            if (constraints.Contains(AxisConstraint.Z)) {
                eulerAngles.z = matchedTransform.eulerAngles.z;
            }

            transform.eulerAngles = eulerAngles;
        }

    }

}
