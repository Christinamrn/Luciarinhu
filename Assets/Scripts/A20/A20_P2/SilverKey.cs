using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverKey : MonoBehaviour
{
    public Item attached;
    public void OnMouseDown()
    {
        Inventory.instance.AddItem(attached);
        gameObject.SetActive(false);
        A20_Manager.instance.silver_key_taken = true;
    }
}
