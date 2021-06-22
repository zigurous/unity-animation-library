using UnityEditor;
using UnityEngine;

namespace Zigurous.Animation.Editor
{
    [CustomPropertyDrawer(typeof(AnimatorParameter))]
    public sealed class AnimatorParameterPropertyDrawer : PropertyDrawer
    {
        private SerializedProperty _name;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (_name == null) {
                _name = property.FindPropertyRelative("_name");
            }

            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            _name.stringValue = EditorGUI.TextField(position, _name.stringValue);
            EditorGUI.EndProperty();
        }

    }

}
