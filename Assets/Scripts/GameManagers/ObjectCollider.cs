using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{
    public LevelLoader loader;
    public int SceneIndex;

    void OnMouseDown()
    {
        if(!UIController.isGamePaused) loader.LoadLevelAt(SceneIndex);
    }
}
