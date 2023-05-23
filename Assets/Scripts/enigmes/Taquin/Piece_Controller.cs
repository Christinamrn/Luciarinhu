using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Controller : MonoBehaviour
{
    public Taquin_Manager manager;
    public void OnMouseDown()
    {
        Vector2 position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if(manager.IsMoveAvailable(position))
        {
            manager.Move(gameObject.transform.GetSiblingIndex());
        }
    }
}
