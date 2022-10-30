using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Zigurous.Animation
{
    /// <summary>
    /// Rotates the transform based on user input.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Input Rotation")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/InputRotation")]
    public sealed class InputRotation : MonoBehaviour
    {
        #if ENABLE_INPUT_SYSTEM
        /// <summary>
        /// The input action that rotates the transform.
        /// </summary>
        [Tooltip("The input action that rotates the transform.")]
        public InputAction rotateInput = new InputAction("Rotate", InputActionType.Value, "<Mouse>/delta/x", null, "scale(factor=0.05)");
        #elif ENABLE_LEGACY_INPUT_MANAGER
        /// <summary>
        /// The input axis that rotates the transform.
        /// </summary>
        [Tooltip("The input axis that rotates the transform.")]
        public string inputAxis = "Mouse X";
        #endif

        /// <summary>
        /// The axis the object rotates around.
        /// </summary>
        [Tooltip("The axis the object rotates around.")]
        public Vector3 axis = Vector3.down;

        /// <summary>
        /// The speed at which the transform rotates.
        /// </summary>
        [Tooltip("The speed at which the transform rotates.")]
        public float speed = 50f;

        /// <summary>
        /// The coordinate space to rotate the transform in.
        /// </summary>
        [Tooltip("The coordinate space to rotate the transform in.")]
        public Space space = Space.Self;

        #if ENABLE_INPUT_SYSTEM
        private void OnDestroy()
        {
            rotateInput.Dispose();
        }

        private void OnEnable()
        {
            rotateInput.Enable();
        }

        private void OnDisable()
        {
            rotateInput.Disable();
        }
        #endif

        private void Update()
        {
            float input = 0f;

            #if ENABLE_INPUT_SYSTEM
            input = rotateInput.ReadValue<float>();
            #elif ENABLE_LEGACY_INPUT_MANAGER
            try
            {
                if (!string.IsNullOrEmpty(inputAxis)) {
                    input = Input.GetAxis(inputAxis);
                }
            }
            catch
            {
                #if UNITY_EDITOR || DEVELOPMENT_BUILD
                Debug.LogWarning($"[InputRotation] Input axis '{inputAxis}' is not setup.\nDefine the input in the Input Manager settings accessed from the menu: Edit > Project Settings");
                #endif
            }
            #endif

            transform.Rotate(axis.normalized * speed * input * Time.deltaTime, space);
        }

    }

}
