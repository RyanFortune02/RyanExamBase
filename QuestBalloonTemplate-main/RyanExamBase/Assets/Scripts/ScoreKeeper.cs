using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    //Overall Zen Score
    public int ZenScore;
    public Text ZenScoreText;
    //Rock Score
    public int RockScore = 0;
    public Text RockScoreText;
    //Paperfloat Score
    public int LanternScore = 5; //Decreasing score
    public Text LanternScoreText;
    //DogFollow Score
    public int DogScore;
    public Text DogScoreText;

    public Text MessageText;

    public void IncrementRockScore()
    {
        RockScore += 1;
        UpdateScoreDisplay();
        if (RockScore == 9)  //Touch 3 rocks increase zen score
        {
            IncrementZenScore();
        }
    }

    public void DecrementLanternScore()
    {
        LanternScore -= 1;
        UpdateScoreDisplay();
        if (LanternScore < 5)
        {
            MessageText.text = "Peace";
        }
        if (LanternScore == 0)  //Counter goes backwards
        {
            IncrementZenScore(); //Light 5 lanterns increase zen score
        }
    }

    public void IncrementDogScore()
    {
        DogScore += 1;
        UpdateScoreDisplay();
        if (DogScore == 1)
        {
            MessageText.text = "Having a beautiful day";
        }
        if (DogScore == 1) //Condition to increase zen score 1
        {
            IncrementZenScore();
        }
    }

    public void IncrementZenScore()
    {
        ZenScore += 1;
        UpdateScoreDisplay();
        if (ZenScore == 3)  //Set to two until score add for dog works
        {
            LoadScene("EndScreen"); //Load end screen
        }
    }

    public void UpdateScoreDisplay()
    {
        RockScoreText.text = "Rock Counter: " + RockScore;
        ZenScoreText.text = "Zen Score: " + ZenScore;
        LanternScoreText.text = "Lantern Counter: " + LanternScore;
        DogScoreText.text = "Dog Score: " + DogScore;
        /*
        if (LanternScore < 5)
        {
            MessageText.text = "Peace";
        }

        if (DogScore == 1)
        {
            MessageText.text = "Having a beautiful day";
        }
        
        */
    }
    //Load next scene by name
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    //Initilaize Score Display with text
    void Start()
    {
        UpdateScoreDisplay();
    }
}
