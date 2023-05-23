using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperController : MonoBehaviour
{
    public Item attached;
    void OnMouseDown()
    {
        Inventory.instance.AddItem(attached);
        gameObject.SetActive(false);
        A20_Manager.instance.bottle_paper_taken = true;
    }
}
