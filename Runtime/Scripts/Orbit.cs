using UnityEngine;

namespace Zigurous.Animation
{
    public sealed class Orbit : MonoBehaviour
    {
        public Transform center;

        public float speed = 1.0f;
        public float radius = 1.0f;

        [Range(0.0f, 360.0f)]
        public float startAngle = 0.0f;
        private float _angle = 0.0f;

        private void Start()
        {
            _angle = this.startAngle;
        }

        private void OnDestroy()
        {
            this.center = null;
        }

        private void LateUpdate()
        {
            _angle += this.speed * Time.deltaTime;

            float radians = _angle * Mathf.Deg2Rad;

            this.transform.position = new Vector3(
                x: this.center.position.x + (Mathf.Cos(radians) * this.radius),
                y: this.center.position.y,
                z: this.center.position.z + (Mathf.Sin(radians) * this.radius)
            );
        }

    }

}
