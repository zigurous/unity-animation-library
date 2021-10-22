using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Moves an object along a predefined path.
    /// </summary>
    [AddComponentMenu("Zigurous/Animation/Follow Path")]
    public sealed class FollowPath : MonoBehaviour
    {
        /// <summary>
        /// A type of looping behavior.
        /// </summary>
        public enum LoopType
        {
            /// <summary>
            /// Turns off looping.
            /// </summary>
            None,

            /// <summary>
            /// Restarts the object from the beginning of the path after it
            /// reaches the end. The object will jump to the position of the
            /// first node.
            /// </summary>
            Restart,

            /// <summary>
            /// After reaching the end of the path, the object will traverse
            /// back to the first node and continue with the next loop.
            /// </summary>
            Circular,

            /// <summary>
            /// The object traverses along the path forwards then backwards then
            /// forwards then backwards, etc.
            /// </summary>
            PingPong,
        }

        /// <summary>
        /// The transform comprising of all the child nodes in the path.
        /// </summary>
        [Tooltip("The transform comprising of all the child nodes in the path.")]
        public Transform path;

        /// <summary>
        /// The transform of the node that the object is currently moving from
        /// (Read only).
        /// </summary>
        public Transform nodeFrom { get; private set; }

        /// <summary>
        /// The transform of the node that the object is currently moving to
        /// (Read only).
        /// </summary>
        public Transform nodeTo { get; private set; }

        /// <summary>
        /// The index of the node that the object is currently moving to
        /// (Read only).
        /// </summary>
        public int currentIndex { get; private set; }

        /// <summary>
        /// How quickly the object moves between nodes. Small numbers make the
        /// object more responsive. Larger numbers make the object respond more
        /// slowly.
        /// </summary>
        [Tooltip("How quickly the object moves between nodes. Small numbers make the object more responsive. Larger numbers make the object respond more slowly.")]
        public float damping = 1f;

        /// <summary>
        /// The maximum speed the object can move between nodes.
        /// </summary>
        [Tooltip("The maximum speed the object can move between nodes.")]
        public float maxSpeed = Mathf.Infinity;

        /// <summary>
        /// Once the object is less than this distance to the current node, then
        /// it will advance to the next one.
        /// </summary>
        [Tooltip("Once the object is less than this distance to the current node, then it will advance to the next one.")]
        public float minProximity = 0.1f;

        /// <summary>
        /// The rate at which the object is moving.
        /// </summary>
        private Vector3 _velocity;

        /// <summary>
        /// The looping behavior, if desired.
        /// </summary>
        [Tooltip("The looping behavior, if desired.")]
        public LoopType looping;

        /// <summary>
        /// Moves the object between nodes in reverse.
        /// </summary>
        [Tooltip("Moves the object between nodes in reverse.")]
        public bool reversed;

        private void Start()
        {
            Restart();
        }

        /// <summary>
        /// Restarts the path at the first node.
        /// </summary>
        public void Restart()
        {
            currentIndex = 0;

            SetCurrentSegment();
        }

        private void Update()
        {
            if (nodeTo == null) {
                return;
            }

            transform.position = Vector3.SmoothDamp(
                current: transform.position,
                target: nodeTo.position,
                currentVelocity: ref _velocity,
                smoothTime: damping,
                maxSpeed: maxSpeed);

            Vector3 vector = transform.position - nodeTo.position;

            if (vector.sqrMagnitude < minProximity) {
                Next();
            }
        }

        private void Next()
        {
            if (path == null) {
                return;
            }

            if (reversed) {
                currentIndex--;
            } else {
                currentIndex++;
            }

            if (currentIndex >= path.childCount || currentIndex < 0)
            {
                Loop();
                SetCurrentSegment();

                if (looping == LoopType.Restart && nodeTo != null) {
                    transform.position = nodeTo.position;
                }
            }
            else
            {
                SetCurrentSegment();
            }
        }

        private void Loop()
        {
            int lastIndex = Mathf.Max(path.childCount - 1, 0);

            switch (looping)
            {
                case LoopType.None:
                    currentIndex = Mathf.Clamp(currentIndex, 0, lastIndex);
                    break;

                case LoopType.Restart:
                case LoopType.Circular:
                    currentIndex = reversed ? lastIndex : 0;
                    break;

                case LoopType.PingPong:
                    reversed = !reversed;
                    currentIndex = reversed ? lastIndex : 0;
                    break;
            }
        }

        private void SetCurrentSegment()
        {
            nodeFrom = nodeTo;

            if (currentIndex >= 0 && currentIndex < path.childCount) {
                nodeTo = path.GetChild(currentIndex);
            }
        }

    }

}
