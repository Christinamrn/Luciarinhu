using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public List<Item> content = new List<Item>();

    private List<Button> uiButtons;

    public Animator anim;
    private bool isOpen;

    private int selected;
    public Item selectedItem {get; set;}
    public bool hasSelectedItem;

    private bool modified;

    private GameObject selected_icon;

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one instance of inventory");
            return;
        }
        instance = this;

        uiButtons = new List<Button>();
        Canvas canvas = GetComponentInChildren<Canvas>();
        Component[] buttons = canvas.GetComponentsInChildren<Button>();
        foreach(Button button in buttons)
        {
            if(button.name != "Opener")
            {
                uiButtons.Add(button);
                button.gameObject.SetActive(false);
            }

        }
        isOpen = false;
        selected_icon = GameObject.Find("Selected");
        selected_icon.SetActive(false);
    }

    void Update()
    {
        if( !modified ) return;
        ResetUI();
        for(int i = 0; i<content.Count; i++)
        {
            if(content[i] == null) 
            {
                continue;
            }
            uiButtons[i].GetComponent<Image>().sprite = content[i].image;
            uiButtons[i].GetComponent<Image>().preserveAspect = true;
            uiButtons[i].gameObject.SetActive(true);
        }
        if(hasSelectedItem)
        {
            selected_icon.SetActive(true);
            selected_icon.transform.position = uiButtons[selected].transform.position;
        }
        modified = false;

    }

    private void ResetUI()
    {
        foreach(Button button in uiButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void AddItem(Item item)
    {
        if(content.Contains(item)) return;
        content.Add(item);
        modified = true;
    }

    public void RemoveItem(Item item)
    {
        UnSelect();
        uiButtons[content.IndexOf(item)].gameObject.SetActive(false);
        content.Remove(item);
        modified = true;
    }

    public void SelectItem(int index)
    {
        selected = index;
        selectedItem = content[selected];
        hasSelectedItem = true;
        selected_icon.SetActive(true);
        selected_icon.transform.position = uiButtons[selected].transform.position;
        selectedItem.Use();
        
    }

    public void Toggle()
    {
        if(isOpen)
        {
            anim.SetTrigger("Close");
            isOpen = false;
        }
        else
        {
            anim.SetTrigger("Open");
            isOpen = true;
        }
    }

    public void UnSelect()
    {
        selected = -1;
        selectedItem = null;
        hasSelectedItem = false;
        selected_icon.SetActive(false);
    }

    public void OnBackClicked()
    {
        Debug.Log("CLicked return");
        GameObject inGameUI = GameObject.Find("UISystem");
        if(inGameUI == null) inGameUI = GameObject.Find("UISystemZoomed");
        inGameUI.transform.GetChild(0).gameObject.SetActive(true);
        GameObject codeUI = GameObject.Find("CodeUI");
        if(codeUI != null) codeUI.transform.GetChild(0).gameObject.SetActive(true);
        UIController.isGamePaused = false;
        GameObject paperview = GameObject.Find("Inventory_Canvas");
        paperview.transform.Find("Background").gameObject.SetActive(false);
        paperview.transform.Find("Button").gameObject.SetActive(false);
        paperview.transform.Find("Paper").gameObject.SetActive(false);
    }

}
