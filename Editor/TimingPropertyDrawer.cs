using UnityEditor;
using UnityEngine;

namespace Zigurous.Animation.Editor
{
    [CustomPropertyDrawer(typeof(Timing))]
    public sealed class TimingPropertyDrawer : PropertyDrawer
    {
        private static readonly float horizontalSpacing = 4.0f;

        private SerializedProperty _startTime;
        private SerializedProperty _endTime;

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
            if (_startTime == null) _startTime = property.FindPropertyRelative("startTime");
            if (_endTime == null) _endTime = property.FindPropertyRelative("endTime");

            // Calculate the bounds of the child fields
            Rect rect = new Rect(position);
            rect.width = (position.width - horizontalSpacing) / 2;

            // Draw the child fields
            rect = SliderWithChangeCheck(_startTime, rect, "Start");
            rect = SliderWithChangeCheck(_endTime, rect, "End");

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
            float value = EditorGUI.Slider(position, label, property.floatValue, 0.0f, 1.0f);

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
