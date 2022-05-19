﻿using UnityEngine;

namespace Zigurous.Animation.Execution
{
    /// <summary>
    /// An update strategy executed during the normal update loop.
    /// </summary>
    public sealed class NormalUpdateStrategy : UpdateStrategy
    {
        private void Update()
        {
            Execute(Time.deltaTime);
        }

    }

}