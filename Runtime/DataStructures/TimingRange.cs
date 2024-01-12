using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// An animation timing range between a lower and upper bound.
    /// </summary>
    [System.Serializable]
    public struct TimingRange
    {
        [SerializeField]
        [Tooltip("The lower bound of the timing range.")]
        private float m_Min;

        /// <summary>
        /// The lower bound of the timing range.
        /// </summary>
        public float min
        {
            readonly get => m_Min;
            set => m_Min = value;
        }

        [SerializeField]
        [Tooltip("The upper bound of the timing range.")]
        private float m_Max;

        /// <summary>
        /// The upper bound of the timing range.
        /// </summary>
        public float max
        {
            readonly get => m_Max;
            set => m_Max = value;
        }

        /// <summary>
        /// Creates a new timing range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the timing range.</param>
        /// <param name="max">The upper bound of the timing range.</param>
        public TimingRange(float min, float max)
        {
            m_Min = min;
            m_Max = max;
        }

        /// <summary>
        /// Returns a random time within the min and max time.
        /// </summary>
        /// <returns>A random time within the min and max time.</returns>
        public readonly float Random()
        {
            return UnityEngine.Random.Range(min, max);
        }

        /// <summary>
        /// Checks if a time is within the min and max time.
        /// </summary>
        /// <param name="time">The time to check.</param>
        /// <returns>True if the time is within the min and max time.</returns>
        public readonly bool Includes(float time)
        {
            return time >= min && time <= max;
        }

    }

}
