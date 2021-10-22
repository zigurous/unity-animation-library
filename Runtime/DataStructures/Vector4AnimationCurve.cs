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
        public AnimationCurve x = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

        /// <summary>
        /// The collection of keyframes for the y-axis of a Vector4.
        /// </summary>
        [Tooltip("The collection of keyframes for the y-axis of a Vector4.")]
        public AnimationCurve y = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

        /// <summary>
        /// The collection of keyframes for the z-axis of a Vector4.
        /// </summary>
        [Tooltip("The collection of keyframes for the z-axis of a Vector4.")]
        public AnimationCurve z = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

        /// <summary>
        /// The collection of keyframes for the w-axis of a Vector4.
        /// </summary>
        [Tooltip("The collection of keyframes for the w-axis of a Vector4.")]
        public AnimationCurve w = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

        /// <inheritdoc/>
        public Vector4 Evaluate(float time)
        {
            return new Vector4(x.Evaluate(time), y.Evaluate(time), z.Evaluate(time), w.Evaluate(time));
        }

        /// <inheritdoc/>
        /// <param name="value">The value for the key (vertical axis in the curve graph).</param>
        public void AddKey(float time, Vector4 value)
        {
            x.AddKey(time, value.x);
            y.AddKey(time, value.y);
            z.AddKey(time, value.z);
            w.AddKey(time, value.w);
        }

        /// <inheritdoc/>
        public void RemoveKey(int index)
        {
            x.RemoveKey(index);
            y.RemoveKey(index);
            z.RemoveKey(index);
            w.RemoveKey(index);
        }

    }

}
