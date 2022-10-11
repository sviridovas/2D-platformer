using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelGenerator))]
public class GenerateLevelEditor : Editor
{
    private LevelGenerator _levelGenerator;

    private void OnEnable()
    {
        _levelGenerator = (LevelGenerator)target;
    }

    public  override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("_generatedTilemap"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_tileGround"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_mapWidth"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_mapHeight"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_factorSmooth"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_randomFillPercent"));

        if(GUI.Button(new Rect(10, 0, 60, 50), "Generate"))
            _levelGenerator.Generate();

        if(GUI.Button(new Rect(10, 55, 60, 50), "Clear"))
            _levelGenerator.Clear();

        GUILayout.Space(100);

        serializedObject.ApplyModifiedProperties();
    }
}
