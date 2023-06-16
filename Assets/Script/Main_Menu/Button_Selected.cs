using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Button_Selected : MonoBehaviour
{
    public void OnNewGameButton()
    {
        SceneManager.LoadScene("Level_Select");
    }

    public void OnLoadGameButton()
    {
        
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
