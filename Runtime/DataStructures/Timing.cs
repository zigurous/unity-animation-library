using UnityEngine;

namespace Zigurous.Animation
{
    [System.Serializable]
    public struct Timing
    {
        [Range(0.0f, 1.0f)]
        public float startTime;

        [Range(0.0f, 1.0f)]
        public float endTime;

        public Timing(float startTime, float endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public bool Includes(float time)
        {
            return time >= this.startTime && time <= this.endTime;
        }

    }

}
