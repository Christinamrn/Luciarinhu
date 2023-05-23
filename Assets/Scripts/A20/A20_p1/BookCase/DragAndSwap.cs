using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndSwap : MonoBehaviour
{
    public GameObject[] objectsToAssign;
    public Collider2D[] collidersToAssign;


    private Vector3 initialPosition;
    private Vector3 finalPosition;
    private bool isDragging = false;
    private int initialIndex = -1;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if(A20_Manager.instance.bookcase_completed) return;
        if (GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            initialPosition = transform.position;
            initialIndex = -1;
            for (int i = 0; i < objectsToAssign.Length; i++)
            {
                if (objectsToAssign[i] == gameObject)
                {
                    initialIndex = i;
                    break;
                }
            }
            isDragging = true;
        }
    }

    private void OnMouseDrag()
    {
        if(A20_Manager.instance.bookcase_completed) return;

        if (isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            transform.position = Vector3.Lerp(transform.position, finalPosition, 0.1f);
        }
    }

    private void OnMouseUp()
    {
        if(A20_Manager.instance.bookcase_completed) return;
        
        isDragging = false;
        bool isColliding = false;

        for (int i = 0; i < objectsToAssign.Length; i++)
        {
            if (objectsToAssign[i] != gameObject && GetComponent<Collider2D>().IsTouching(collidersToAssign[i]))
            {
                Vector3 temp = objectsToAssign[i].transform.position;
                objectsToAssign[i].transform.position = initialPosition;
                transform.position = temp;
                isColliding = true;
                break;
            }
        }

        if (!isColliding)
        {
            if (initialIndex >= 0)
            {
                transform.position = initialPosition;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, initialPosition, 0.1f);
            }
        }
    }

    
    
}