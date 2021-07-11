using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// The start and end time of an animation.
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

        /// <summary>Creates a new timing with the specified values.</summary>
        /// <param name="start">The start time of the animation.</param>
        /// <param name="end">The end time of the animation.</param>
        public Timing(float start, float end)
        {
            this.start = start;
            this.end = end;
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
