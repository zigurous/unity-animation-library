namespace Zigurous.Animation
{
    /// <summary>
    /// Flags to constrain the properties of a transform.
    /// </summary>
    [System.Flags]
    public enum TransformConstraint : int
    {
        /// <summary>
        /// No constraint.
        /// </summary>
        None = 0,

        /// <summary>
        /// Constrain the position of a transform.
        /// </summary>
        Position = 1 << 0,

        /// <summary>
        /// Constrain the rotation of a transform.
        /// </summary>
        Rotation = 1 << 1,

        /// <summary>
        /// Constrain the scale of a transform.
        /// </summary>
        Scale = 1 << 2,
    }

    /// <summary>
    /// Extension methods for <see cref="TransformConstraint"/>.
    /// </summary>
    public static class TransformConstraintExtensions
    {
        /// <summary>
        /// Checks if the constraints contains the specified flag.
        /// </summary>
        /// <param name="constraints">The constraints to check.</param>
        /// <param name="flag">The flag to check for.</param>
        /// <returns>True if the constraints contain the specified flag.</returns>
        public static bool Contains(this TransformConstraint constraints, TransformConstraint flag)
        {
            return ((int)constraints & (int)flag) == (int)flag;
        }

    }

}
