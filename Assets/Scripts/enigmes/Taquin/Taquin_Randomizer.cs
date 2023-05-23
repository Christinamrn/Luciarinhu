using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Taquin_Randomizer : MonoBehaviour
{

    public static List<Vector2> Randomize()
    {
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        List<Vector2> staticPositions = new List<Vector2>();
        List<Vector2> randomPositions = new List<Vector2>();
        for (int i =1; i>-2; i--)
        {
            for (int j =-1; j<2; j++) 
            {
                staticPositions.Add(new Vector2(j*2.43f, i*2.43f));
            }
        }
        Vector2 previousPos = new Vector2(-100.0f, -100.0f);
        for(int i = 0; i<8; i++)
        {
            int indexI = (int)UnityEngine.Random.Range(0, 7);
            while(randomPositions.Contains(staticPositions[indexI])){
                indexI = (indexI >0)? indexI - 1 : 7;
            }
            randomPositions.Add(staticPositions[indexI]);
        }

        return randomPositions;

    }

    
}
