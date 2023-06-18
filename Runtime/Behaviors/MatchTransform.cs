using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Matches the transform values to another.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Match Transform")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/MatchTransform")]
    [DefaultExecutionOrder(100)]
    public sealed class MatchTransform : MonoBehaviour
    {
        /// <summary>
        /// The transform properties to match.
        /// </summary>
        public TransformConstraint constraints = (TransformConstraint)~0;

        /// <summary>
        /// The target transform to match.
        /// </summary>
        public Transform matchedTransform;

        private void LateUpdate()
        {
            if (matchedTransform == null) {
                return;
            }

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

    }

}
