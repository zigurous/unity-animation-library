using UnityEditor;
using UnityEngine;

namespace Zigurous.Animation.Editor
{
    [CustomPropertyDrawer(typeof(Timing))]
    public sealed class TimingPropertyDrawer : PropertyDrawer
    {
        private static readonly GUIContent startLabel = new GUIContent("Start");
        private static readonly GUIContent endLabel = new GUIContent("End");

        private const float horizontalSpacing = 4f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int originalIndent = EditorGUI.indentLevel;
            float originalLabelWidth = EditorGUIUtility.labelWidth;

            EditorGUI.indentLevel = 0;

            SerializedProperty m_Start = property.FindPropertyRelative("m_Start");
            SerializedProperty m_End = property.FindPropertyRelative("m_End");

            Rect field = new Rect(position);
            field.width = (position.width - horizontalSpacing) / 2f;

            field = FloatField(field, m_Start, startLabel);
            field = FloatField(field, m_End, endLabel);

            EditorGUI.indentLevel = originalIndent;
            EditorGUIUtility.labelWidth = originalLabelWidth;
            EditorGUI.EndProperty();
        }

        private Rect FloatField(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUIUtility.labelWidth = EditorStyles.label.CalcSize(label).x;

            property.serializedObject.Update();
            property.floatValue = EditorGUI.FloatField(position, label, property.floatValue);
            property.serializedObject.ApplyModifiedProperties();

            position.x += position.width + horizontalSpacing;
            return position;
        }

    }

}
