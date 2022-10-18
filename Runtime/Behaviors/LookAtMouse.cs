﻿using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Zigurous.Animation
{
    /// <summary>
    /// Rotates the transform to look at the mouse.
    /// </summary>
    public sealed class LookAtMouse : MonoBehaviour
    {
        /// <summary>
        /// The camera used to convert positions from world space to screen space.
        /// </summary>
        [Tooltip("The camera used to convert positions from world space to screen space.")]
        public Camera screenCamera;

        private void Reset()
        {
            if (screenCamera == null) {
                screenCamera = Camera.main;
            }
        }

        private void Start()
        {
            if (screenCamera == null) {
                screenCamera = Camera.main;
            }
        }

        private void Update()
        {
            if (screenCamera == null) {
                return;
            }

            Vector3 screenPoint = screenCamera.WorldToScreenPoint(transform.position);
            Vector3 mousePosition = Vector3.zero;

            #if ENABLE_INPUT_SYSTEM
            mousePosition = Mouse.current.position.ReadValue();
            #elif ENABLE_LEGACY_INPUT_MANAGER
            mousePosition = Input.mousePosition;
            #endif

            Vector3 lookDirection = mousePosition - screenPoint;
            transform.rotation = lookDirection != Vector3.zero ?
                Quaternion.LookRotation(lookDirection) :
                Quaternion.identity;
        }

    }

}
