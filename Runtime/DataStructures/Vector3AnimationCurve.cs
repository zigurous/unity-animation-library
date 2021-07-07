using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Stores a collection of keyframes that can be evaluated over time as a
    /// Vector3.
    /// </summary>
    [System.Serializable]
    public sealed class Vector3AnimationCurve : IAnimationCurve<Vector3>
    {
        /// <summary>The collection of keyframes for the x-axis of a Vector3.</summary>
        /// <value>Stores a collection of keyframes that can be evaluated over time.</value>
        [Tooltip("The collection of keyframes for the x-axis of a Vector3.")]
        public AnimationCurve x = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));

        /// <summary>The collection of keyframes for the y-axis of a Vector3.</summary>
        /// <value>Stores a collection of keyframes that can be evaluated over time.</value>
        [Tooltip("The collection of keyframes for the y-axis of a Vector3.")]
        public AnimationCurve y = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));

        /// <summary>The collection of keyframes for the z-axis of a Vector3.</summary>
        /// <value>Stores a collection of keyframes that can be evaluated over time.</value>
        [Tooltip("The collection of keyframes for the z-axis of a Vector3.")]
        public AnimationCurve z = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));

        /// <inheritdoc/>
        public Vector3 Evaluate(float time)
        {
            return new Vector3(
                this.x.Evaluate(time),
                this.y.Evaluate(time),
                this.z.Evaluate(time));
        }

        /// <inheritdoc/>
        /// <param name="value">The value for the key (vertical axis in the curve graph).</param>
        public void AddKey(float time, Vector3 value)
        {
            this.x.AddKey(time, value.x);
            this.y.AddKey(time, value.y);
            this.z.AddKey(time, value.z);
        }

        /// <inheritdoc/>
        public void RemoveKey(int index)
        {
            this.x.RemoveKey(index);
            this.y.RemoveKey(index);
            this.z.RemoveKey(index);
        }

    }

}
