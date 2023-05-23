using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiblioManager : MonoBehaviour
{
    List<GameObject> books;
    List<GameObject> shapes;
    public List<Vector3> BooksPositions; // soluce
    public List<Vector3> ShapesPositions; //soluce 
    private bool isCompleted = false;
    private bool bookPlaced = false;

    public Animator door;
    // Start is called before the first frame update
    void Start()
    {
        books = new List<GameObject>();
        shapes = new List<GameObject>();
        BooksPositions = new List<Vector3>();
        ShapesPositions = new List<Vector3>();
        
        for(int i = 0; i<gameObject.transform.childCount; i++)
        {
            GameObject biblioObject = gameObject.transform.GetChild(i).gameObject;
            if(biblioObject.name.Contains("livre"))
            {
                books.Add(biblioObject);
                BooksPositions.Add(biblioObject.transform.position);

                if(i == A20_Manager.instance.index_missingBook && !A20_Manager.instance.book_placed)
                {
                    biblioObject.GetComponent<SpriteRenderer>().enabled = false;
                    biblioObject.GetComponent<BoxCollider2D>().enabled = false;
                }

            }
            else if(biblioObject.name.Contains("forme"))
            {
                shapes.Add(biblioObject);
                ShapesPositions.Add(biblioObject.transform.position);

            }
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!bookPlaced)
        {
            bookPlaced = A20_Manager.instance.book_placed;
            books[A20_Manager.instance.index_missingBook].GetComponent<SpriteRenderer>().enabled = bookPlaced;
            books[A20_Manager.instance.index_missingBook].GetComponent<BoxCollider2D>().enabled = bookPlaced;
        } 
        if(!isCompleted) 
        {
            isCompleted = Check();
            A20_Manager.instance.bookcase_completed = isCompleted;
            if(isCompleted) door.SetTrigger("Open");
        }
    }

    bool Check()
    {
        bool book_completed = true;
        bool shapes_completed = true;
        for (int i = 0; i<BooksPositions.Count; i++)
        {
            if(BooksPositions[i] != GameObject.Find("A20_P1_livre_vert_"+(i+1).ToString()).transform.position) book_completed = false;
        }
        for (int i = 0; i<ShapesPositions.Count; i++)
        {
            if(ShapesPositions[i] != GameObject.Find("A20_P1_formes_"+(i+1).ToString()).transform.position) shapes_completed = false;
        }

        return book_completed && shapes_completed;
    }

    public void SwapBooks(int index0, int index1)
    {
        GameObject tmp = books[index1];
        books[index1] = books[index0];
        books[index0] = tmp;

    }

    public void SwapShapes(int index0, int index1)
    {
        GameObject tmp = shapes[index1];
        shapes[index1] = shapes[index0];
        shapes[index0] = tmp;

    }
}
