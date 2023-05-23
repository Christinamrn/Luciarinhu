using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OpenDrawer : MonoBehaviour
{
    public Animator openAnim;
    public static bool isOpen = false;
    public GameObject key;

    void Start()
    {
        openAnim.SetBool("Code", A20_Manager.instance.tableCode_correct);
        key.SetActive(false);
    }


    void OnMouseDown()
    {
        if(UIController.isGamePaused) return;
        
        if(isOpen)
        {
            openAnim.SetTrigger("Close");
            isOpen = false;
        }
        else 
        {
            if(A20_Manager.instance.tableCode_correct)
            {
                openAnim.SetTrigger("Open");
                isOpen = true;
                
            }
            
        }
    }

    void ShowKey()
    {
        if(!A20_Manager.instance.golden_key_taken) key.SetActive(A20_Manager.instance.tableCode_correct);
    }

    void HideKey()
    {
        key.SetActive(false);

    }

}
