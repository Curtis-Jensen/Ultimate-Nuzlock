using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FighterSelect))]
public class FighterSelectEditor : Editor
{
    /* 1 Picks a number between 1 (inclusive) and 12 (inclusive)
     */
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Next Fighter")) 
        {
            var fighterSelect = (FighterSelect)target;

            Debug.Log(fighterSelect.ChooseFighter());//1
        } 
    }
}
