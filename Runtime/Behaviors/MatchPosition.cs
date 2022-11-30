using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Matches the position of the transform to another transform.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Match Position")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/MatchPosition")]
    [DefaultExecutionOrder(100)]
    public sealed class MatchPosition : MonoBehaviour
    {
        /// <summary>
        /// The coordinate space the transform is updated in.
        /// </summary>
        [Tooltip("The coordinate space the transform is updated in.")]
        public Space space = Space.World;

        /// <summary>
        /// The position axes to match.
        /// </summary>
        [Tooltip("The position axes to match.")]
        public AxisConstraint constraints = (AxisConstraint)~0;

        /// <summary>
        /// The target transform to match the position to.
        /// </summary>
        [Tooltip("The target transform to match the position to.")]
        public Transform matchedTransform;

        private void LateUpdate()
        {
            if (matchedTransform != null)
            {
                if (space == Space.World) {
                    MatchWorldSpace();
                } else {
                    MatchLocalSpace();
                }
            }
        }

        private void MatchWorldSpace()
        {
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

        private void MatchLocalSpace()
        {
            Vector3 position = transform.localPosition;

            if (constraints.Contains(AxisConstraint.X)) {
                position.x = matchedTransform.localPosition.x;
            }

            if (constraints.Contains(AxisConstraint.Y)) {
                position.y = matchedTransform.localPosition.y;
            }

            if (constraints.Contains(AxisConstraint.Z)) {
                position.z = matchedTransform.localPosition.z;
            }

            transform.localPosition = position;
        }

    }

}
