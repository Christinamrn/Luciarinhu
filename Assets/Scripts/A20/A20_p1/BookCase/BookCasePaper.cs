using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCasePaper : MonoBehaviour
{
    public Item attached;

    void OnMouseDown()
    {
        if(!A20_Manager.instance.bookcase_completed) return;
        Inventory.instance.AddItem(attached);
        gameObject.SetActive(false);
        A20_Manager.instance.bookcase_paper_taken = true;
    }
}
