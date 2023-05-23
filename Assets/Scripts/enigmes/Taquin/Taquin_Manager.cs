using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Taquin_Manager : MonoBehaviour
{
    public GameObject taquin;
    List<Vector2> positions;
    List<Vector2> expectedPositions;

    bool isCompleted = false;
    float increment;

    Vector2 empty;
    // Start is called before the first frame update
    void Start()
    {
        increment = 2.43f * taquin.transform.localScale.x;
        expectedPositions = new List<Vector2>();
        for (int i =1; i>-2; i--) 
        {
            for (int j =-1; j<2; j++) 
            {
                expectedPositions.Add(new Vector2(j*increment, i*increment));
            }
        }
        empty = expectedPositions[8];
        positions = Taquin_Randomizer.Randomize();
        for (int i = 0; i < positions.Count; i++) 
        {
            taquin.transform.GetChild(i).position = new Vector3(positions[i].x, positions[i].y, 0.0f);
        }
    }

    public bool IsMoveAvailable(Vector2 position)
    {
        return (position - empty).magnitude==increment;
    }

    public void Move(int siblingIndex)
    {
        if(isCompleted) return;
        Vector2 temp = positions[siblingIndex];
        positions[siblingIndex] = empty;
        empty = temp;
        taquin.transform.GetChild(siblingIndex).position = new Vector3(positions[siblingIndex].x, positions[siblingIndex].y, 0.0f);
        isCompleted = Check();

    }

    bool Check()
    {
        for (int i = 0; i < taquin.transform.childCount; i++) 
        {
            Vector2 position = new Vector2(taquin.transform.GetChild(i).position.x, taquin.transform.GetChild(i).position.y);
            if( position != expectedPositions[i]) return false;
        }
        Debug.Log("Completed");
        return true;
    }

}
