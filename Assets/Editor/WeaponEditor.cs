using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        //Weapon weapon = (Weapon)target;
        //EditorGUILayout.FloatField(weapon.damage);
    }
}
