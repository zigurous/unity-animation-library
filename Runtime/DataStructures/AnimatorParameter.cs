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
        [System.NonSerialized]
        [HideInInspector]
        private int m_Hash;

        /// <summary>
        /// The hash id of the animator parameter (Read only).
        /// </summary>
        public int hash
        {
            get
            {
                if (m_Hash == 0) {
                    m_Hash = Animator.StringToHash(m_Name);
                }
                return m_Hash;
            }
        }

        [SerializeField]
        [Tooltip("The name of the animator parameter.")]
        private string m_Name;

        /// <summary>
        /// The name of the animator parameter.
        /// </summary>
        public string name
        {
            get => m_Name;
            set
            {
                m_Name = value;
                m_Hash = Animator.StringToHash(value);
            }
        }

        /// <summary>
        /// Creates a new animator parameter with the given name.
        /// </summary>
        /// <param name="name">The name of the animator parameter.</param>
        public AnimatorParameter(string name)
        {
            m_Name = name;
            m_Hash = Animator.StringToHash(name);
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
