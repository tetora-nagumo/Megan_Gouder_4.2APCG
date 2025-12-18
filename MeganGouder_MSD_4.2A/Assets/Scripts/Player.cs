using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float padding = 1f;
    float xMin, xMax, yMin, yMax;
    [SerializeField] int playerHealth = 100;

    [SerializeField] GameObject deathVFX;

    [SerializeField] float explosionTime;

    [SerializeField] AudioClip PlayerHurt;

    [SerializeField] AudioClip PlayerDie;

    [SerializeField][Range(0,1)] float PlayerVolume = 0.75f;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if(damageDealer!=null)
        {
            ProcessHit(damageDealer);
        }

    }

    private void ProcessHit(DamageDealer damageDealer)
    {

          Debug.Log("Player hit for: " + damageDealer.GetDamage());


        playerHealth -= damageDealer.GetDamage();
        AudioSource.PlayClipAtPoint(PlayerHurt,Camera.main.transform.position,PlayerVolume);

        damageDealer.Hit();
        Debug.Log("Player health now: " + playerHealth);
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(PlayerDie,Camera.main.transform.position,PlayerVolume);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, 1f);
        FindAnyObjectByType<level>().LoadGameOver();

    }
}
