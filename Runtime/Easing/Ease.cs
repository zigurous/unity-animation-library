namespace Zigurous.Animation
{
    /// <summary>
    /// An easing function type. Easing functions specify the rate of change of
    /// a parameter over time.
    /// </summary>
    public enum Ease : int
    {
        Linear,
        SineIn,
        SineOut,
        SineInOut,
        CubicIn,
        CubicOut,
        CubicInOut,
        QuadIn,
        QuadOut,
        QuadInOut,
        QuartIn,
        QuartOut,
        QuartInOut,
        QuintIn,
        QuintOut,
        QuintInOut,
        ExpoIn,
        ExpoOut,
        ExpoInOut,
        CircIn,
        CircOut,
        CircInOut,
        BackIn,
        BackOut,
        BackInOut,
        ElasticIn,
        ElasticOut,
        ElasticInOut,
        BounceIn,
        BounceOut,
        BounceInOut
    }

    /// <summary>
    /// Extension methods for <see cref="Ease"/>.
    /// </summary>
    public static class EaseExtensions
    {
        /// <summary>
        /// Returns the f(x) value using the ease function.
        /// </summary>
        /// <param name="ease">The ease function type.</param>
        /// <param name="x">The x-axis value to evaluate.</param>
        /// <returns>The interpolated value.</returns>
        public static float ValueAt(this Ease ease, float x)
        {
            return EaseFunction.lookup[ease](x);
        }

    }

}
