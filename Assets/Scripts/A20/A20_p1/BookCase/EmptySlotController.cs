using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySlotController : ItemReceiver
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(!A20_Manager.instance.book_placed);
    }

    public override bool Accept(int id)
    {
        base.Accept(id);
        A20_Manager.instance.book_placed = hasAccepted;
        return hasAccepted;
    }

    public override void Use()
    {
        Inventory.instance.RemoveItem(Inventory.instance.selectedItem);
        gameObject.SetActive(false);
    }

    
}
