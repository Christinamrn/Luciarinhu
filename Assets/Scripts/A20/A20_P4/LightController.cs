using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Sprite light_on, light_off;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = A20_Manager.instance.light_on ? light_on : light_off;
        gameObject.transform.position = A20_Manager.instance.light_on ? new Vector3(-46.4f, 30.84f, 49.4f) : new Vector3(-45.0f, 32.2f, 49.4f);
    }
}
