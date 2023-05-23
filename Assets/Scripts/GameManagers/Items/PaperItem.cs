using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "Paper", menuName = "Inventory/Paper")]
public class PaperItem : Item
{
    public Sprite number;
    public Sprite sprite_tampon;
    public override void Use()
    {
        GameObject paperview = GameObject.Find("Inventory_Canvas");
        GameObject inGameUI = GameObject.Find("UI");
        if(inGameUI == null) inGameUI = GameObject.Find("UIZoomed");
        inGameUI.SetActive(false);
        GameObject codeUI = GameObject.Find("CodeUI");
        if(codeUI != null) codeUI.transform.GetChild(0).gameObject.SetActive(false);
        paperview.transform.Find("Background").gameObject.SetActive(true);
        paperview.transform.Find("Button").gameObject.SetActive(true);
        paperview.transform.Find("Paper").gameObject.SetActive(true);
        Image number_image = paperview.transform.Find("Paper").Find("Number").gameObject.GetComponent<Image>();
        number_image.GetComponent<Image>().sprite = number;
        number_image.preserveAspect = true;
        number_image.SetNativeSize();
        Image tampon = paperview.transform.Find("Paper").Find("Tampon").gameObject.GetComponent<Image>();
        tampon.GetComponent<Image>().sprite = sprite_tampon;
        tampon.preserveAspect = true;
        tampon.SetNativeSize();
        UIController.isGamePaused = true;
        Inventory.instance.UnSelect();

    }
}
