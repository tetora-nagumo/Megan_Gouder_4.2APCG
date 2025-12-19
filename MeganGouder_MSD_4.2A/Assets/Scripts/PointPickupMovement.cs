using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PointPickupMovement : MonoBehaviour
{

    [SerializeField] AudioClip PickUp;

    [SerializeField][Range(0, 1)] float PickUpVol = 0.75f;
    public float pickUpSpeed = 5f;

    float xMin, xMax, yMax;
    Camera mainCamera;

    ScoreText scoreText;

    [HideInInspector] public PointPickUpSpawner spawner;

    void Start()
    {
        mainCamera = Camera.main;
        SetBoundaries();


        scoreText = FindAnyObjectByType<ScoreText>();


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
            if (spawner != null)
                spawner.PickupDestroyed();

            Destroy(gameObject);
        }
    }

    void SetBoundaries()
    {
        xMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMax = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            scoreText.AddPointsPickUp();
            AudioSource.PlayClipAtPoint(PickUp, Camera.main.transform.position, PickUpVol);
            if (spawner != null)
                spawner.PickupDestroyed();
            Destroy(gameObject);

        }

    }
}