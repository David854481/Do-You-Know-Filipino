using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsUI : MonoBehaviour
{
    [Header("CurrentScorePanel UI")]
    [SerializeField] private TextMeshProUGUI highScoreUI;
    [SerializeField] private TextMeshProUGUI currentScoreUI;
    [SerializeField] private TextMeshProUGUI currentScorePanelFlavorText;

    [Header("HighScorePanel UI")]
    [SerializeField] private TextMeshProUGUI highScore2UI;
    [SerializeField] private TextMeshProUGUI highScorePanelFlavorText;

    [Header("MenuManager Stuff")]
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private Panel normalResultsUI;
    [SerializeField] private Panel highScoreResultsUI;

    void Start()
    {
        updateUI();   
    }

    private void updateUI()
    {
        Debug.Log("Category: " + PlayerPrefs.GetString("currentCategory"));
        //High Score checker
        switch (PlayerPrefs.GetString("currentCategory"))
        {
            case "food":
                highScoreUI.text = PlayerPrefs.GetInt("highScoreFood").ToString();
                currentScoreUI.text = PlayerPrefs.GetInt("currentScore").ToString();
                highScore2UI.text = highScoreUI.text = PlayerPrefs.GetInt("highScoreFood").ToString();

                Debug.Log("SCORE: " + PlayerPrefs.GetInt("currentScore"));
                Debug.Log("HIGH SCORE: " + PlayerPrefs.GetInt("highScoreFood"));

                if (PlayerPrefs.GetInt("currentScore") >= PlayerPrefs.GetInt("highScoreFood"))
                {
                    menuManager.SetCurrentWithHistory(highScoreResultsUI);
                }
                break;
            case "literature":
                highScoreUI.text = PlayerPrefs.GetInt("highScoreLiterature").ToString();
                currentScoreUI.text = PlayerPrefs.GetInt("currentScore").ToString();
                highScore2UI.text = highScoreUI.text = PlayerPrefs.GetInt("highScoreLiterature").ToString();

                if (PlayerPrefs.GetInt("currentScore") >= PlayerPrefs.GetInt("highScoreLiterature"))
                {
                    menuManager.SetCurrentWithHistory(highScoreResultsUI);
                }
                break;
            case "events":
                highScoreUI.text = PlayerPrefs.GetInt("highScoreEvents").ToString();
                currentScoreUI.text = PlayerPrefs.GetInt("currentScore").ToString();
                highScore2UI.text = highScoreUI.text = PlayerPrefs.GetInt("highScoreEvents").ToString();

                if (PlayerPrefs.GetInt("currentScore") >= PlayerPrefs.GetInt("highScoreEvents"))
                {
                    menuManager.SetCurrentWithHistory(highScoreResultsUI);
                }
                break;
            case "places":
                highScoreUI.text = PlayerPrefs.GetInt("highScorePlaces").ToString();
                currentScoreUI.text = PlayerPrefs.GetInt("currentScore").ToString();
                highScore2UI.text = highScoreUI.text = PlayerPrefs.GetInt("highScorePlaces").ToString();

                if (PlayerPrefs.GetInt("currentScore") >= PlayerPrefs.GetInt("highScorePlaces"))
                {
                    menuManager.SetCurrentWithHistory(highScoreResultsUI);
                }
                break;
            case "animals":
                highScoreUI.text = PlayerPrefs.GetInt("highScoreAnimals").ToString();
                currentScoreUI.text = PlayerPrefs.GetInt("currentScore").ToString();
                highScore2UI.text = highScoreUI.text = PlayerPrefs.GetInt("highScoreAnimals").ToString();

                if (PlayerPrefs.GetInt("currentScore") >= PlayerPrefs.GetInt("highScoreAnimals"))
                {
                    menuManager.SetCurrentWithHistory(highScoreResultsUI);
                }
                break;
        }

        //Can't use switch-case sry i'm yandev :(
        //For flavor text
        if (PlayerPrefs.GetInt("currentScore") >= 0 && PlayerPrefs.GetInt("currentScore") <= 5)
        {
            currentScorePanelFlavorText.text = "You are a\n FOREIGNER";
            highScorePanelFlavorText.text = "You are a\n FOREIGNER";
        }

        else if (PlayerPrefs.GetInt("currentScore") >= 6 && PlayerPrefs.GetInt("currentScore") <= 10)
        {
            currentScorePanelFlavorText.text = "You are \n HALF FILIPINO";
            highScorePanelFlavorText.text = "You are \n HALF FILIPINO";
        }

        else if (PlayerPrefs.GetInt("currentScore") >= 11 && PlayerPrefs.GetInt("currentScore") <= 15)
        {
            currentScorePanelFlavorText.text = "You are \n FILIPINO";
            highScorePanelFlavorText.text = "You are \n FILIPINO";
        }

        else if (PlayerPrefs.GetInt("currentScore") >= 16)
        {
            currentScorePanelFlavorText.text = "You are a\n NATIVE ANTHROPOLOGIST";
            highScorePanelFlavorText.text = "You are a\n NATIVE ANTHROPOLOGIST";
        }
    }
}
