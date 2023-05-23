using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool isMoving = false;
    private float moveSpeed = 2f;
    private float returnSpeed = 3f;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = GetComponent<Collider2D>();
            if (collider.OverlapPoint(mousePos)) {
                isMoving = true;
                moveSpeed = Mathf.Abs(moveSpeed);
            }
        }

        if (isMoving) {
            transform.position -= new Vector3(0, Time.deltaTime * moveSpeed, 0);

            if (transform.position.y < initialPosition.y - 1) {
                moveSpeed = -returnSpeed;
            } else if (transform.position.y > initialPosition.y) {
                isMoving = false;
                transform.position = initialPosition;
            }
        }
    }
}
