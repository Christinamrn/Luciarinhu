using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonTile : MonoBehaviour
{
    private SimonManager manager;
    private string tile_name;

    void Start()
    {
        GameObject managerObject = GameObject.Find("Manager");
        manager = managerObject.GetComponent<SimonManager>();
        string object_name = gameObject.name;
        tile_name = object_name.Remove(0, "A20_P2_piano_".Length);
    }

    void OnMouseDown()
    {
        manager.PressTile(tile_name);
        Debug.Log(tile_name);
    }
}
