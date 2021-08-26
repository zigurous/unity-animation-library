using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// An animation parameter that can be set on an Animator.
    /// </summary>
    /// <remarks>
    /// A hash id is automatically created for the parameter. Ids are used for
    /// optimized setters and getters on Animator parameters.
    /// </remarks>
    [System.Serializable]
    public struct AnimatorParameter
    {
        [SerializeField]
        [HideInInspector]
        private int _hash;

        /// <summary>
        /// The hash id of the animator parameter (Read only).
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
        [Tooltip("The name of the animator parameter.")]
        private string _name;

        /// <summary>
        /// The name of the animator parameter.
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
        /// Creates a new animator parameter with the given name.
        /// </summary>
        /// <param name="name">The name of the animator parameter.</param>
        public AnimatorParameter(string name)
        {
            _name = name;
            _hash = Animator.StringToHash(name);
        }

        /// <summary>
        /// Implicitly converts a name to an animator parameter.
        /// </summary>
        /// <param name="name">The name of the animator parameter.</param>
        /// <returns>A new animator parameter with the given name.</returns>
        public static implicit operator AnimatorParameter(string name) => new AnimatorParameter(name);

        /// <summary>
        /// Implicitly converts an animator parameter to a hash id.
        /// </summary>
        /// <param name="property">The animator parameter to convert to an id.</param>
        /// <returns>The hash id of the animator parameter.</returns>
        public static implicit operator int(AnimatorParameter property) => property.hash;

    }

}
