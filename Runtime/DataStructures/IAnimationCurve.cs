namespace Zigurous.Animation
{
    /// <summary>
    /// A type that can be represented with animation curves.
    /// </summary>
    /// <typeparam name="T">The type evaluated by the animation curve.</typeparam>
    public interface IAnimationCurve<T>
    {
        /// <summary>
        /// Evaluate the curve at the specified time.
        /// </summary>
        /// <param name="time">The time within the curve you want to evaluate (the horizontal axis in the curve graph).</param>
        /// <returns>The value of the curve, at the point in time specified.</returns>
        T Evaluate(float time);

        /// <summary>
        /// Adds a new key to the curve.
        /// </summary>
        /// <param name="time">The time at which to add the key (horizontal axis in the curve graph).</param>
        /// <param name="value">The value for the key (vertical axis in the curve graph).</param>
        void AddKey(float time, T value);

        /// <summary>
        /// Removes a key.
        /// </summary>
        /// <param name="index">The index of the key to remove.</param>
        void RemoveKey(int index);
    }

}
