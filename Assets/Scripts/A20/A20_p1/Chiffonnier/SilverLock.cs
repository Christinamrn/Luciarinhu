using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverLock : ItemReceiver
{
    bool hasMoved;

    void Awake()
    {
        if(A20_Manager.instance.silverlock_opened)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0.53f, 0.0f, 0.0f);
            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
            renderer.sprite = afterUse;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(hasAccepted) A20_Manager.instance.silverlock_opened = true;
        if(!hasMoved && A20_Manager.instance.silverlock_opened)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0.53f, 0.0f, 0.0f);
            hasMoved = true;
            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
            renderer.sprite = afterUse;

        }
    }
}
