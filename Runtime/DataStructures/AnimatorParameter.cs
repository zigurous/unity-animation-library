using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// An animation parameter that can be set on an animator. A hash id is
    /// automatically created for the parameter for optimal code.
    /// </summary>
    [System.Serializable]
    public struct AnimatorParameter
    {
        [SerializeField]
        [HideInInspector]
        private int _hash;

        /// <summary>
        /// The hash id of the animation parameter.
        /// </summary>
        public int hash
        {
            get
            {
                if (_hash == 0) {
                    _hash = Animator.StringToHash(_name);
                }
                return _hash;
            }
        }

        [SerializeField]
        [Tooltip("The name of the animation parameter.")]
        private string _name;

        /// <summary>
        /// The name of the animation parameter.
        /// </summary>
        public string name
        {
            get => _name;
            set
            {
                _name = value;
                _hash = Animator.StringToHash(value);
            }
        }

        /// <summary>
        /// Constructs a new animation parameter with the given name.
        /// </summary>
        public AnimatorParameter(string name)
        {
            _name = name;
            _hash = Animator.StringToHash(name);
        }

        public static implicit operator AnimatorParameter(string name) => new AnimatorParameter(name);

    }

}
