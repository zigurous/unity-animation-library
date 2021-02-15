using UnityEngine;

namespace Zigurous.Animation
{
    public sealed class Rotate : MonoBehaviour
    {
        public Vector3 speed = Vector3.up;
        public Space space = Space.World;

        private void Update()
        {
            this.transform.Rotate(this.speed * Time.deltaTime, this.space);
        }

    }

}
