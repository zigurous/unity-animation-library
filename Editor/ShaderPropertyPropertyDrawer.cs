using UnityEditor;
using UnityEngine;

namespace Zigurous.Animation.Editor
{
    [CustomPropertyDrawer(typeof(ShaderProperty))]
    public sealed class ShaderPropertyPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty nameProperty = property.FindPropertyRelative("m_Name");

            label = EditorGUI.BeginProperty(position, label, property);

            EditorGUI.BeginChangeCheck();

            nameProperty.stringValue = EditorGUI.DelayedTextField(position, label, nameProperty.stringValue);

            if (EditorGUI.EndChangeCheck()) {
                property.serializedObject.ApplyModifiedProperties();
            }

            EditorGUI.EndProperty();
        }

    }

}
