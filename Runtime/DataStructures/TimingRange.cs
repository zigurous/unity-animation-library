using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Represents an animation timing range between a lower and upper bound.
    /// </summary>
    [System.Serializable]
    public struct TimingRange
    {
        /// <summary>
        /// The lower bound of the timing range.
        /// </summary>
        [Tooltip("The lower bound of the timing range.")]
        public float min;

        /// <summary>
        /// The upper bound of the timing range.
        /// </summary>
        [Tooltip("The upper bound of the timing range.")]
        public float max;

        /// <summary>Constructs a new timing range with the given <paramref name="min"/> and <paramref name="max"/>.</summary>
        /// <param name="min">The lower bound of the timing range.</param>
        /// <param name="max">The upper bound of the timing range.</param>
        public TimingRange(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        /// <returns>
        /// A random time within the min and max time.
        /// </returns>
        public float Random()
        {
            return UnityEngine.Random.Range(this.min, this.max);
        }

        /// <returns>Whether the given <paramref name="time"/> is within the min and max time.</returns>
        /// <param name="time">The time to check.</param>
        public bool Includes(float time)
        {
            return time >= this.min && time <= this.max;
        }

    }

}
