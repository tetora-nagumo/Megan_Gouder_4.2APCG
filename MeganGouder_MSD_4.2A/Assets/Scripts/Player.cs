using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float padding = 1f;
    float xMin, xMax, yMin, yMax;
    void Start()
    {
        Boundaries();
    }


    void Update()
    {
        Move();
    }


    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime*moveSpeed; 
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        transform.position = new Vector2(newXPos, transform.position.y);

    }

    private void Boundaries()
    {
        //boundaries based on the camera
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;



    }
}
