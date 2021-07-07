using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Represents an animation timing range between a lower and upper bound
    /// normalized between 0 and 1.
    /// </summary>
    [System.Serializable]
    public struct TimingRange01
    {
        [SerializeField]
        [Tooltip("The lower bound of the timing range, between 0 and 1.")]
        [Range(0.0f, 1.0f)]
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
        [Range(0.0f, 1.0f)]
        private float _max;

        /// <summary>
        /// The upper bound of the timing range, between 0 and 1.
        /// </summary>
        public float max
        {
            get => _max;
            set => _max = Mathf.Clamp01(value);
        }

        /// <summary>Constructs a new timing range with the given <paramref name="min"/> and <paramref name="max"/>.</summary>
        /// <param name="min">The lower bound of the timing range, between 0 and 1.</param>
        /// <param name="max">The upper bound of the timing range, between 0 and 1.</param>
        public TimingRange01(float min, float max)
        {
            _min = Mathf.Clamp01(min);
            _max = Mathf.Clamp01(max);
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
