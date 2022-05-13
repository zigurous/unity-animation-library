using UnityEngine;

namespace Zigurous.Animation.Execution
{
    /// <summary>
    /// An update strategy executed during the fixed update update loop.
    /// </summary>
    public sealed class FixedUpdateStrategy : UpdateStrategy
    {
        private void FixedUpdate()
        {
            Execute(Time.fixedDeltaTime);
        }

    }

}
