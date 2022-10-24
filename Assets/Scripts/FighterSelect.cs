using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterSelect : MonoBehaviour
{
    public Fighter[] fighters;

    /* 1 Initialize all the things
     * 
     * 2 Checks that the next opponent being chosen is not already a friend
     * It does this by chosing a random fighter and making sure it's not already a friend
     * 
     * 3 Once the fighter has been chosen, assume it's going to be beaten and become a friend,
     * and then update the text to show who it is
     * 
     * 4 If there are only 3 fighters left, show the squad strike
     */
    public string ChooseFighter()
    {
        #region Initializations
        Text fighterText = gameObject.GetComponent<Text>();
        System.Random randomNumberGenerator = new System.Random();
        Fighter chosenFighter;
        int randomNumber;
        int remainingFighters = fighters.Length;
        #endregion//1

        int i = 0;
        do//2
        {
            randomNumber = randomNumberGenerator.Next(0, fighters.Length);
            chosenFighter = fighters[randomNumber];

            i++;
            if (i > 1000) throw new UnityException("Got stuck in an infinite while loop");
        } while (chosenFighter.status != Fighter.Status.Enemy) ;

        fighters[randomNumber].status = Fighter.Status.Friend;//3
        fighterText.text = chosenFighter.name;

        remainingFighters--;
        if (remainingFighters == 3) fighterText.text = ArrangeSquadStrike();//4

        return chosenFighter.name;
    }

    string ArrangeSquadStrike()
    {
        string fullList = "";
        foreach(Fighter fighter in fighters)
        {
            fullList += fighter.name + "\n";
        }

        return fullList;
    }
}

[System.Serializable]
public struct Fighter
{
    public string name;
    public enum Status {Enemy, Friend, Dead};
    public Status status;
}
