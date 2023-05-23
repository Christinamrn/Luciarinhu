using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperView : MonoBehaviour
{

    public void OnBackClicked()
    {
        GameObject.Find("UISystem").SetActive(true);
        UIController.isGamePaused = false;
        GameObject.Find("PaperView/Background").SetActive(false);
    }
}
