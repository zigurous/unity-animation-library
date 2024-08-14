using UnityEditor;

namespace Zigurous.Animation.Editor
{
    [CustomEditor(typeof(LockPosition))]
    public class LockPositionEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            using (new EditorGUI.DisabledScope(true)) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"));
            }

            SerializedProperty space = serializedObject.FindProperty("space");
            SerializedProperty constraints = serializedObject.FindProperty("constraints");
            SerializedProperty useTransformPosition = serializedObject.FindProperty("useTransformPosition");
            SerializedProperty lockedPosition = serializedObject.FindProperty("lockedPosition");

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(space);
            EditorGUILayout.PropertyField(constraints);
            EditorGUILayout.PropertyField(useTransformPosition);

            if (!useTransformPosition.boolValue) {
                EditorGUILayout.PropertyField(lockedPosition);
            }

            if (EditorGUI.EndChangeCheck()) {
                serializedObject.ApplyModifiedProperties();
            }
        }

    }

}
