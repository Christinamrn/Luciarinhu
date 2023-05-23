using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPaperController : MonoBehaviour
{
    public Item attached;

    void OnMouseDown()
    {
        Inventory.instance.AddItem(attached);
        gameObject.SetActive(false);
        A20_Manager.instance.wheel_paper_taken = true;
    }
}
