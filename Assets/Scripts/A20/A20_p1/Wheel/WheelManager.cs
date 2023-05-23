using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelManager : MonoBehaviour
{
    protected bool _completed;
    SpriteRenderer openSpriteRenderer;
    SpriteRenderer paperSpriteRenderer;
    A20_Manager a20_manager;

    private bool _wheel_2_correct;
    private bool _wheel_3_correct;
    private bool _wheel_4_correct;
    
    public int random_set;

    private void Awake()
    {
        GameObject a20ManagerObject = GameObject.Find("A20_Manager");
        a20_manager = a20ManagerObject.GetComponent<A20_Manager>();
        _completed = A20_Manager.instance.wheel_completed;

        openSpriteRenderer = GameObject.Find("Wheel_open").GetComponent<SpriteRenderer>();
        paperSpriteRenderer = GameObject.Find("Wheel_paper").GetComponent<SpriteRenderer>();

        if (_completed) SetCompleted();
        else
        {
            openSpriteRenderer.enabled = false;
            paperSpriteRenderer.enabled = false;
        }
        random_set = Random.Range(1, 5);
    }

    private void Start()
    {
        _wheel_2_correct = false;
        _wheel_3_correct = false;
        _wheel_4_correct = false;
    }

    private void SetCompleted()
    {
        openSpriteRenderer.enabled = true;
        paperSpriteRenderer.enabled = !A20_Manager.instance.wheel_paper_taken;
    }

    private void CheckCorrect()
    {
        if (_wheel_2_correct && _wheel_3_correct && _wheel_4_correct)
        {
            _completed = true;
            A20_Manager.instance.wheel_completed = true;
            openSpriteRenderer.enabled = true;
            paperSpriteRenderer.enabled = true;
            Debug.Log("Enigme complétée !");
        }
    }

    public void SetWheelCorrect(int i)
    {
        if (i == 2)
            _wheel_2_correct = true;
        if (i == 3)
            _wheel_3_correct = true;
        if (i == 4)
            _wheel_4_correct = true;
        CheckCorrect();
    }
}
