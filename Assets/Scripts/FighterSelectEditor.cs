using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FighterSelect))]
public class FighterSelectEditor : Editor
{
    /* 
     */
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Next Fighter")) 
        {
            var fighterSelect = (FighterSelect)target;

            fighterSelect.ChooseFighter();
        } 
    }
}
