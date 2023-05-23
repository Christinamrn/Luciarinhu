using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerDrawer : OuvertureTiroir
{
    public GameObject hammer;

    public override void OnMouseDown()
    {
        if(!A20_Manager.instance.silverlock_opened) return;
        if(TiroirFerme.activeSelf){
            TiroirFerme.SetActive(false);
            TiroirOuvert.SetActive(true);
            if(!A20_Manager.instance.hammer_taken) hammer.SetActive(true);
        }else{
            TiroirFerme.SetActive(true);
            TiroirOuvert.SetActive(false);
            if(!A20_Manager.instance.hammer_taken) hammer.SetActive(false);
        }
    }
}
