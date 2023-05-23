using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeSwitchController : MonoBehaviour
{
    public Sprite light_on, light_off;

    public GameObject number;

    private bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        isOn = A20_Manager.instance.light_on;
        gameObject.GetComponent<SpriteRenderer>().sprite = isOn ? light_on : light_off;
        number.SetActive(A20_Manager.instance.light_on);
    }

    public void OnMouseDown()
    {
        if(isOn)
        {
            isOn = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = light_off;
            number.SetActive(isOn);
        }
        else
        {
            isOn = true ;
            gameObject.GetComponent<SpriteRenderer>().sprite = light_on;
            number.SetActive(isOn);
        }
        A20_Manager.instance.light_on = isOn;
    }


}
