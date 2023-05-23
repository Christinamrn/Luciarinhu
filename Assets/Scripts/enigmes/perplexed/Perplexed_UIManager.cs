using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Perplexed_UIManager : MonoBehaviour
{
    public List<Sprite> sprites_normal;

    public Perplexed_Manager manager;

    List<int> button_values;

    // Start is called before the first frame update
    void Start()
    {
        button_values = new List<int>();
        for(int i = 0; i < 8; i++)
        {
            Button button = gameObject.GetComponentsInChildren<Button>()[i];
            button.GetComponent<Image>().sprite = sprites_normal[0];
            button_values.Add(0);
        }
    }

    public void OnDigitClicked()
    {
        GameObject digit = EventSystem.current.currentSelectedGameObject;
        int index = digit.transform.GetSiblingIndex();
        if(button_values[index] == 9) button_values[index] = 0;
        else button_values[index] ++;
        UpdateManagerMatrix();
        UpdateSprites();
    }

    void UpdateManagerMatrix()
    {
        int number0 = button_values[0] * 10 + button_values[1];
        int number1 = button_values[2] * 10 + button_values[3];
        int number2 = button_values[4] * 10 + button_values[5];
        int number3 = button_values[6] * 10 + button_values[7];

        manager.ModifyMatrix(0,0,number0);
        manager.ModifyMatrix(1,0,number1);
        manager.ModifyMatrix(0,1,number2);
        manager.ModifyMatrix(1,1,number3);
    }

    void UpdateSprites()
    {
        for(int i = 0; i < 8; i++)
        {
            Button button = gameObject.GetComponentsInChildren<Button>()[i];
            button.GetComponent<Image>().sprite = sprites_normal[button_values[i]];
        }
    }
}
