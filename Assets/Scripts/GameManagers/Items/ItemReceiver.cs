using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* An item receiver is a object on which you can use a specific item. A lock for example */
public class ItemReceiver : MonoBehaviour
{
    public bool hasAccepted = false;
    public int accepted;

    public Sprite beforeUse;
    public Sprite afterUse;

    void Start()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = hasAccepted ? afterUse : beforeUse;
    }

    public virtual bool Accept(int id)
    {
        hasAccepted = (accepted == id);
        return hasAccepted;
    }

    public virtual void OnMouseDown()
    {
        if(Inventory.instance.selectedItem == null) return;
        bool used = Accept(Inventory.instance.selectedItem.id);
        if(used) Use();
        else Inventory.instance.UnSelect();
    }

    public virtual void Use()
    {
        Inventory.instance.RemoveItem(Inventory.instance.selectedItem);
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = afterUse;
    }
}
