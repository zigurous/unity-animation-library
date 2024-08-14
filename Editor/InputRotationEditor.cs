using UnityEditor;
using UnityEngine;

namespace Zigurous.Animation.Editor
{
    [CustomEditor(typeof(InputRotation))]
    public class InputRotationEditor : UnityEditor.Editor
    {
        private static readonly GUIContent rotateInputLabel = new("Rotate Input");

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            using (new EditorGUI.DisabledScope(true)) {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"));
            }

            #if ENABLE_INPUT_SYSTEM
            SerializedProperty useInputReference = serializedObject.FindProperty("useInputReference");
            SerializedProperty rotateInput = serializedObject.FindProperty("rotateInput");
            SerializedProperty rotateInputReference = serializedObject.FindProperty("rotateInputReference");
            #elif ENABLE_LEGACY_INPUT_MANAGER
            SerializedProperty inputAxis = serializedObject.FindProperty("inputAxis");
            #endif

            SerializedProperty axis = serializedObject.FindProperty("axis");
            SerializedProperty speed = serializedObject.FindProperty("speed");
            SerializedProperty space = serializedObject.FindProperty("space");

            EditorGUI.BeginChangeCheck();

            #if ENABLE_INPUT_SYSTEM
            EditorGUILayout.PropertyField(useInputReference);

            if (useInputReference.boolValue) {
                EditorGUILayout.PropertyField(rotateInputReference, rotateInputLabel);
            } else {
                EditorGUILayout.PropertyField(rotateInput, rotateInputLabel);
            }
            #elif ENABLE_LEGACY_INPUT_MANAGER
            EditorGUILayout.PropertyField(inputAxis);
            #endif

            EditorGUILayout.PropertyField(axis);
            EditorGUILayout.PropertyField(speed);
            EditorGUILayout.PropertyField(space);

            if (EditorGUI.EndChangeCheck()) {
                serializedObject.ApplyModifiedProperties();
            }
        }

    }

}
