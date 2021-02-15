using UnityEngine;

namespace Zigurous.Animation
{
    public sealed class Scale : MonoBehaviour
    {
        public Vector3 speed = Vector3.one;

        private void Update()
        {
            this.transform.localScale += this.speed * Time.deltaTime;
        }

    }

}
