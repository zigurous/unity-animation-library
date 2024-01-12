using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// The start and end time of an animation.
    /// </summary>
    [System.Serializable]
    public struct Timing
    {
        [SerializeField]
        [Tooltip("The start time of the animation.")]
        private float m_Start;

        /// <summary>
        /// The start time of the animation.
        /// </summary>
        public float start
        {
            readonly get => m_Start;
            set => m_Start = value;
        }

        [SerializeField]
        [Tooltip("The end time of the animation.")]
        private float m_End;

        /// <summary>
        /// The end time of the animation.
        /// </summary>
        public float end
        {
            readonly get => m_End;
            set => m_End = value;
        }

        /// <summary>
        /// Creates a new timing with the specified values.
        /// </summary>
        /// <param name="start">The start time of the animation.</param>
        /// <param name="end">The end time of the animation.</param>
        public Timing(float start, float end)
        {
            m_Start = start;
            m_End = end;
        }

        /// <summary>
        /// Returns a random time within the start and end time.
        /// </summary>
        /// <returns>A random time within the start and end time.</returns>
        public readonly float Random()
        {
            return UnityEngine.Random.Range(start, end);
        }

        /// <summary>
        /// Checks if a time is within the start and end time.
        /// </summary>
        /// <param name="time">The time to check.</param>
        /// <returns>True if the time is within the start and end time.</returns>
        public readonly bool Includes(float time)
        {
            return time >= start && time <= end;
        }

    }

}
