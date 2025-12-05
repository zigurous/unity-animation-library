using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Bakes the mesh of a skinned mesh renderer.
    /// </summary>
    [DefaultExecutionOrder(1)]
    [AddComponentMenu("Zigurous/Animation/Skinned Mesh Baker")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/SkinnedMeshBaker")]
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public sealed class SkinnedMeshBaker : MonoBehaviour
    {
        /// <summary>
        /// The skinned mesh renderer being baked.
        /// </summary>
        public SkinnedMeshRenderer skinnedMeshRenderer { get; private set; }

        /// <summary>
        /// The baked mesh.
        /// </summary>
        public Mesh bakedMesh { get; private set; }

        /// <summary>
        /// The bounds of the baked mesh.
        /// </summary>
        public Bounds bounds { get; private set; }

        /// <summary>
        /// Bakes the mesh every single frame. Note: performance costly.
        /// </summary>
        [Tooltip("Bakes the mesh every single frame. Note: performance costly.")]
        public bool updateEveryFrame;

        private void Awake()
        {
            skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
            bakedMesh = new Mesh();
        }

        private void OnEnable()
        {
            Bake();
        }

        private void LateUpdate()
        {
            if (updateEveryFrame) {
                Bake();
            }
        }

        /// <summary>
        /// Bakes the mesh in its current state and recalculates the bounds.
        /// </summary>
        public void Bake()
        {
            skinnedMeshRenderer.BakeMesh(bakedMesh);
            bakedMesh.RecalculateBounds();
            bounds = bakedMesh.bounds;
        }

    }

}
