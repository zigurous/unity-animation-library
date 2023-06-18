using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// An update strategy executed during the fixed update loop.
    /// </summary>
    internal sealed class FixedUpdateStrategy : UpdateStrategy
    {
        private void FixedUpdate()
        {
            Execute(Time.fixedDeltaTime);
        }

    }

}
