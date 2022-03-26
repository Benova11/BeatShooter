using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(simpleAduioEvent))]
public class simpleAudioEventEditor : Editor
{
    AudioSource previewSource;
  
    private void OnEnable()
    {
        previewSource = EditorUtility.CreateGameObjectWithHideFlags("previe wSource", HideFlags.HideAndDontSave,
            typeof(AudioSource)).GetComponent<AudioSource>();
    }
    private void OnDisable()
    {
        DestroyImmediate(previewSource);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
        if (GUILayout.Button("Preview"))
        {
            var simpleTarget = (simpleAduioEvent)target;
            simpleTarget.Play(previewSource);


        }

        EditorGUI.EndDisabledGroup();
    }
}
