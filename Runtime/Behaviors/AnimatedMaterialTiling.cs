using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Animates the tiling property of a renderer's material.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Animated Material Tiling")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/AnimatedMaterialTiling")]
    public class AnimatedMaterialTiling : UpdateBehaviour
    {
        /// <summary>
        /// The renderer to animate.
        /// </summary>
        [Tooltip("The renderer to animate.")]
        public new Renderer renderer;

        /// <summary>
        /// The tiling animation speed.
        /// </summary>
        [Tooltip("The tiling animation speed.")]
        public float animationSpeed = 1f;

        /// <summary>
        /// The tiling axis to animate on.
        /// </summary>
        [Tooltip("The tiling axis to animate on.")]
        public Vector2 axis = Vector2.right;

        /// <summary>
        /// A Unity lifecycle method called when the behaviour is reset in the editor.
        /// </summary>
        protected virtual void Reset()
        {
            renderer = GetComponent<MeshRenderer>();
        }

        /// <inheritdoc/>
        protected override void OnUpdate(float deltaTime)
        {
            if (renderer != null) {
                renderer.material.mainTextureOffset += axis * animationSpeed * Time.deltaTime;
            }
        }

    }

}
