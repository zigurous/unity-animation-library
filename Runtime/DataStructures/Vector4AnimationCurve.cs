using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Stores a collection of keyframes that can be evaluated over time as a
    /// Vector4.
    /// </summary>
    [System.Serializable]
    public sealed class Vector4AnimationCurve : IAnimationCurve<Vector4>
    {
        /// <summary>
        /// The collection of keyframes for the x-axis of a Vector4.
        /// </summary>
        [Tooltip("The collection of keyframes for the x-axis of a Vector4.")]
        public AnimationCurve x = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));

        /// <summary>
        /// The collection of keyframes for the y-axis of a Vector4.
        /// </summary>
        [Tooltip("The collection of keyframes for the y-axis of a Vector4.")]
        public AnimationCurve y = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));

        /// <summary>
        /// The collection of keyframes for the z-axis of a Vector4.
        /// </summary>
        [Tooltip("The collection of keyframes for the z-axis of a Vector4.")]
        public AnimationCurve z = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));

        /// <summary>
        /// The collection of keyframes for the w-axis of a Vector4.
        /// </summary>
        [Tooltip("The collection of keyframes for the w-axis of a Vector4.")]
        public AnimationCurve w = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));

        /// <inheritdoc/>
        public Vector4 Evaluate(float time)
        {
            return new Vector4(
                this.x.Evaluate(time),
                this.y.Evaluate(time),
                this.z.Evaluate(time),
                this.w.Evaluate(time));
        }

        /// <inheritdoc/>
        /// <param name="value">The value for the key (vertical axis in the curve graph).</param>
        public void AddKey(float time, Vector4 value)
        {
            this.x.AddKey(time, value.x);
            this.y.AddKey(time, value.y);
            this.z.AddKey(time, value.z);
            this.w.AddKey(time, value.w);
        }

        /// <inheritdoc/>
        public void RemoveKey(int index)
        {
            this.x.RemoveKey(index);
            this.y.RemoveKey(index);
            this.z.RemoveKey(index);
            this.w.RemoveKey(index);
        }

    }

}
