using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// An update strategy executed during the late update loop.
    /// </summary>
    internal sealed class LateUpdateStrategy : UpdateStrategy
    {
        private void LateUpdate()
        {
            Execute(Time.deltaTime);
        }

    }

}
