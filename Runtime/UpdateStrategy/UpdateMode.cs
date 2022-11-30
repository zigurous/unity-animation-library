using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// An update mode an animation behavior can run with.
    /// </summary>
    public enum UpdateMode
    {
        /// <summary>
        /// Updates during the normal loop, once every frame.
        /// </summary>
        [Tooltip("Updates during the normal loop, once every frame.")]
        Update,

        /// <summary>
        /// Updates after all other update functions, once every frame.
        /// </summary>
        [Tooltip("Updates after all other update functions, once every frame.")]
        LateUpdate,

        /// <summary>
        /// Updates during the physics loop at a fixed timestep.
        /// </summary>
        [Tooltip("Updates during the physics loop at a fixed timestep.")]
        FixedUpdate,
    }

}
