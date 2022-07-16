using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    private int tries = 3;
    private int score;

    public UIController UIController { get; set; }
    public void CheckPlayerAnswer(bool playerAnswer, bool itemAnswer)
    {
        var isPlayerCorrect = playerAnswer && itemAnswer;
        if (isPlayerCorrect)
            AddScore();
        else
            RemoveTries();

        UIController.EnableAnswerReveal(isPlayerCorrect);
    }

    private void AddScore()
    {
        score += 1;
        UIController.UpdateScoreUI(score);
    }

    private void RemoveTries()
    {
        if (tries > 0)
        {
            tries -= 1;
            UIController.DisableTryBar(tries);

            if (tries <= 0)
                GameOver();
        }
    }

    private void GameOver()
    {

    }
}
