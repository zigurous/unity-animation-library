using UnityEngine;

namespace Zigurous.Animation.Execution
{
    /// <summary>
    /// An update strategy that executes an update action.
    /// </summary>
    internal abstract class UpdateStrategy : MonoBehaviour
    {
        /// <summary>
        /// A function delegate to execute an update action.
        /// </summary>
        /// <param name="deltaTime">The time since the last frame.</param>
        public delegate void UpdateAction(float deltaTime);

        /// <summary>
        /// The update action to execute.
        /// </summary>
        private UpdateAction update;

        /// <summary>
        /// Executes the update action.
        /// </summary>
        /// <param name="deltaTime">The time since the last frame.</param>
        public void Execute(float deltaTime)
        {
            if (update != null) {
                update.Invoke(deltaTime);
            }
        }

        /// <summary>
        /// Registers an update action to be executed by the strategy.
        /// </summary>
        /// <param name="action">The update action to register.</param>
        public void Register(UpdateAction action)
        {
            if (action != null)
            {
                update += action;
                enabled = update != null;
            }
        }

        /// <summary>
        /// Unregisters an update action from being executed by the strategy.
        /// </summary>
        /// <param name="action">The update action to unregister.</param>
        public void Unregister(UpdateAction action)
        {
            if (action != null)
            {
                update -= action;
                enabled = update != null;
            }
        }

    }

}
