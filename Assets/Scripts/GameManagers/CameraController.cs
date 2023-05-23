using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    private Vector3 origin, difference;
    private Transform reset;
    private bool isInSlideMode = false;

    private bool isDragged;

    // Start is called before the first frame update
    void Start()
    {
        reset = Camera.main.transform;
    }

    
    void LateUpdate()
    {
        if(isInSlideMode)
        {
            if(Input.GetMouseButton(1))
            {
                difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
                if(!isDragged)
                {
                    isDragged = true;
                    origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            } else isDragged = false;

            if(isDragged) 
            {
                float X_offset = Math.Max(-18.2659f, Math.Min((origin - difference).x, 18.2659f));
                Camera.main.transform.position = new Vector3(X_offset,Camera.main.transform.position.y, Camera.main.transform.position.z);
            }
        }
        else {
            if(Input.GetMouseButton(1))
            {
                if(((Camera.main.transform.eulerAngles.y + Input.GetAxis("Mouse X")) <= 8.0f || (Camera.main.transform.eulerAngles.y + Input.GetAxis("Mouse X"))>= 354.0f) &&
                    ((Camera.main.transform.eulerAngles.x + Input.GetAxis("Mouse Y")) <= 8.0f || (Camera.main.transform.eulerAngles.x + Input.GetAxis("Mouse Y")) >= 354.0f)) 

                    Camera.main.transform.eulerAngles += new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            } 
        }

    }
}
