using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    private UIController uiController;

    private int tries = 3;
    private int score;

    public UIController UIController { set { uiController = value;  } }
    public void CheckPlayerAnswer(bool playerAnswer, bool itemAnswer)
    {
        var isPlayerCorrect = playerAnswer && itemAnswer;
        if (isPlayerCorrect)
            AddScore();
        else
            RemoveTries();

        uiController.EnableAnswerReveal(isPlayerCorrect);
    }

    private void AddScore()
    {
        score += 1;
    }

    private void RemoveTries()
    {
        if (tries > 0)
        {
            uiController.DisableTryBar(tries);
            tries -= 1;
        }
        else
            GameOver();
    }

    private void GameOver()
    {

    }
}
