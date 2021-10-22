using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// An animation timing range normalized between 0 and 1.
    /// </summary>
    [System.Serializable]
    public struct TimingRange01
    {
        [SerializeField]
        [Tooltip("The lower bound of the timing range, between 0 and 1.")]
        [Range(0f, 1f)]
        private float _min;

        /// <summary>
        /// The lower bound of the timing range, between 0 and 1.
        /// </summary>
        public float min
        {
            get => _min;
            set => _min = Mathf.Clamp01(value);
        }

        [SerializeField]
        [Tooltip("The upper bound of the timing range, between 0 and 1.")]
        [Range(0f, 1f)]
        private float _max;

        /// <summary>
        /// The upper bound of the timing range, between 0 and 1.
        /// </summary>
        public float max
        {
            get => _max;
            set => _max = Mathf.Clamp01(value);
        }

        /// <summary>
        /// Creates a new timing range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the timing range, between 0 and 1.</param>
        /// <param name="max">The upper bound of the timing range, between 0 and 1.</param>
        public TimingRange01(float min, float max)
        {
            _min = Mathf.Clamp01(min);
            _max = Mathf.Clamp01(max);
        }

        /// <summary>
        /// Returns a random time within the min and max time.
        /// </summary>
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
