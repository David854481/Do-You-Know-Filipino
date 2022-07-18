using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    private int tries = 3;

    public GameplayUI GameplayUI { get; set; }
    public float Score { get; set; }
    public int Tries { get { return tries;  } }
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
        if (tries > 0)
        {
            AudioManager.Instance.Play("GameplayBGM");
            return;
        }
        else GameOver();
    }

    private void AddScore()
    {
        Score += 1;
        GameplayUI.UpdateScoreUI(Score);
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
        //should check first if the current score beat the highscore

        //reset the values for the next game
        Score = 0;
        tries = 3;
    }
}
