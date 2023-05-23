using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public LevelLoader loader;
    public void OnPlayClicked()
    {
        Debug.Log("Play");
        loader.LoadLevelAt(1);
    }

    public void OnQuitPlayed()
    {
        Application.Quit();
    }

    public void onOptionsClicked()
    {
        Debug.Log("Options");
    }
}
