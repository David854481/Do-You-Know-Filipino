using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void switchScene(int sceneID)
    {
        switch (sceneID)
        {
            case 0: //To MainMenu Scene
                //Switches to the MainMenu screen
                SceneManager.LoadScene("MainMenu");
                break;
            case 1: //To CategoryMenu Scene
                //Switches to the Results screen
                SceneManager.LoadScene("CategoryMenu");
                AudioManager.Instance.Play("ButtonPressSfx");
                AudioManager.Instance.Stop("GameplayBGM");
                GameController.Instance.ResetGame();
                break;
            case 2: //To DoYouKnowFilipino Scene
                //Sets category information for main game
                PlayerPrefs.SetString("currentCategory", GameController.Instance.currentCategory);
                PlayerPrefs.Save();
                CategoryStatic.CategoryInformation = PlayerPrefs.GetString("currentCategory"); //change test to a dynamic variable
                //Switches to the MainGame screen
                SceneManager.LoadScene("Do You Know Filipino");
                AudioManager.Instance.Play("ButtonPressSfx");
                AudioManager.Instance.Play("GameplayBGM");
                break;
            case 3: //To Results Screen
                //Set the score to the playerpref or database something that holds the scores

                //Switches to the Results screen
                SceneManager.LoadScene("Results");
                AudioManager.Instance.Stop("GameplayBGM");
                break;
        }
    }

    public void setCategoryValue(string category)
    {
        GameController.Instance.currentCategory = category;
    }
}
