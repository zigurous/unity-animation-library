using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// The start and end time of an animation normalized between 0 and 1.
    /// </summary>
    [System.Serializable]
    public struct Timing01
    {
        [SerializeField]
        [Tooltip("The start time of the animation, between 0 and 1.")]
        [Range(0.0f, 1.0f)]
        private float _start;

        /// <summary>
        /// The start time of the animation, between 0 and 1.
        /// </summary>
        public float start
        {
            get => _start;
            set => _start = Mathf.Clamp01(value);
        }

        [SerializeField]
        [Tooltip("The end time of the animation, between 0 and 1.")]
        [Range(0.0f, 1.0f)]
        private float _end;

        /// <summary>
        /// The end time of the animation, between 0 and 1.
        /// </summary>
        public float end
        {
            get => _end;
            set => _end = Mathf.Clamp01(value);
        }

        /// <summary>Creates a new timing with the specified values.</summary>
        /// <param name="start">The start time of the animation, between 0 and 1.</param>
        /// <param name="end">The end time of the animation, between 0 and 1.</param>
        public Timing01(float start, float end)
        {
            _start = Mathf.Clamp01(start);
            _end = Mathf.Clamp01(end);
        }

        /// <summary>Picks a random time within the start and end time.</summary>
        /// <returns>The random time.</returns>
        public float Random()
        {
            return UnityEngine.Random.Range(this.start, this.end);
        }

        /// <summary>Checks if <paramref name="time"/> is within the start and end time.</summary>
        /// <param name="time">The time to check.</param>
        /// <returns>True if <paramref name="time"/> is within the start and end time.</returns>
        public bool Includes(float time)
        {
            return time >= this.start && time <= this.end;
        }

    }

}
