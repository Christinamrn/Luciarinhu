using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController: MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject inGameUI;
    public LevelLoader loader;

    public void OnLeftArrowClicked()
    {
        loader.LoadNextLevel(-1);
    }

    public void OnRightArrowClicked()
    {
        loader.LoadNextLevel(1);
    }

    public void OnBackClicked()
    {
        if(isGamePaused)
        {
            pauseMenuUI.SetActive(false);
            inGameUI.SetActive(true);
            isGamePaused = false;
        }
        else loader.LoadPreviousLevel();
    }

    public void onMenuClicked()
    {
        pauseMenuUI.SetActive(true);
        inGameUI.SetActive(false);
        isGamePaused = true;
    }
}
