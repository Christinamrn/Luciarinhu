using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoCaccheController : MonoBehaviour
{
    public GameObject key;
    public Sprite opened;
    private bool completed;
    private bool is_opening;

    // Start is called before the first frame update
    void Start()
    {
        is_opening = false;
        key = GameObject.Find("A20_P2_cle_chiffonnier");

        if(A20_Manager.instance.piano_completed)
        {
            if(A20_Manager.instance.silver_key_taken)
                key.SetActive(false);
            transform.Translate(Vector3.left * 10);
            completed = true;
        }
        else
        {
            completed = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(A20_Manager.instance.piano_completed)
        {
            key.GetComponent<BoxCollider2D>().enabled = true;
            if (!completed)
            {
                completed = true;
                is_opening = true;
            }
        }

        if (is_opening)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 8);
            if (transform.position.x < -1)
                is_opening = false;
        }
    }
}
