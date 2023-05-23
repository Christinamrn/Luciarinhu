using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public float transitionTime = 1f;
    public Animator transition;
    public static int previous = 0;

    public static Dictionary<int, int> history  = new Dictionary<int, int>();

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("left"))
        {
            LoadNextLevel(-1);
        }
        if(Input.GetKeyDown("right"))
            LoadNextLevel(1);
    }

    public void LoadNextLevel(int increment)
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex + increment;
        if(levelIndex >= 5) levelIndex = 1;
        else if(levelIndex < 1) levelIndex = 4;
        StartCoroutine(LoadLevel(levelIndex));
    }

    public void LoadPreviousLevel()
    {
        LoadLevelAt(history[SceneManager.GetActiveScene().buildIndex]);
    }

    public void LoadLevelAt(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        if(history.ContainsKey(levelIndex))
        {
            if(SceneManager.GetActiveScene().buildIndex < history[levelIndex])
            {
                history[levelIndex] = SceneManager.GetActiveScene().buildIndex; 
            }
        }
        else
        {
            history.Add(levelIndex, SceneManager.GetActiveScene().buildIndex);  
        }
        /*previous = SceneManager.GetActiveScene().buildIndex;
*/        
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
