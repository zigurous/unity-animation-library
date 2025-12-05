using System.Collections.Generic;
using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// Timing functions for every ease type. Easing functions specify the rate
    /// of change of a parameter over time.
    /// </summary>
    public static class EaseFunction
    {
        /// <summary>
        /// The overshoot value used in some easing functions.
        /// </summary>
        public static float overshoot = 1.70158f;

        /// <summary>
        /// A function delegate that returns the value along a timing curve
        /// given the x-axis value, i.e., f(x).
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public delegate float TimingCurve(float x);

        /// <summary>
        /// A dictionary of every timing function classified by ease type.
        /// </summary>
        public static readonly Dictionary<Ease, TimingCurve> lookup = new(32, new EaseEqualityComparer())
        {
            { Ease.Linear, Linear },

            { Ease.SineIn, SineIn },
            { Ease.SineOut, SineOut },
            { Ease.SineInOut, SineInOut },

            { Ease.CubicIn, CubicIn },
            { Ease.CubicOut, CubicOut },
            { Ease.CubicInOut, CubicInOut },

            { Ease.QuadIn, QuadIn },
            { Ease.QuadOut, QuadOut },
            { Ease.QuadInOut, QuadInOut },

            { Ease.QuartIn, QuartIn },
            { Ease.QuartOut, QuartOut },
            { Ease.QuartInOut, QuartInOut },

            { Ease.QuintIn, QuintIn },
            { Ease.QuintOut, QuintOut },
            { Ease.QuintInOut, QuintInOut },

            { Ease.ExpoIn, ExpoIn },
            { Ease.ExpoOut, ExpoOut },
            { Ease.ExpoInOut, ExpoInOut },

            { Ease.CircIn, CircIn },
            { Ease.CircOut, CircOut },
            { Ease.CircInOut, CircInOut },

            { Ease.BackIn, BackIn },
            { Ease.BackOut, BackOut },
            { Ease.BackInOut, BackInOut },

            { Ease.ElasticIn, ElasticIn },
            { Ease.ElasticOut, ElasticOut },
            { Ease.ElasticInOut, ElasticInOut },

            { Ease.BounceIn, BounceIn },
            { Ease.BounceOut, BounceOut },
            { Ease.BounceInOut, BounceInOut },
        };

        /// <summary>
        /// Evaulates f(x) using a Linear ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float Linear(float x)
        {
            return x;
        }

        /// <summary>
        /// Evaulates f(x) using a SineIn ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float SineIn(float x)
        {
            return 1f - Mathf.Cos(x * Mathf.PI / 2f);
        }

        /// <summary>
        /// Evaulates f(x) using a SineOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float SineOut(float x)
        {
            return Mathf.Sin(x * Mathf.PI / 2f);
        }

        /// <summary>
        /// Evaulates f(x) using a SineInOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float SineInOut(float x)
        {
            return -(Mathf.Cos(Mathf.PI * x) - 1f) / 2f;
        }

        /// <summary>
        /// Evaulates f(x) using a CubicIn ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float CubicIn(float x)
        {
            return x * x * x;
        }

        /// <summary>
        /// Evaulates f(x) using a CubicOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float CubicOut(float x)
        {
            return 1f - Mathf.Pow(1f - x, 3f);
        }

        /// <summary>
        /// Evaulates f(x) using a CubicInOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float CubicInOut(float x)
        {
            return x < 0.5f ?
                4f * x * x * x :
                1f - Mathf.Pow(-2f * x + 2f, 3f) / 2f;
        }

        /// <summary>
        /// Evaulates f(x) using a QuadIn ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float QuadIn(float x)
        {
            return x * x;
        }

        /// <summary>
        /// Evaulates f(x) using a QuadOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float QuadOut(float x)
        {
            return 1f - (1f - x) * (1f - x);
        }

        /// <summary>
        /// Evaulates f(x) using a QuadInOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float QuadInOut(float x)
        {
            return x < 0.5f ?
                2f * x * x :
                1f - Mathf.Pow(-2f * x + 2f, 2f) / 2f;
        }

        /// <summary>
        /// Evaulates f(x) using a QuartIn ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float QuartIn(float x)
        {
            return x * x * x * x;
        }

        /// <summary>
        /// Evaulates f(x) using a QuartOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float QuartOut(float x)
        {
            return 1f - Mathf.Pow(1f - x, 4f);
        }

        /// <summary>
        /// Evaulates f(x) using a QuartInOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float QuartInOut(float x)
        {
            return x < 0.5f ?
                8f * x * x * x * x :
                1f - Mathf.Pow(-2f * x + 2f, 4f) / 2f;
        }

        /// <summary>
        /// Evaulates f(x) using a QuintIn ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float QuintIn(float x)
        {
            return x * x * x * x * x;
        }

        /// <summary>
        /// Evaulates f(x) using a QuintOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float QuintOut(float x)
        {
            return 1f - Mathf.Pow(1f - x, 5f);
        }

        /// <summary>
        /// Evaulates f(x) using a QuintInOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float QuintInOut(float x)
        {
            return x < 0.5f ?
                16f * x * x * x * x * x :
                1f - Mathf.Pow(-2f * x + 2f, 5f) / 2f;
        }

        /// <summary>
        /// Evaulates f(x) using an ExpoIn ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float ExpoIn(float x)
        {
            return x <= 0f ? 0f : Mathf.Pow(2f, 10f * x - 10f);
        }

        /// <summary>
        /// Evaulates f(x) using an ExpoOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float ExpoOut(float x)
        {
            return x >= 1f ? 1f : 1f - Mathf.Pow(2f, -10f * x);
        }

        /// <summary>
        /// Evaulates f(x) using an ExpoInOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float ExpoInOut(float x)
        {
            return x <= 0f ? 0f : x >= 1f ? 1f : x < 0.5f ?
                Mathf.Pow(2f, 20f * x - 10f) / 2f :
                (2f - Mathf.Pow(2f, -20f * x + 10f)) / 2f;
        }

        /// <summary>
        /// Evaulates f(x) using a CircIn ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float CircIn(float x)
        {
            return 1f - Mathf.Sqrt(1f - Mathf.Pow(x, 2f));
        }

        /// <summary>
        /// Evaulates f(x) using a CircOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float CircOut(float x)
        {
            return Mathf.Sqrt(1f - Mathf.Pow(x - 1f, 2f));
        }

        /// <summary>
        /// Evaulates f(x) using a CircInOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float CircInOut(float x)
        {
            return x < 0.5f ?
                (1f - Mathf.Sqrt(1f - Mathf.Pow(2f * x, 2f))) / 2f :
                (Mathf.Sqrt(1f - Mathf.Pow(-2f * x + 2f, 2f)) + 1f) / 2f;
        }

        /// <summary>
        /// Evaulates f(x) using a BackIn ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float BackIn(float x)
        {
            return (overshoot + 1f) * x * x * x - overshoot * x * x;
        }

        /// <summary>
        /// Evaulates f(x) using a BackOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float BackOut(float x)
        {
            return 1f + (overshoot + 1f) * Mathf.Pow(x - 1f, 3f) + overshoot * Mathf.Pow(x - 1f, 2f);
        }

        /// <summary>
        /// Evaulates f(x) using a BackInOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float BackInOut(float x)
        {
            float c2 = overshoot * 1.525f;
            return x < 0.5f ?
                (Mathf.Pow(2f * x, 2f) * ((c2 + 1f) * 2f * x - c2)) / 2f :
                (Mathf.Pow(2f * x - 2f, 2f) * ((c2 + 1f) * (x * 2f - 2f) + c2) + 2f) / 2f;
        }

        /// <summary>
        /// Evaulates f(x) using an ElasticIn ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float ElasticIn(float x)
        {
            return x <= 0f ? 0f : x >= 1f ? 1f :
                -Mathf.Pow(2f, 10f * x - 10f) * Mathf.Sin((x * 10f - 10.75f) * ((2f * Mathf.PI) / 3f));
        }

        /// <summary>
        /// Evaulates f(x) using an ElasticOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float ElasticOut(float x)
        {
            return x <= 0f ? 0f : x >= 1f ? 1f :
                Mathf.Pow(2f, -10f * x) * Mathf.Sin((x * 10f - 0.75f) * ((2f * Mathf.PI) / 3f)) + 1f;
        }

        /// <summary>
        /// Evaulates f(x) using an ElasticInOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float ElasticInOut(float x)
        {
            return x <= 0f ? 0f : x >= 1f ? 1f : x < 0.5f ?
                -(Mathf.Pow(2f, 20f * x - 10f) * Mathf.Sin((20f * x - 11.125f) * ((2f * Mathf.PI) / 4.5f))) / 2f :
                Mathf.Pow(2f, -20f * x + 10f) * Mathf.Sin((20f * x - 11.125f) * ((2f * Mathf.PI) / 4.5f)) / 2f + 1f;
        }

        /// <summary>
        /// Evaulates f(x) using a BounceIn ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float BounceIn(float x)
        {
            return 1f - BounceOut(1f - x);
        }

        /// <summary>
        /// Evaulates f(x) using a BounceOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float BounceOut(float x)
        {
            if (x < 1f / 2.75f) {
                return 7.5625f * x * x;
            } else if (x < 2f / 2.75f) {
                x -= (1.5f / 2.75f);
                return 7.5625f * x * x + 0.75f;
            } else if (x < 2.5f / 2.75f) {
                x -= (2.25f / 2.75f);
                return 7.5625f * x * x + 0.9375f;
            }

            x -= (2.625f / 2.75f);
            return 7.5625f * x * x + 0.984375f;
        }

        /// <summary>
        /// Evaulates f(x) using a BounceInOut ease.
        /// </summary>
        /// <param name="x">The x-axis number to evaluate.</param>
        /// <returns>The y-axis value of the curve at the given x-axis value.</returns>
        public static float BounceInOut(float x)
        {
            return x < 0.5f ?
                (1f - BounceOut(1f - 2f * x)) / 2f :
                (1f + BounceOut(2f * x - 1f)) / 2f;
        }

    }

}
