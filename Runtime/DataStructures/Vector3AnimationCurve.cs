﻿using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Stores a collection of keyframes that can be evaluated over time as a
    /// Vector3.
    /// </summary>
    [System.Serializable]
    public sealed class Vector3AnimationCurve : IAnimationCurve<Vector3>
    {
        /// <summary>
        /// The collection of keyframes for the x-axis of a Vector3.
        /// </summary>
        [Tooltip("The collection of keyframes for the x-axis of a Vector3.")]
        public AnimationCurve x = new(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

        /// <summary>
        /// The collection of keyframes for the y-axis of a Vector3.
        /// </summary>
        [Tooltip("The collection of keyframes for the y-axis of a Vector3.")]
        public AnimationCurve y = new(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

        /// <summary>
        /// The collection of keyframes for the z-axis of a Vector3.
        /// </summary>
        [Tooltip("The collection of keyframes for the z-axis of a Vector3.")]
        public AnimationCurve z = new(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

        /// <inheritdoc/>
        public Vector3 Evaluate(float time)
        {
            return new Vector3(x.Evaluate(time), y.Evaluate(time), z.Evaluate(time));
        }

        /// <inheritdoc/>
        /// <param name="value">The value for the key (vertical axis in the curve graph).</param>
        public void AddKey(float time, Vector3 value)
        {
            x.AddKey(time, value.x);
            y.AddKey(time, value.y);
            z.AddKey(time, value.z);
        }

        /// <inheritdoc/>
        public void RemoveKey(int index)
        {
            x.RemoveKey(index);
            y.RemoveKey(index);
            z.RemoveKey(index);
        }

    }

}
