using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    private bool completed = false;
    private float margin = 0.05f;
    private Vector3 _lastMousePosition;
    public float rotationSpeed = 10.0f;
    public float maxRotationAngle = 360.0f;
    public float minMouseDelta = 0.1f; // Mouvement minimal de la souris pour appliquer une rotation
    public Sprite[] spriteArray;

    private GameObject managerObject;
    private WheelManager manager;
    private int index;

    private void SetRandomSprite(int n)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent <SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[n - 1];
    }

    private void Start()
    {
        managerObject = GameObject.Find("Manager");
        manager = managerObject.GetComponent<WheelManager>();
        int random_set = manager.random_set;
        SetRandomSprite(random_set);
        float random_rotation = Random.Range(0.0f, 360.0f);
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, random_rotation);
        string name = gameObject.name;
        if (name == "Wheel_2")
            index = 2;
        if (name == "Wheel_3")
            index = 3;
        if (name == "Wheel_4")
            index = 4;
    }

    private void OnMouseDown()
    {
        _lastMousePosition = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        _lastMousePosition = Input.mousePosition;
        Quaternion currentRotation = transform.rotation;
        float rotationValue = currentRotation[2];
        if ((rotationValue > (0.0f - margin)) && (rotationValue < (0.0f + margin)))
        {
            completed = true;
            manager.SetWheelCorrect(index);
        }
    }

    private void OnMouseDrag()
    {
        if (!completed)
        {
            // Calcul de la différence de position entre la souris et le centre de l'objet
            Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mouseDelta = Input.mousePosition - objectPosition;

            // Vérification si le mouvement de la souris est suffisant pour appliquer une rotation
            if (mouseDelta.magnitude < minMouseDelta) return;

            // Calcul de l'angle entre la direction de la souris et la direction de l'objet
            float angle = Vector3.Angle(transform.right, mouseDelta);

            // Calcul de la quantité de rotation à appliquer en fonction de l'angle
            float rotationAmount = angle * rotationSpeed * Time.deltaTime;
            rotationAmount = Mathf.Clamp(rotationAmount, -maxRotationAngle, maxRotationAngle);

            // Calcul de la direction de la rotation
            Vector3 cross = Vector3.Cross(transform.right, mouseDelta);
            float direction = Mathf.Sign(cross.z);

            // Rotation de l'objet
            transform.Rotate(Vector3.forward, direction * rotationAmount, Space.World);

            // Mise à jour de la dernière position de la souris
            _lastMousePosition = Input.mousePosition;
        }
    }
}