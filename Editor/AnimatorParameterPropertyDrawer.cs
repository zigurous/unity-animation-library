using UnityEditor;
using UnityEngine;

namespace Zigurous.Animation.Editor
{
    [CustomPropertyDrawer(typeof(AnimatorParameter))]
    public sealed class AnimatorParameterPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty name = property.FindPropertyRelative("m_Name");
            SerializedProperty hash = property.FindPropertyRelative("m_Hash");

            EditorGUI.BeginProperty(position, label, property);

            string nameValue = EditorGUI.TextField(position, label, name.stringValue);

            if (nameValue != name.stringValue)
            {
                name.stringValue = nameValue;
                hash.intValue = Animator.StringToHash(nameValue);
                property.serializedObject.ApplyModifiedProperties();
            }

            EditorGUI.EndProperty();
        }

    }

}
