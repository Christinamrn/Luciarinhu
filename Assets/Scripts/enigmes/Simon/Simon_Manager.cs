using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon_Manager : MonoBehaviour
{

    // lights in this order red blue yellow green
    public List<Animator> lights;

    List<List<int>> sequences;
    int currentButton;
    int currentSequence;

    IEnumerator currentPlaying;
    bool isRolling;

    bool isCompleted;


    // Start is called before the first frame update
    void Start()
    {
        sequences = new List<List<int>>();
        sequences.Add(Sequence_Randomizer.Randomize(3));
        sequences.Add(Sequence_Randomizer.Randomize(4));
        sequences.Add(Sequence_Randomizer.Randomize(5));
        currentButton = 0;
        currentSequence = 0;
        currentPlaying = PlaySequence(currentSequence);
        StartCoroutine(currentPlaying);
        isRolling = false;
    }

    public void SetPressed(int index)
    {
        if(isCompleted) return;
        StopCoroutine(currentPlaying);
        lights[index].SetTrigger("Switched");
        HandlePress(index);
    }

    void HandlePress(int index)
    {
        if(isCompleted) return;
        if(sequences[currentSequence][currentButton] == index)
        {
            if(currentSequence == sequences.Count - 1 && (currentButton == sequences[currentSequence].Count - 1))
            {
                isCompleted = true;
                currentPlaying = PlayRoll();
                StartCoroutine(currentPlaying);
                Debug.Log("Completed");
                return;
            }
            if(currentButton == sequences[currentSequence].Count - 1)
            {
                currentSequence++;
                currentButton = 0;
                currentPlaying = PlayRoll();
                StartCoroutine(currentPlaying);
            }
            else currentButton++;
            
        }
        else
        {
            currentButton = 0;
            currentPlaying = PlaySequence(currentSequence);
            StartCoroutine(currentPlaying);
        }
    }

    IEnumerator PlaySequence(int indexSequence)
    {
        yield return new WaitForSeconds(2.0f);

        for(int i = 0; i<sequences[indexSequence].Count; i++)
        {
            lights[sequences[indexSequence][i]].SetTrigger("Switched");
            yield return new WaitForSeconds(0.8f);
        }
    }

    IEnumerator PlayRoll()
    {
        yield return new WaitForSeconds(0.3f);
        for(int k = 0; k<2;k++)
        {
            for(int i = 0; i<lights.Count; i++)
            {
                lights[i].SetTrigger("Switched");
                yield return new WaitForSeconds(0.1f);
            }
        }
        if(!isCompleted)
        {
            currentPlaying = PlaySequence(currentSequence);
            StartCoroutine(currentPlaying); 
        }
        
    }

}
