using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitController : MonoBehaviour
{
    public bool isModifiable;
    public int m_value = 1;
    public List<Sprite> digits;
    public bool isChanged;
    public Vector2 index;
    public void OnMouseDown()
    {
        if(!isModifiable) return;
        m_value = (m_value == 9)? 1 : m_value+1;
        gameObject.GetComponent<SpriteRenderer>().sprite = digits[m_value-1];
        isChanged = true;
    }
}
