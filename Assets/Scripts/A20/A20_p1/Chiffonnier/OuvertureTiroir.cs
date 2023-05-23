using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuvertureTiroir : MonoBehaviour
{
    public GameObject TiroirFerme;
    public GameObject TiroirOuvert;

    void Start()
    {
        TiroirOuvert.SetActive(false);
        TiroirFerme.SetActive(true);
    }

    public virtual void OnMouseDown(){
        if(!A20_Manager.instance.silverlock_opened) return;
        if(TiroirFerme.activeSelf){
            TiroirFerme.SetActive(false);
            TiroirOuvert.SetActive(true);
        }else{
            TiroirFerme.SetActive(true);
            TiroirOuvert.SetActive(false);
        }
    }
}
