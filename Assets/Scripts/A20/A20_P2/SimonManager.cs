using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonManager : MonoBehaviour
{
    bool completed;
    string final_sequence;
    string current_sequence;
    A20_Manager a20_manager;

    void Awake()
    {
        GameObject a20ManagerObject = GameObject.Find("A20_Manager");
        a20_manager = a20ManagerObject.GetComponent<A20_Manager>();
    }

    void Start()
    {
        completed = false;
        final_sequence = a20_manager.pianoGenerator.sequence;
        current_sequence = "";
    }

    public void PressTile(string tile)
    {
        if (!completed)
        {
            current_sequence = current_sequence + tile;
            if (!final_sequence.StartsWith(current_sequence))
            {
                current_sequence = "";
            }
            if (current_sequence == final_sequence)
            {
                completed = true;
                A20_Manager.instance.piano_completed = true;
               
            }
        }
    }
}
