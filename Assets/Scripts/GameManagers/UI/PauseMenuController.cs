using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject inGameUI;

    public void OnBackClicked()
    {
        
        inGameUI.SetActive(true);
        UIController.isGamePaused = false;
        pauseMenuUI.SetActive(false);
    }

    public void onSettingsClicked(){}

    public void onQuitClicked()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
