using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Stores a collection of keyframes that can be evaluated over time as a
    /// Vector2.
    /// </summary>
    [System.Serializable]
    public sealed class Vector2AnimationCurve : IAnimationCurve<Vector2>
    {
        /// <summary>
        /// The collection of keyframes for the x-axis of a Vector2.
        /// </summary>
        [Tooltip("The collection of keyframes for the x-axis of a Vector2.")]
        public AnimationCurve x = new(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

        /// <summary>
        /// The collection of keyframes for the y-axis of a Vector2.
        /// </summary>
        [Tooltip("The collection of keyframes for the y-axis of a Vector2.")]
        public AnimationCurve y = new(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

        /// <inheritdoc/>
        public Vector2 Evaluate(float time)
        {
            return new Vector2(x.Evaluate(time), y.Evaluate(time));
        }

        /// <inheritdoc/>
        /// <param name="value">The value for the key (vertical axis in the curve graph).</param>
        public void AddKey(float time, Vector2 value)
        {
            x.AddKey(time, value.x);
            y.AddKey(time, value.y);
        }

        /// <inheritdoc/>
        public void RemoveKey(int index)
        {
            x.RemoveKey(index);
            y.RemoveKey(index);
        }

    }

}
