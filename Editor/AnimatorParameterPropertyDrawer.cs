using UnityEditor;
using UnityEngine;

namespace Zigurous.Animation.Editor
{
    [CustomPropertyDrawer(typeof(AnimatorParameter))]
    public sealed class AnimatorParameterPropertyDrawer : PropertyDrawer
    {
        private SerializedProperty _name;
        private SerializedProperty _hash;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (_name == null) {
                _name = property.FindPropertyRelative("_name");
            }

            if (_hash == null) {
                _hash = property.FindPropertyRelative("_hash");
            }

            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            string name = EditorGUI.TextField(position, _name.stringValue);

            if (name != _name.stringValue)
            {
                _name.stringValue = name;
                _hash.intValue = Animator.StringToHash(name);
            }

            EditorGUI.EndProperty();
        }

    }

}
