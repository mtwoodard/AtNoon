using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerStats))]
public class PlayerStatsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlayerStats stats = (PlayerStats)target;
        stats.Health = EditorGUILayout.IntField(stats.Health);
    }
}
