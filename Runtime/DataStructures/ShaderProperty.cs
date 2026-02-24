using System;
using UnityEngine;

namespace Zigurous.Animation
{
    /// <summary>
    /// A shader property that can be set on a material. An id is automatically
    /// created for the property for optimal code.
    /// </summary>
    [Serializable]
    public struct ShaderProperty : IEquatable<ShaderProperty>
    {
        [NonSerialized]
        [HideInInspector]
        private int m_Id;

        /// <summary>
        /// The id of the shader property (Read only).
        /// </summary>
        public int id
        {
            get
            {
                if (m_Id == 0) {
                    m_Id = Shader.PropertyToID(m_Name);
                }
                return m_Id;
            }
        }

        [SerializeField]
        [Tooltip("The name of the shader property.")]
        private string m_Name;

        /// <summary>
        /// The name of the shader property.
        /// </summary>
        public string name
        {
            readonly get => m_Name;
            set
            {
                m_Name = value;
                m_Id = Shader.PropertyToID(value);
            }
        }

        /// <summary>
        /// Creates a new shader property with the given name.
        /// </summary>
        /// <param name="name">The name of the shader property.</param>
        public ShaderProperty(string name)
        {
            m_Name = name;
            m_Id = 0;
        }

        /// <summary>
        /// Determines if the shader property is equal to another.
        /// </summary>
        /// <param name="other">The other shader property to compare to.</param>
        /// <returns>True if the shader properties are equal, false otherwise.</returns>
        public bool Equals(ShaderProperty other)
        {
            return id == other.id;
        }

        /// <summary>
        /// Determines if the shader property is equal to another.
        /// </summary>
        /// <param name="other">The other object to compare to.</param>
        /// <returns>True if the shader properties are equal, false otherwise.</returns>
        public override bool Equals(object other)
        {
            if (other is ShaderProperty property) {
                return Equals(property);
            } else {
                return false;
            }
        }

        /// <summary>
        /// Returns the hash code of the shader property.
        /// </summary>
        /// <returns>The hash code of the shader property.</returns>
        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        /// <summary>
        /// Determines if two shader properties are equal.
        /// </summary>
        /// <param name="lhs">The first shader property to compare.</param>
        /// <param name="rhs">The second shader property to compare.</param>
        /// <returns>True if the shader properties are equal, false otherwise.</returns>
        public static bool operator ==(ShaderProperty lhs, ShaderProperty rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Determines if two shader properties are not equal.
        /// </summary>
        /// <param name="lhs">The first shader property to compare.</param>
        /// <param name="rhs">The second shader property to compare.</param>
        /// <returns>True if the shader properties are not equal, false otherwise.</returns>
        public static bool operator !=(ShaderProperty lhs, ShaderProperty rhs)
        {
            return !lhs.Equals(rhs);
        }

        /// <summary>
        /// Implicitly converts a name to a shader property.
        /// </summary>
        /// <param name="name">The name of the shader property.</param>
        /// <returns>A shader property with the given name.</returns>
        public static implicit operator ShaderProperty(string name) => new(name);

        /// <summary>
        /// Implicitly converts a shader property to an id.
        /// </summary>
        /// <param name="property">The shader property to convert to an id.</param>
        /// <returns>The id of the shader property.</returns>
        public static implicit operator int(ShaderProperty property) => property.id;
    }

}
