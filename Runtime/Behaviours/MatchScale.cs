using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Matches the scale of the transform to another transform.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Match Scale")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/MatchScale")]
    [DefaultExecutionOrder(100)]
    public sealed class MatchScale : MonoBehaviour
    {
        /// <summary>
        /// The scale axes to match.
        /// </summary>
        [Tooltip("The scale axes to match.")]
        public AxisConstraint constraints = (AxisConstraint)~0;

        /// <summary>
        /// The target transform to match the scale to.
        /// </summary>
        [Tooltip("The target transform to match the scale to.")]
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
