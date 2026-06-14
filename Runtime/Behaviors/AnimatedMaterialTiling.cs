using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Animates the texture offset of a material over time.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Animated Texture Offset")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/AnimatedTextureOffset")]
    [RequireComponent(typeof(Renderer))]
    public sealed class AnimatedTextureOffset : MonoBehaviour
    {
        /// <summary>
        /// The direction to offset the texture coordinates.
        /// </summary>
        [Tooltip("The direction to offset the texture coordinates.")]
        public Vector2 direction = Vector2.right;

        /// <summary>
        /// The speed at which to offset the texture coordinates.
        /// </summary>
        [Tooltip("The speed at which to offset the texture coordinates.")]
        public float speed = 1f;

        /// <summary>
        /// Uses unscaled time when animating the texture offset.
        /// </summary>
        [Tooltip("Uses unscaled time when animating the texture offset.")]
        public bool unscaledTime = false;

        private Material material;

        private void Start()
        {
            material = GetComponent<MeshRenderer>().material;
        }

        private void Update()
        {
            if (unscaledTime) {
                material.mainTextureOffset += speed * Time.unscaledDeltaTime * direction;
            } else {
                material.mainTextureOffset += speed * Time.deltaTime * direction;
            }
        }

    }

}
