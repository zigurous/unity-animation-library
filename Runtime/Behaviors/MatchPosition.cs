using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Matches the position of the transform to another.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Match Position")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/MatchPosition")]
    [DefaultExecutionOrder(100)]
    public sealed class MatchPosition : MonoBehaviour
    {
        /// <summary>
        /// The position axes to match.
        /// </summary>
        public AxisConstraint constraints = (AxisConstraint)~0;

        /// <summary>
        /// The target transform to match the position to.
        /// </summary>
        public Transform matchedTransform;

        private void LateUpdate()
        {
            if (matchedTransform == null) {
                return;
            }

            Vector3 position = transform.position;

            if (constraints.Contains(AxisConstraint.X)) {
                position.x = matchedTransform.position.x;
            }

            if (constraints.Contains(AxisConstraint.Y)) {
                position.y = matchedTransform.position.y;
            }

            if (constraints.Contains(AxisConstraint.Z)) {
                position.z = matchedTransform.position.z;
            }

            transform.position = position;
        }

    }

}
