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

        if (GUILayout.Button("Next Fighters")) 
        {
            var fighterSelect = (FighterSelect)target;

            if (fighterSelect.remainingFighters == fighterSelect.fighters.Length)
                fighterSelect.ChooseFighter(Fighter.Status.Enemy, fighterSelect.enemyFighterText);

            if (fighterSelect.remainingFighters == 3 && fighterSelect.squadStrikeEnd)
            {
                fighterSelect.enemyFighterText.text = fighterSelect.ArrangeSquadStrike();
            }
            else
            {
                fighterSelect.SlowMo();
                fighterSelect.ChooseFighter(Fighter.Status.Friend, fighterSelect.friendFighterText);
                fighterSelect.ChooseFighter(Fighter.Status.Enemy, fighterSelect.enemyFighterText);
            }
        }
    }
}
