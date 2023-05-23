using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class UICodeLock : MonoBehaviour
{

    public static bool isCodeValid = false;
    public GameObject canvas;
    public void OnDigitClicked()
    {
        if(isCodeValid) return;
        GameObject digit = EventSystem.current.currentSelectedGameObject;
        int current = Int32.Parse(digit.GetComponentInChildren<TextMeshProUGUI>().text);
        int next;
        if(current == 9) next = 0;
        else next = current+1;
        digit.GetComponentInChildren<TextMeshProUGUI>().text = next.ToString();
        check();
    }

    private void check()
    {
        Button number0 = canvas.GetComponentsInChildren<Button>()[0];
        Button number1 = canvas.GetComponentsInChildren<Button>()[1];
        Button number2 = canvas.GetComponentsInChildren<Button>()[2];
        Button number3 = canvas.GetComponentsInChildren<Button>()[3];

        int n0, n1, n2, n3;
        n0 = Int32.Parse(number0.GetComponentInChildren<TextMeshProUGUI>().text);
        n1 = Int32.Parse(number1.GetComponentInChildren<TextMeshProUGUI>().text);
        n2 = Int32.Parse(number2.GetComponentInChildren<TextMeshProUGUI>().text);
        n3 = Int32.Parse(number3.GetComponentInChildren<TextMeshProUGUI>().text);

        if(n0 == 4 && n1 == 5 && n2 == 9 && n3 == 8)
        {
            isCodeValid = true;
            A20_Manager.instance.tableCode_correct = true;
        }

    }
}
