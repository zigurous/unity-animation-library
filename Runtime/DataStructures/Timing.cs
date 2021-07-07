using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Represents the start and end time of an animation.
    /// </summary>
    [System.Serializable]
    public struct Timing
    {
        /// <summary>
        /// The start time of the animation.
        /// </summary>
        [Tooltip("The start time of the animation.")]
        public float start;

        /// <summary>
        /// The end time of the animation.
        /// </summary>
        [Tooltip("The end time of the animation.")]
        public float end;

        /// <summary>Constructs a new timing with the given <paramref name="start"/> and <paramref name="end"/>.</summary>
        /// <param name="start">The start time of the animation.</param>
        /// <param name="end">The end time of the animation.</param>
        public Timing(float start, float end)
        {
            this.start = start;
            this.end = end;
        }

        /// <returns>
        /// A random time within the start and end time.
        /// </returns>
        public float Random()
        {
            return UnityEngine.Random.Range(this.start, this.end);
        }

        /// <returns>Whether the given <paramref name="time"/> is within the start and end time.</returns>
        /// <param name="time">The time to check.</param>
        public bool Includes(float time)
        {
            return time >= this.start && time <= this.end;
        }

    }

}
