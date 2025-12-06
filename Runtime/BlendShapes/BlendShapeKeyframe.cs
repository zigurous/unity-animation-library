namespace Zigurous.Animation
{
    /// <summary>
    /// Keyframe data for a blend shape animation.
    /// </summary>
    public sealed class BlendShapeKeyframe
    {
        /// <summary>
        /// The index of the blend shape modified by the keyframe.
        /// </summary>
        public int index;

        /// <summary>
        /// The frame number within the animation.
        /// </summary>
        public int frame;

        /// <summary>
        /// The length of the keyframe in subframes.
        /// </summary>
        public int length;

        /// <summary>
        /// The current blend shape weight of the keyframe.
        /// </summary>
        public float weight;

        /// <summary>
        /// The target blend shape weight of the keyframe.
        /// </summary>
        public float targetWeight;

        /// <summary>
        /// The duration of the keyframe in seconds.
        /// </summary>
        public float duration => BlendShapeAnimation.FrameDuration * length;

        /// <summary>
        /// Creates a new blend shape keyframe for the given index.
        /// </summary>
        /// <param name="index">The index of the keyframe.</param>
        public BlendShapeKeyframe(int index)
        {
            this.index = index;
        }

    }

}
