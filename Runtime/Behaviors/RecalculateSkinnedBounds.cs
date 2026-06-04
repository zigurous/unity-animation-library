using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Recalculates the bounds of a skinned mesh renderer.
    /// </summary>
    [DefaultExecutionOrder(1)]
    [AddComponentMenu("Zigurous/Animation/Recalculate Skinned Bounds")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/RecalculateSkinnedBounds")]
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public sealed class RecalculateSkinnedBounds : MonoBehaviour
    {
        /// <summary>
        /// The skinned mesh renderer being baked.
        /// </summary>
        public SkinnedMeshRenderer skinnedRenderer { get; private set; }

        /// <summary>
        /// The baked mesh.
        /// </summary>
        public Mesh bakedMesh { get; private set; }

        /// <summary>
        /// The bounds of the baked mesh.
        /// </summary>
        public Bounds bounds => skinnedRenderer.localBounds;

        /// <summary>
        /// Bakes the mesh every single frame. Note: performance costly.
        /// </summary>
        [Tooltip("Bakes the mesh every single frame. Note: performance costly.")]
        public bool updateEveryFrame;

        private void Awake()
        {
            skinnedRenderer = GetComponent<SkinnedMeshRenderer>();
            bakedMesh = new Mesh();
        }

        private void OnEnable()
        {
            Recalculate();
        }

        private void LateUpdate()
        {
            if (updateEveryFrame) {
                Recalculate();
            }
        }

        /// <summary>
        /// Bakes the mesh in its current state and recalculates the bounds.
        /// </summary>
        public void Recalculate()
        {
            skinnedRenderer.BakeMesh(bakedMesh);
            bakedMesh.RecalculateBounds();
            skinnedRenderer.localBounds = bakedMesh.bounds;
        }

    }

}
