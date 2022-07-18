using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayUI : MonoBehaviour
{
    [Header("Game UI")]
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private Image[] tryBar;
    [SerializeField] private GameObject imageCategoryItem;

    [Header("Answer Reveal UI")]
    [SerializeField] private GameObject answerRevealOverlay;
    [SerializeField] private TextMeshProUGUI answerRevealText;
    [SerializeField] private Image answerRevealImage;
    [SerializeField] private Sprite correctAnswerImage;
    [SerializeField] private Sprite wrongAnswerImage;

    public void UpdateScoreUI(float score)
    {
        scoreUI.text = score.ToString();
    }

    public void DisableTryBar(int tries)
    {
        tryBar[tries].enabled = false;
    }

    public void ShowAnswerReveal(bool answer)
    {
        SetAnswerReveal(answer);
        PlayAnswerRevealAudio(answer);
        answerRevealOverlay.SetActive(true);
    }

    private void Start()
    {
        GameController.Instance.GameplayUI = this;
        UpdateScoreUI(GameController.Instance.Score);

        //i being the initial number of attempts provided by the game minus the array index
        for (int i = 2; i > GameController.Instance.Tries - 1; i--)
            DisableTryBar(i);

        GameController.Instance.CheckRemainingTries();
    }

    private void SetAnswerReveal(bool answer)
    {
        if (answer)
        {
            answerRevealText.text = "Your\nAnswer\nis\nCorrect!";
            answerRevealImage.sprite = correctAnswerImage;
        }
        else
        {
            answerRevealText.text = "Your\nAnswer\nis\nWrong!";
            answerRevealImage.sprite = wrongAnswerImage;
        }
    }

    private void PlayAnswerRevealAudio(bool answer)
    {
        AudioManager.Instance.Stop("GameplayBGM");
        if (answer)
        {
            AudioManager.Instance.Play("RightAnswerSfx");
        }
        else
        {
            AudioManager.Instance.Play("WrongAnswerSfx");
        }
    }
}
