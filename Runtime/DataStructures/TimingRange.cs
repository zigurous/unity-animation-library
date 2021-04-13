namespace Zigurous.Animation
{
    [System.Serializable]
    public struct TimingRange
    {
        public float min;
        public float max;

        public TimingRange(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        public float Random()
        {
            return UnityEngine.Random.Range(this.min, this.max);
        }

    }

}
