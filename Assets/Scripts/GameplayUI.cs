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

    private List<ItemSO> allItems = new List<ItemSO>();

    [Header("Game UI")]
    [SerializeField] private Image itemImage;
    [SerializeField] private Image triviaImage;
    [SerializeField] private TextMeshProUGUI triviaText;
    [SerializeField] private ImageSwipe imageSwipe;

    public SceneSwitch sceneSwitch;
    public MenuManager menuManager;
    public Panel tutorialPanel;

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
        GameController.Instance.CheckRemainingTries();

        UpdateScoreUI(GameController.Instance.Score);
        
        pickRandomItem();

        if (PlayerPrefs.GetInt("isNewGame") == 0)
        {
            PlayerPrefs.SetInt("isNewGame", 1);
            PlayerPrefs.Save();
            menuManager.SetCurrentWithHistory(tutorialPanel);
        }

        //i being the initial number of attempts provided by the game minus the array index
        for (int i = 2; i > GameController.Instance.Tries - 1; i--)
            DisableTryBar(i);
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

    private void pickRandomItem()
    {

        switch (PlayerPrefs.GetString("currentCategory"))
        {
            case "food":
                allItems.Clear();
                allItems.AddRange(Resources.LoadAll<ItemSO>("Items/Food/"));
                break;
            case "literature":
                allItems.Clear();
                allItems.AddRange(Resources.LoadAll<ItemSO>("Items/Literature/"));
                break;
            case "events":
                allItems.Clear();
                allItems.AddRange(Resources.LoadAll<ItemSO>("Items/Events/"));
                break;
            case "places":
                allItems.Clear();
                allItems.AddRange(Resources.LoadAll<ItemSO>("Items/Events/"));
                break;
            case "animals":
                allItems.Clear();
                allItems.AddRange(Resources.LoadAll<ItemSO>("Items/Animals/"));
                break;
        }
        randomItem();
    }

    public void randomItem()
    {
        int random = Random.Range(0, allItems.Count);
        itemImage.sprite = allItems[random].itemImage;
        triviaImage.sprite = allItems[random].itemImage;
        triviaText.text = allItems[random].itemTrivia;
        imageSwipe.ImageItemAnswer = allItems[random].isFilipino;

        Debug.Log(allItems.Count);
        Debug.Log("Item: " + allItems[random]);
    }

    public void gameOverTransition()
    {
        //Go to next screen
        sceneSwitch.switchScene(3);
    }
}
