using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CategoryUI : MonoBehaviour
{
    [Header("HighScoreText UI")]
    [SerializeField] private TextMeshProUGUI highScoreFoodUI;
    [SerializeField] private TextMeshProUGUI highScoreLiteratureUI;
    [SerializeField] private TextMeshProUGUI highScoreEventsUI;
    [SerializeField] private TextMeshProUGUI highScorePlacesUI;
    [SerializeField] private TextMeshProUGUI highScoreAnimalsUI;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateHighScoreUI();

        if(PlayerPrefs.GetInt("isNewGame", 0) != 1)
            PlayerPrefs.SetInt("isNewGame", 0);
        PlayerPrefs.Save();
    }

    public void UpdateHighScoreUI()
    {
        highScoreFoodUI.text = PlayerPrefs.GetInt("highScoreFood").ToString();
        highScoreLiteratureUI.text = PlayerPrefs.GetInt("highScoreLiterature").ToString();
        highScoreEventsUI.text = PlayerPrefs.GetInt("highScoreEvents").ToString();
        highScorePlacesUI.text = PlayerPrefs.GetInt("highScorePlaces").ToString();
        highScoreAnimalsUI.text = PlayerPrefs.GetInt("highScoreAnimals").ToString();
    }
}
