using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// An animation timing range between a lower and upper bound.
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

        /// <summary>
        /// Creates a new timing range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the timing range.</param>
        /// <param name="max">The upper bound of the timing range.</param>
        public TimingRange(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Returns a random time within the min and max time.
        /// </summary>
        /// <returns>A random time within the min and max time.</returns>
        public float Random()
        {
            return UnityEngine.Random.Range(min, max);
        }

        /// <summary>
        /// Checks if a time is within the min and max time.
        /// </summary>
        /// <param name="time">The time to check.</param>
        /// <returns>True if the time is within the min and max time.</returns>
        public bool Includes(float time)
        {
            return time >= min && time <= max;
        }

    }

}
