using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public Item attached;
    void OnMouseDown()
    {
        Inventory.instance.AddItem(attached);
        gameObject.SetActive(false);
        A20_Manager.instance.hammer_taken = true;
    }
}
