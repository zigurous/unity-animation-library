using UnityEditor;
using UnityEngine;

namespace Zigurous.Animation.Editor
{
    [CustomPropertyDrawer(typeof(TimingRange01))]
    public sealed class TimingRange01PropertyDrawer : PropertyDrawer
    {
        private static readonly GUIContent minLabel = new GUIContent("Min");
        private static readonly GUIContent maxLabel = new GUIContent("Max");

        private const float horizontalSpacing = 4f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int originalIndent = EditorGUI.indentLevel;
            float originalLabelWidth = EditorGUIUtility.labelWidth;

            EditorGUI.indentLevel = 0;

            SerializedProperty m_Min = property.FindPropertyRelative("m_Min");
            SerializedProperty m_Max = property.FindPropertyRelative("m_Max");

            Rect field = new Rect(position);
            field.width = (position.width - horizontalSpacing) / 2f;

            field = SliderField(field, m_Min, minLabel);
            field = SliderField(field, m_Max, maxLabel);

            EditorGUI.indentLevel = originalIndent;
            EditorGUIUtility.labelWidth = originalLabelWidth;
            EditorGUI.EndProperty();
        }

        private Rect SliderField(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUIUtility.labelWidth = EditorStyles.label.CalcSize(label).x;

            property.serializedObject.Update();
            property.floatValue = EditorGUI.Slider(position, label, property.floatValue, 0f, 1f);
            property.serializedObject.ApplyModifiedProperties();

            position.x += position.width + horizontalSpacing;
            return position;
        }

    }

}
