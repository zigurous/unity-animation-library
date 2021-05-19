using UnityEngine;

namespace Zigurous.Animation
{
    [System.Serializable]
    public sealed class Vector3AnimationCurve
    {
        public AnimationCurve x = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));
        public AnimationCurve y = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));
        public AnimationCurve z = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));

        public Vector3 Evaluate(float time)
        {
            return new Vector3(this.x.Evaluate(time), this.y.Evaluate(time), this.z.Evaluate(time));
        }

    }

}
