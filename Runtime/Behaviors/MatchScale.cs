using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Matches the scale of the transform to another.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Match Scale")]
    public sealed class MatchScale : MonoBehaviour
    {
        /// <summary>
        /// The scale axes to match.
        /// </summary>
        public AxisConstraint constraints = (AxisConstraint)~0;

        /// <summary>
        /// The target transform to match the scale to.
        /// </summary>
        public Transform matchedTransform;

        private void LateUpdate()
        {
            if (matchedTransform == null) {
                return;
            }

            Vector3 scale = transform.localScale;

            if (constraints.Contains(AxisConstraint.X)) {
                scale.x = matchedTransform.localScale.x;
            }

            if (constraints.Contains(AxisConstraint.Y)) {
                scale.y = matchedTransform.localScale.y;
            }

            if (constraints.Contains(AxisConstraint.Z)) {
                scale.z = matchedTransform.localScale.z;
            }

            transform.localScale = scale;
        }

    }

}
