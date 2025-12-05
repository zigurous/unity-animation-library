using System.Collections.Generic;

namespace Zigurous.Animation
{
    /// <summary>
    /// Compares the equality of two <see cref="Ease"/> types.
    /// </summary>
    internal sealed class EaseEqualityComparer : IEqualityComparer<Ease>
    {
        /// <summary>
        /// Compares the equality of two <see cref="Ease"/> types.
        /// </summary>
        /// <param name="x">The first ease to compare.</param>
        /// <param name="y">The second ease to compare.</param>
        /// <returns>True if the two ease types are equal.</returns>
        public bool Equals(Ease x, Ease y) => x == y;

        /// <summary>
        /// Returns the hash code for a specified <see cref="Ease"/> type.
        /// </summary>
        /// <param name="ease">The ease to get the hash code for.</param>
        /// <returns>The hash code for the ease.</returns>
        public int GetHashCode(Ease ease) => (int)ease;
    }

}
