using System.Collections.Generic;
using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Tracks the position of a vertex on a skinned mesh renderer.
    /// </summary>
    [DefaultExecutionOrder(3)]
    [AddComponentMenu("Zigurous/Animation/Skinned Mesh Vertex Tracker")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/SkinnedMeshVertexTracker")]
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public sealed class SkinnedMeshVertexTracker : MonoBehaviour
    {
        private RecalculateSkinnedBounds baker;
        private List<Vector3> vertices;

        /// <summary>
        /// The index of the vertex to track.
        /// </summary>
        [Tooltip("The index of the vertex to track.")]
        public int index = 0;

        /// <summary>
        /// The transform that tracks to the vertex position (optional).
        /// </summary>
        [Tooltip("The transform that tracks to the vertex position (optional).")]
        public Transform trackingTransform;

        /// <summary>
        /// The world space position of the tracked vertex.
        /// </summary>
        public Vector3 vertexPosition { get; private set; }

        private void Awake()
        {
            if (!TryGetComponent(out baker)) {
                baker = gameObject.AddComponent<RecalculateSkinnedBounds>();
            }

            baker.updateEveryFrame = true;
        }

        private void OnEnable()
        {
            Recalculate();
        }

        private void LateUpdate()
        {
            Recalculate();
        }

        /// <summary>
        /// Recalculates the vertex position with the current state of the
        /// skinned mesh renderer.
        /// </summary>
        public void Recalculate()
        {
            vertices ??= new List<Vector3>(baker.bakedMesh.vertexCount);
            baker.bakedMesh.GetVertices(vertices);

            Vector3 vertex = vertices[Mathf.Clamp(index, 0, vertices.Count - 1)];
            vertexPosition = transform.TransformPoint(vertex);

            if (trackingTransform != null) {
                trackingTransform.position = vertexPosition;
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (Application.isPlaying && enabled && vertices != null)
            {
                Vector3 vertex = vertices[Mathf.Clamp(index, 0, vertices.Count - 1)];
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(transform.TransformPoint(vertex), 0.1f);
            }
        }

    }

}
