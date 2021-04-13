using UnityEngine;

namespace Zigurous.Animation
{
    [System.Serializable]
    public sealed class Vector2AnimationCurve
    {
        public AnimationCurve x = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));
        public AnimationCurve y = new AnimationCurve(new Keyframe(0.0f, 0.0f), new Keyframe(1.0f, 0.0f));

        ~Vector2AnimationCurve()
        {
            this.x = null;
            this.y = null;
        }

        public Vector2 Evaluate(float time) => new Vector2(
            this.x.Evaluate(time),
            this.y.Evaluate(time));

    }

}
