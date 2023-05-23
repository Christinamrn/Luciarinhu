using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameController : MonoBehaviour
{
    public Animator anim;
    private A20_Manager a20_manager;
    bool left_or_right;

    void Awake()
    {
        GameObject a20ManagerObject = GameObject.Find("A20_Manager");
        a20_manager = a20ManagerObject.GetComponent<A20_Manager>();
        left_or_right = a20_manager.pianoGenerator.left_or_right;
    }

    void OnMouseDown()
    {
        if (left_or_right)
        {
            anim.SetTrigger("Fade_right");
        }
        else
        {
            anim.SetTrigger("Fade_left");
        }
    }
}
