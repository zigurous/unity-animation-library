namespace Zigurous.Animation
{
    /// <summary>
    /// An update mode during which an animation behavior can run.
    /// </summary>
    public enum UpdateMode
    {
        /// <summary>
        /// Updates during the normal loop, once every frame.
        /// </summary>
        Update,

        /// <summary>
        /// Updates after all other update functions, once every frame.
        /// </summary>
        LateUpdate,

        /// <summary>
        /// Updates during the physics loop at a fixed timestep.
        /// </summary>
        FixedUpdate,
    }

}
