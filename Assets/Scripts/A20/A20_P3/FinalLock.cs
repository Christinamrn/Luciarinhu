using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLock : ItemReceiver
{
    void Update()
    {
        if(hasAccepted) A20_Manager.instance.finalLock_opened = true;
    }
}
