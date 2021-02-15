using UnityEditor;
using UnityEngine;

namespace Zigurous.Animation.Editor
{
    [CustomPropertyDrawer(typeof(TimingRange))]
    public sealed class TimingRangePropertyDrawer : PropertyDrawer
    {
        private static readonly float horizontalSpacing = 4.0f;

        private SerializedProperty _min;
        private SerializedProperty _max;

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
            if (_min == null) _min = property.FindPropertyRelative("min");
            if (_max == null) _max = property.FindPropertyRelative("max");

            // Calculate the bounds of the child fields
            Rect rect = new Rect(position);
            rect.width = (position.width - horizontalSpacing) / 2;

            // Draw the child fields
            rect = FloatFieldWithChangeCheck(_min, rect);
            rect = FloatFieldWithChangeCheck(_max, rect);

            // Set sizes back to their original values
            EditorGUI.indentLevel = originalIndent;
            EditorGUIUtility.labelWidth = originalLabelWidth;

            // Finish drawing the property
            EditorGUI.EndProperty();
        }

        private Rect FloatFieldWithChangeCheck(SerializedProperty property, Rect position)
        {
            // Check for changes in the field's value
            EditorGUI.BeginChangeCheck();

            // Calculate the width of the field label
            GUIContent label = new GUIContent(property.displayName);
            EditorGUIUtility.labelWidth = EditorStyles.label.CalcSize(label).x;

            // Draw the field and store the field's value
            float value = EditorGUI.FloatField(position, label, property.floatValue);

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
