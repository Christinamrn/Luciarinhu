using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookDrawer : OuvertureTiroir
{
    public GameObject book;
    public OuvertureTiroir aboveDrawer;

    void Update()
    {
        book.SetActive(!A20_Manager.instance.book_taken && TiroirOuvert.activeSelf && aboveDrawer.TiroirFerme.activeSelf && !aboveDrawer.TiroirOuvert.activeSelf);
    }

    public override void OnMouseDown()
    {
        if(!A20_Manager.instance.silverlock_opened) return;
        if(TiroirFerme.activeSelf){
            TiroirFerme.SetActive(false);
            TiroirOuvert.SetActive(true);
            if(!A20_Manager.instance.book_taken && aboveDrawer.TiroirFerme.activeSelf) book.SetActive(true);
        }else{
            TiroirFerme.SetActive(true);
            TiroirOuvert.SetActive(false);
            if(!A20_Manager.instance.book_taken) book.SetActive(false);
        }
    }
}
