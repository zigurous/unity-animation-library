using UnityEditor;
using UnityEngine;

namespace Zigurous.Animation.Editor
{
    [CustomPropertyDrawer(typeof(TimingRange01))]
    public sealed class TimingRange01PropertyDrawer : PropertyDrawer
    {
        private const float horizontalSpacing = 4f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Start drawing the property
            EditorGUI.BeginProperty(position, label, property);

            // Draw the property label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Store orginal sizes so they can be set back to their original values
            int originalIndent = EditorGUI.indentLevel;
            float originalLabelWidth = EditorGUIUtility.labelWidth;

            // Set indent level of child fields
            EditorGUI.indentLevel = 0;

            // Create references to child fields
            SerializedProperty min = property.FindPropertyRelative("m_Min");
            SerializedProperty max = property.FindPropertyRelative("m_Max");

            // Calculate the bounds of the child fields
            Rect rect = new Rect(position);
            rect.width = (position.width - horizontalSpacing) / 2f;

            // Draw the child fields
            rect = SliderWithChangeCheck(min, rect, "Min");
            rect = SliderWithChangeCheck(max, rect, "Max");

            // Set sizes back to their original values
            EditorGUI.indentLevel = originalIndent;
            EditorGUIUtility.labelWidth = originalLabelWidth;

            // Finish drawing the property
            EditorGUI.EndProperty();
        }

        private Rect SliderWithChangeCheck(SerializedProperty property, Rect position, string displayName)
        {
            // Check for changes in the field's value
            EditorGUI.BeginChangeCheck();

            // Calculate the width of the field label
            GUIContent label = new GUIContent(displayName);
            EditorGUIUtility.labelWidth = EditorStyles.label.CalcSize(label).x;

            // Draw the field and store the field's value
            float value = EditorGUI.Slider(position, label, property.floatValue, 0f, 1f);

            // Update the property's value from the field
            if (EditorGUI.EndChangeCheck()) {
                property.floatValue = value;
            }

            // Advance the position for the next child field
            position.x += position.width + horizontalSpacing;
            return position;
        }

    }

}
