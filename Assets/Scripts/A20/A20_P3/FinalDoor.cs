using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : ObjectCollider
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(A20_Manager.instance.finalLock_opened);
    }
    
}
