using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    private int tries = 3;

    public GameplayUI GameplayUI { get; set; }
    public int Score { get; private set; }
    public int Tries { get { return tries;  } }
    private List<ItemSO> allItems = new List<ItemSO>();
    public string currentCategory { get; set;}
    public void CheckPlayerAnswer(bool playerAnswer, bool itemAnswer)
    {
        var isPlayerCorrect = playerAnswer == itemAnswer;
        if (isPlayerCorrect)
            AddScore();
        else
            RemoveTries();

        GameplayUI.ShowAnswerReveal(isPlayerCorrect);
    }

    public void CheckRemainingTries()
    {
        if (tries > 0) return;
        else GameOver();
    }

    public void ResetGame()
    {
        Score = 0;
        tries = 3;
    }

    private void AddScore()
    {
        Score += 1;
        GameplayUI.UpdateScoreUI(Score);
        PlayerPrefs.SetInt("currentScore", Score);
        PlayerPrefs.Save();

        Debug.Log("Score: " + Score);
    }

    private void RemoveTries()
    {
        if (tries > 0)
        {
            tries -= 1;
            GameplayUI.DisableTryBar(tries);
        }
    }
    
    private void GameOver()
    {
        //Get category and check whether current score is higher than category high score
        switch (PlayerPrefs.GetString("currentCategory"))
        {
            case "food":
                if (Score > PlayerPrefs.GetInt("highScoreFood"))
                    PlayerPrefs.SetInt("highScoreFood", Score);
                break;
            case "literature":
                if (Score > PlayerPrefs.GetInt("highScoreLiterature"))
                    PlayerPrefs.SetInt("highScoreLiterature", Score);
                break;
            case "events":
                if (Score > PlayerPrefs.GetInt("highScoreEvents"))
                    PlayerPrefs.SetInt("highScoreEvents", Score);
                break;
            case "places":
                if (Score > PlayerPrefs.GetInt("highScorePlaces"))
                    PlayerPrefs.SetInt("highScorePlaces", Score);
                break;
            case "animals":
                if (Score > PlayerPrefs.GetInt("highScoreAnimals"))
                    PlayerPrefs.SetInt("highScoreAnimals", Score);
                break;
        }

        //Saves score for Results UI
        PlayerPrefs.SetString("currentCategory", PlayerPrefs.GetString("currentCategory"));
        PlayerPrefs.Save();

        //reset the values for the next game
        ResetGame();

        //ignore how i did this my brain turned off
        GameplayUI.gameOverTransition();
    }
}
