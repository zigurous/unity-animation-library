#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.InputSystem;

namespace Zigurous.Animation
{
    /// <summary>
    /// Previews animations on a blend shape animator.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Blend Shape Animator Preview Controller")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/BlendShapeAnimatorPreviewController")]
    [RequireComponent(typeof(BlendShapeAnimator))]
    public sealed class BlendShapeAnimatorPreviewController : MonoBehaviour
    {
        /// <summary>
        /// The animation to preview.
        /// </summary>
        [Tooltip("The animation to preview.")]
        public AnimationId previewAnimation;

        /// <summary>
        /// Plays the animation upon input activation (optional).
        /// </summary>
        [Tooltip("Plays the animation upon input activation (optional).")]
        public InputActionReference input;

        private void OnValidate()
        {
            if (Application.isPlaying && enabled && input == null && TryGetComponent(out BlendShapeAnimator animator)) {
                animator.PlayAnimation(previewAnimation);
            }
        }

        private void OnEnable()
        {
            if (input != null)
            {
                input.action.performed += OnInputPerformed;
                input.action.Enable();
            }
            else if (TryGetComponent(out BlendShapeAnimator animator))
            {
                animator.PlayAnimation(previewAnimation);
            }
        }

        private void OnDisable()
        {
            if (input != null)
            {
                input.action.performed -= OnInputPerformed;
                input.action.Disable();
            }
        }

        private void OnInputPerformed(InputAction.CallbackContext context)
        {
            if (TryGetComponent(out BlendShapeAnimator animator)) {
                animator.PlayAnimation(previewAnimation);
            }
        }

    }

}
#endif
