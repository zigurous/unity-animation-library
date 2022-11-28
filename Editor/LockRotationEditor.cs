using UnityEditor;

namespace Zigurous.Animation.Editor
{
    [CustomEditor(typeof(LockRotation))]
    public class LockRotationEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            SerializedProperty space = serializedObject.FindProperty("space");
            SerializedProperty constraints = serializedObject.FindProperty("constraints");
            SerializedProperty useTransformRotation = serializedObject.FindProperty("useTransformRotation");
            SerializedProperty lockedRotation = serializedObject.FindProperty("lockedRotation");

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(space);
            EditorGUILayout.PropertyField(constraints);
            EditorGUILayout.PropertyField(useTransformRotation);

            if (!useTransformRotation.boolValue) {
                EditorGUILayout.PropertyField(lockedRotation);
            }

            if (EditorGUI.EndChangeCheck()) {
                serializedObject.ApplyModifiedProperties();
            }
        }

    }

}
