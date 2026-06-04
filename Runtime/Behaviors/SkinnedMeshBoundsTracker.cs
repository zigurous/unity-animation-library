using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Tracks the bounds of a skinned mesh renderer.
    /// </summary>
    [DefaultExecutionOrder(2)]
    [AddComponentMenu("Zigurous/Animation/Skinned Mesh Bounds Tracker")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.animation/api/Zigurous.Animation/SkinnedMeshBoundsTracker")]
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public sealed class SkinnedMeshBoundsTracker : MonoBehaviour
    {
        private RecalculateSkinnedBounds baker;

        /// <summary>
        /// The transform that tracks the center of the mesh (optional).
        /// </summary>
        [Tooltip("The transform that tracks the center of the mesh (optional).")]
        public Transform centerTracker;

        /// <summary>
        /// The transform that tracks the top of the mesh (optional).
        /// </summary>
        [Tooltip("he transform that tracks the top of the mesh (optional).")]
        public Transform topTracker;

        /// <summary>
        /// The transform that tracks the bottom of the mesh (optional).
        /// </summary>
        [Tooltip("The transform that tracks the bottom of the mesh (optional).")]
        public Transform bottomTracker;

        /// <summary>
        /// Ignores the scale of the object when calculating the bounds.
        /// </summary>
        [Tooltip("Ignores the scale of the object when calculating the bounds.")]
        public bool unscaled;

        /// <summary>
        /// Updates the mesh bounds every frame. Note: performance costly.
        /// </summary>
        [Tooltip("Updates the mesh bounds every frame. Note: performance costly.")]
        public bool updateEveryFrame;

        private void Awake()
        {
            if (!TryGetComponent(out baker)) {
                baker = gameObject.AddComponent<RecalculateSkinnedBounds>();
            }

            baker.updateEveryFrame |= updateEveryFrame;
        }

        private void OnValidate()
        {
            if (Application.isPlaying && baker != null) {
                baker.updateEveryFrame = updateEveryFrame;
            }
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
        /// Recalculates the tracker positions with the current state of the
        /// skinned mesh renderer.
        /// </summary>
        public void Recalculate()
        {
            if (unscaled) {
                TrackUnscaledPositions(baker.bounds);
            } else {
                TrackScaledPositions(baker.bounds);
            }
        }

        private void TrackScaledPositions(Bounds bounds)
        {
            if (centerTracker != null) {
                centerTracker.position = transform.TransformPoint(bounds.center);
            }

            if (topTracker != null) {
                topTracker.position = transform.TransformPoint(bounds.center + (Vector3.up * bounds.extents.y));
            }

            if (bottomTracker != null) {
                bottomTracker.position = transform.TransformPoint(bounds.center + (Vector3.down * bounds.extents.y));
            }
        }

        private void TrackUnscaledPositions(Bounds bounds)
        {
            if (centerTracker != null) {
                centerTracker.position = transform.position + bounds.center;
            }

            if (topTracker != null) {
                topTracker.position = transform.position + bounds.center + (Vector3.up * bounds.extents.y);
            }

            if (bottomTracker != null) {
                bottomTracker.position = transform.position + bounds.center + (Vector3.down * bounds.extents.y);
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (Application.isPlaying && enabled && baker != null)
            {
                Vector3 center;

                if (unscaled) {
                    center = transform.position + baker.bounds.center;
                } else {
                    center = transform.TransformPoint(baker.bounds.center);
                }

                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(center, Vector3.Scale(baker.bounds.size, transform.lossyScale));
            }
        }

    }

}
