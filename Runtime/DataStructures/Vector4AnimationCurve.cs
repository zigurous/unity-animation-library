using UnityEngine;

namespace Zigurous.Animation
{
    [System.Serializable]
    public sealed class Vector4AnimationCurve
    {
        public AnimationCurve x = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));
        public AnimationCurve y = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));
        public AnimationCurve z = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));
        public AnimationCurve w = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));

        public Vector4 Evaluate(float time)
        {
            return new Vector4(this.x.Evaluate(time), this.y.Evaluate(time), this.z.Evaluate(time), this.w.Evaluate(time));
        }

    }

}
