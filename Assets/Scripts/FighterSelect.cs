using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterSelect : MonoBehaviour
{
    [Tooltip("Will squad strike be in the ending?")]
    public bool squadStrikeEnd;
    [Range(1,9)] 
    [Tooltip("What level to set the CPUs to.  This is more to keep track; it's not called in code.")]
    public int difficultyLevel = 9;
    [Range(0,1)]
    public float slowMoChance;
    [Tooltip("What fighters are being used.")]
    public Fighter[] fighters;
    public Text friendFighterText;
    public Text enemyFighterText;
    public Text slowMoText;

    internal int remainingFighters;
    int randomNumber;
    System.Random randomNumberGenerator;
    Fighter chosenFighter;

    /* 1 Because enemy selection turns them into a friend, it can be used to pick an initial player 1
     * 
     * 2 Naturally, this will choose the same fighter as the line above.  Then an enemy is chosen
     */
    void Start()
    {
        enemyFighterText = gameObject.GetComponent<Text>();
        randomNumberGenerator = new System.Random();
        remainingFighters = fighters.Length;

        SlowMo();
        ChooseFighter(Fighter.Status.Enemy, enemyFighterText);//1
        ChooseFighter(Fighter.Status.Friend, friendFighterText);//2
        ChooseFighter(Fighter.Status.Enemy, enemyFighterText);
    }

    /* 2 Checks that the next opponent being chosen is not already a friend
     * It does this by chosing a random fighter and making sure it's not already a friend
     * 
     * 3 Once the fighter has been chosen, assume it's going to be beaten and become a friend,
     * and then update the text to show who it is
     */
    internal string ChooseFighter(Fighter.Status desiredStatus, Text displayText)
    {
        int i = 0;
        do//2
        {
            randomNumber = randomNumberGenerator.Next(0, fighters.Length);
            chosenFighter = fighters[randomNumber];

            i++;
            if (i > 1000) throw new UnityException("Got stuck in an infinite while loop");
        } while (chosenFighter.status != desiredStatus);

        fighters[randomNumber].status = Fighter.Status.Friend;//3
        displayText.text = chosenFighter.name;

        remainingFighters--;

        return chosenFighter.name;
    }

    internal void SlowMo()
    {
        float randomNumber = UnityEngine.Random.value;

        if (randomNumber < slowMoChance)
             slowMoText.text = "SLOW MOTION";
        else slowMoText.text = "";
    }

    /* TODO: Right now it lets the player know there's a squad strike, 
     * but it picks from the top of the list every time.  Randomize that.
     */
    /// <summary>
    /// Groups the final fighters for a squad strike
    /// </summary>
    /// <returns></returns>
    internal string ArrangeSquadStrike()
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
