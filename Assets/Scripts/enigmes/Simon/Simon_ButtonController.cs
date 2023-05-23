using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon_ButtonController : MonoBehaviour
{
    public Animator anim;
    public int index; //color
    public Simon_Manager manager;
    public void OnMouseDown()
    {
        manager.SetPressed(index);
        anim.SetTrigger("Pressed");
    }
}
