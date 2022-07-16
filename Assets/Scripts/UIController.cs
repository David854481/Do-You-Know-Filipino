using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Game UI")]
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private Image[] tryBar;

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

    public void EnableAnswerReveal(bool answer)
    {
        SetAnswerReveal(answer);
        PlayAnswerRevealAudio(answer);
        answerRevealOverlay.SetActive(true);
    }

    private void Start()
    {
        GameController.Instance.UIController = this;
    }

    private void SetAnswerReveal(bool answer)
    {
        if (answer)
        {
            answerRevealText.text = "Your Answer is Correct!";
            answerRevealImage.sprite = correctAnswerImage;
        }
        else
        {
            answerRevealText.text = "Your Answer is Wrong!";
            answerRevealImage.sprite = wrongAnswerImage;
        }
    }

    private void PlayAnswerRevealAudio(bool answer)
    {
        if (answer)
        {
            //play correct answer audio
        }
        else
        {
            //play wrong answer audio
        }
    }
}
