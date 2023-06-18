using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Matches the rotation of the transform to another transform.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Match Rotation")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/MatchRotation")]
    [DefaultExecutionOrder(100)]
    public sealed class MatchRotation : MonoBehaviour
    {
        /// <summary>
        /// The coordinate space the transform is updated in.
        /// </summary>
        [Tooltip("The coordinate space the transform is updated in.")]
        public Space space = Space.World;

        /// <summary>
        /// The rotation axes to match.
        /// </summary>
        [Tooltip("The rotation axes to match.")]
        public AxisConstraint constraints = (AxisConstraint)~0;

        /// <summary>
        /// The target transform to match the rotation to.
        /// </summary>
        [Tooltip("The target transform to match the rotation to.")]
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

        private void MatchLocalSpace()
        {
            Vector3 eulerAngles = transform.localEulerAngles;

            if (constraints.Contains(AxisConstraint.X)) {
                eulerAngles.x = matchedTransform.localEulerAngles.x;
            }

            if (constraints.Contains(AxisConstraint.Y)) {
                eulerAngles.y = matchedTransform.localEulerAngles.y;
            }

            if (constraints.Contains(AxisConstraint.Z)) {
                eulerAngles.z = matchedTransform.localEulerAngles.z;
            }

            transform.localEulerAngles = eulerAngles;
        }

    }

}
