using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKeyController : MonoBehaviour
{

    public Item attached;
    public void OnMouseDown()
    {
        Inventory.instance.AddItem(attached);
        gameObject.SetActive(false);
        A20_Manager.instance.golden_key_taken = true;
    }

   
}
