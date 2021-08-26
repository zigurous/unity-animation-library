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
        /// The object follows the path comprised of all the children of this
        /// transform.
        /// </summary>
        [Tooltip("The object follows the path comprised of all the children of this transform.")]
        public Transform path;

        /// <summary>
        /// The transform of the node that the object is currently moving from.
        /// </summary>
        public Transform nodeFrom { get; private set; }

        /// <summary>
        /// The transform of the node that the object is currently moving to.
        /// </summary>
        public Transform nodeTo { get; private set; }

        /// <summary>
        /// The index of the node that the object is currently moving to.
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
            this.currentIndex = 0;

            SetCurrentSegment();
        }

        private void Update()
        {
            if (this.nodeTo == null) {
                return;
            }

            this.transform.position = Vector3.SmoothDamp(
                current: this.transform.position,
                target: this.nodeTo.position,
                currentVelocity: ref _velocity,
                smoothTime: this.damping,
                maxSpeed: this.maxSpeed);

            Vector3 vector = this.transform.position - this.nodeTo.position;

            if (vector.sqrMagnitude < this.minProximity) {
                Next();
            }
        }

        private void Next()
        {
            if (this.path == null) {
                return;
            }

            if (this.reversed) {
                this.currentIndex--;
            } else {
                this.currentIndex++;
            }

            if (this.currentIndex >= this.path.childCount || this.currentIndex < 0)
            {
                Loop();
                SetCurrentSegment();

                if (this.looping == LoopType.Restart && this.nodeTo != null) {
                    this.transform.position = this.nodeTo.position;
                }
            }
            else
            {
                SetCurrentSegment();
            }
        }

        private void Loop()
        {
            int lastIndex = Mathf.Max(this.path.childCount - 1, 0);

            switch (this.looping)
            {
                case LoopType.None:
                    this.currentIndex = Mathf.Clamp(this.currentIndex, 0, lastIndex);
                    break;

                case LoopType.Restart:
                case LoopType.Circular:
                    this.currentIndex = this.reversed ? lastIndex : 0;
                    break;

                case LoopType.PingPong:
                    this.reversed = !this.reversed;
                    this.currentIndex = this.reversed ? lastIndex : 0;
                    break;
            }
        }

        private void SetCurrentSegment()
        {
            this.nodeFrom = this.nodeTo;

            if (this.currentIndex >= 0 && this.currentIndex < this.path.childCount) {
                this.nodeTo = this.path.GetChild(this.currentIndex);
            }
        }

    }

}
