namespace Zigurous.Animation
{
    /// <summary>
    /// Flags to constrain an axis.
    /// </summary>
    [System.Flags]
    public enum AxisConstraint : int
    {
        /// <summary>
        /// No constraint.
        /// </summary>
        None = 0,

        /// <summary>
        /// Constrain the X axis.
        /// </summary>
        X = 1 << 0,

        /// <summary>
        /// Constrain the Y axis.
        /// </summary>
        Y = 1 << 1,

        /// <summary>
        /// Constrain the Z axis.
        /// </summary>
        Z = 1 << 2,
    }

    /// <summary>
    /// Extension methods for <see cref="AxisConstraint"/>.
    /// </summary>
    public static class AxisConstraintExtensions
    {
        /// <summary>
        /// Checks if the constraints contains the specified axis.
        /// </summary>
        /// <param name="constraints">The constraints to check.</param>
        /// <param name="axis">The axis to check for.</param>
        /// <returns>True if the constraints contain the specified axis.</returns>
        public static bool Contains(this AxisConstraint constraints, AxisConstraint axis)
        {
            return ((int)constraints & (int)axis) == (int)axis;
        }

    }

}
