using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public void StartGame()
    {
        SceneSwitch sceneSwitch = new SceneSwitch();
        sceneSwitch.switchScene(1);
    }
}
