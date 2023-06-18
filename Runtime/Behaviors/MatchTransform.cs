using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Matches the transform values to another transform.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Match Transform")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/MatchTransform")]
    [DefaultExecutionOrder(100)]
    public sealed class MatchTransform : MonoBehaviour
    {
        /// <summary>
        /// The coordinate space the transform is updated in.
        /// </summary>
        [Tooltip("The coordinate space the transform is updated in.")]
        public Space space = Space.World;

        /// <summary>
        /// The transform properties to match.
        /// </summary>
        [Tooltip("The transform properties to match.")]
        public TransformConstraint constraints = (TransformConstraint)~0;

        /// <summary>
        /// The target transform to match.
        /// </summary>
        [Tooltip("The target transform to match.")]
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
            if (constraints.Contains(TransformConstraint.Position)) {
                transform.position = matchedTransform.position;
            }

            if (constraints.Contains(TransformConstraint.Rotation)) {
                transform.rotation = matchedTransform.rotation;
            }

            if (constraints.Contains(TransformConstraint.Scale)) {
                transform.localScale = matchedTransform.localScale;
            }
        }

        private void MatchLocalSpace()
        {
            if (constraints.Contains(TransformConstraint.Position)) {
                transform.localPosition = matchedTransform.localPosition;
            }

            if (constraints.Contains(TransformConstraint.Rotation)) {
                transform.localRotation = matchedTransform.localRotation;
            }

            if (constraints.Contains(TransformConstraint.Scale)) {
                transform.localScale = matchedTransform.localScale;
            }
        }

    }

}
