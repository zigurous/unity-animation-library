using UnityEditor;

namespace Zigurous.Animation.Editor
{
    [CustomEditor(typeof(LockScale))]
    public class LockScaleEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            SerializedProperty constraints = serializedObject.FindProperty("constraints");
            SerializedProperty useTransformScale = serializedObject.FindProperty("useTransformScale");
            SerializedProperty lockedScale = serializedObject.FindProperty("lockedScale");

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(constraints);
            EditorGUILayout.PropertyField(useTransformScale);

            if (!useTransformScale.boolValue) {
                EditorGUILayout.PropertyField(lockedScale);
            }

            if (EditorGUI.EndChangeCheck()) {
                serializedObject.ApplyModifiedProperties();
            }
        }

    }

}
