using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleController : ItemReceiver
{
    public GameObject paper;
    
    void Start()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = A20_Manager.instance.bottle_broken ? afterUse : beforeUse;
        gameObject.transform.position = A20_Manager.instance.bottle_broken ? new Vector3(72.2f, 3.5f, 33.84f) : new Vector3(68.92f, 6.8f, 35.25f);
    }

    public override bool Accept(int id)
    {
        base.Accept(id);
        A20_Manager.instance.bottle_broken = hasAccepted;
        paper.SetActive(hasAccepted);
        if (hasAccepted) gameObject.transform.position = new Vector3(72.2f, 3.5f, 33.84f);
        return hasAccepted;
    }

    public override void OnMouseDown()
    {
        if(A20_Manager.instance.bottle_broken) return;
        base.OnMouseDown();
    }

}
