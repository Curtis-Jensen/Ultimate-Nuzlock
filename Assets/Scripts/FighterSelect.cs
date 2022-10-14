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
     * 3 Once the fighter has been chosen, assume it's a friend, and then update the text to show who it is
     */
    public string ChooseFighter()
    {
        #region Initializations
        Text fighterText = gameObject.GetComponent<Text>();
        System.Random randomNumberGenerator = new System.Random();
        Fighter chosenFighter;
        int randomNumber;
        #endregion//1

        do//2
        {
            randomNumber = randomNumberGenerator.Next(1, 12);
            chosenFighter = fighters[randomNumber];
        } while (chosenFighter.status != Fighter.Status.Enemy) ;

        fighters[randomNumber].status = Fighter.Status.Friend;//3
        fighterText.text = chosenFighter.name;

        return chosenFighter.name;
    }
}

[System.Serializable]
public struct Fighter
{
    public string name;
    public enum Status {Enemy, Friend, Dead };
    public Status status;
}
