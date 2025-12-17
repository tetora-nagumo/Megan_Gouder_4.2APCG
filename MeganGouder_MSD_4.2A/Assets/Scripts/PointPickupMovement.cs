using UnityEngine;

public class PointPickupMovement : MonoBehaviour
{
    public float pickUpSpeed = 5f;

    float xMin, xMax, yMax;
    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        SetBoundaries();

        
        float randomX = Random.Range(xMin, xMax);
        transform.position = new Vector3(randomX, yMax, 0);
    }

    void Update()
    {
        
        transform.Translate(Vector3.down * pickUpSpeed * Time.deltaTime);

        // Destroy when off screen
        float yMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        if (transform.position.y < yMin)
        {
            Destroy(gameObject);
        }
    }

    void SetBoundaries()
    {
        xMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMax = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }
}