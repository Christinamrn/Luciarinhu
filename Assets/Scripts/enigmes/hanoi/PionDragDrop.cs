using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PionDragDrop : MonoBehaviour
{
    public TourDeHanoi tourDeHanoi;

    private bool isDragging = false;
    private Vector3 startPosition;
    private Transform originalParent;
    private float originalZPosition;

    private void OnMouseDown()
    {
        if (tourDeHanoi.jeuFini() == false){
            if (Input.GetMouseButtonDown(0))
            {
                // Vérifier si l'enfant est le dernier enfant de son parent
                if (transform.GetSiblingIndex() == transform.parent.childCount - 1)
                {
                    isDragging = true;
                    startPosition = transform.position;
                    originalParent = transform.parent;
                    originalZPosition = startPosition.z;
                    transform.SetParent(null); // Détacher l'enfant de son parent d'origine
                }
            }
        }
        else{
            return;
        }
        
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;

            // Vérifier s'il y a une collision avec un parent
            Collider2D[] collisions = Physics2D.OverlapPointAll(transform.position);

            foreach (Collider2D collision in collisions)
            {
                // Vérifier si le collider de collision appartient à un parent valide
                if (collision.gameObject != originalParent.gameObject && collision.gameObject.CompareTag("Tour"))
                {
                    // Vérifier si le nouveau parent a des enfants ou si le dernier enfant a un nom valide
                    if (collision.transform.childCount == 0 ||
                        IsLastChildNameValid(collision.transform.GetChild(collision.transform.childCount - 1).gameObject))
                    {
                        // Déplacer l'enfant vers le nouveau parent
                        if (collision.transform.childCount > 0)
                        {
                            // Placer le gameobject sur le haut du collider du dernier enfant du parent
                            Collider2D lastChildCollider = collision.transform.GetChild(collision.transform.childCount - 1).GetComponent<Collider2D>();
                            float yOffset = lastChildCollider.bounds.extents.y + transform.GetComponent<Collider2D>().bounds.extents.y - 0.15f;
                            Vector3 newPosition = lastChildCollider.bounds.center + new Vector3(0f, yOffset, 0f);
                            transform.position = newPosition;
                        }
                        else
                        {
                            // Placer de façon centrée sur le milieu du collider du parent
                            Vector3 parentCenter = collision.bounds.center;
                            float yOffset = collision.bounds.extents.y - 0.25f;
                            Vector3 newPosition = new Vector3(parentCenter.x, parentCenter.y - yOffset, originalZPosition);
                            transform.position = newPosition;
                        }

                        transform.SetParent(collision.transform);
                        tourDeHanoi.jeuFini();
                        return;
                    }
                }
            }

            // Si aucune collision avec un parent n'a été trouvée, revenir à la position d'origine
            transform.position = new Vector3(startPosition.x, startPosition.y, originalZPosition);
            transform.SetParent(originalParent);
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Suivre la position de la souris pour déplacer l'enfant
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = originalZPosition; // Conserver la position Z d'origine
            transform.position = mousePosition;
        }
    }

    private bool IsLastChildNameValid(GameObject lastChild)
    {
        string lastChar = lastChild.name.Substring(lastChild.name.Length - 1);
        string ownLastChar = gameObject.name.Substring(gameObject.name.Length - 1);

        // Vérifier si le dernier caractère du nom de l'enfant et du gameObject est "1", "2" ou "3"
        if ((lastChar == "1" || lastChar == "2" || lastChar == "3") &&
            (ownLastChar == "1" || ownLastChar == "2" || ownLastChar == "3"))
        {
            int lastChildValue = int.Parse(lastChar);
            int ownValue = int.Parse(ownLastChar);

            // Vérifier si la valeur du dernier caractère du gameObject est inférieure à celle du dernier enfant
            if (ownValue < lastChildValue)
            {
                return true;
            }
        }

        return false;
    }

    

}
