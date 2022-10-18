using UnityEditor;

namespace Zigurous.Animation.Editor
{
    [CustomEditor(typeof(LockTransform))]
    public class LockTransformEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            SerializedProperty constraints = serializedObject.FindProperty("constraints");
            SerializedProperty useTransformValues = serializedObject.FindProperty("useTransformValues");
            SerializedProperty lockedPosition = serializedObject.FindProperty("lockedPosition");
            SerializedProperty lockedRotation = serializedObject.FindProperty("lockedRotation");
            SerializedProperty lockedScale = serializedObject.FindProperty("lockedScale");

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(constraints);
            EditorGUILayout.PropertyField(useTransformValues);

            if (!useTransformValues.boolValue)
            {
                EditorGUILayout.PropertyField(lockedPosition);
                EditorGUILayout.PropertyField(lockedRotation);
                EditorGUILayout.PropertyField(lockedScale);
            }

            if (EditorGUI.EndChangeCheck()) {
                serializedObject.ApplyModifiedProperties();
            }
        }

    }

}
