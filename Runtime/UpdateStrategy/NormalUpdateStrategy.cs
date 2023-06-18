using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// An update strategy executed during the normal update loop.
    /// </summary>
    internal sealed class NormalUpdateStrategy : UpdateStrategy
    {
        private void Update()
        {
            Execute(Time.deltaTime);
        }

    }

}
