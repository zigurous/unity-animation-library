using UnityEngine;

namespace Zigurous.Animation
{
    public sealed class Move : MonoBehaviour
    {
        public Vector3 speed = Vector3.zero;
        public Space space = Space.World;

        private void Update()
        {
            this.transform.Translate(this.speed * Time.deltaTime, this.space);
        }
    }

}
