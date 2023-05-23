using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_Randomizer : MonoBehaviour
{
    public static List<int> Randomize(int size)
    {
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        List<int> sequence = new List<int>();
        for(int i = 0; i<size; i++)
        {
            int button = (int)UnityEngine.Random.Range(0, 4);
            sequence.Add(button);
        }
        return sequence;

    }
}
