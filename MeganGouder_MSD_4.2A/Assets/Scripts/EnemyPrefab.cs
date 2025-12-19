using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class EnemyPrefab : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float health = 20;
    [Header("Effects")]
    [SerializeField] GameObject deathVFX;

    [SerializeField] float explosionTime = 1f;

    [SerializeField] AudioClip EnemyDestroy;

    [SerializeField] AudioClip EnemyHurt;

    [SerializeField][Range(0, 1)] float enemyVolume = 0.75f;


    [Header("Shooting")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject enemyLazerPrefab;
    [SerializeField] float enemyLazerSpeed = 1;




    private void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Die();
            return;
        }


        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            ProcessHit(damageDealer);
        }
    }


    private void ProcessHit(DamageDealer damageDealer)
    {

        Debug.Log("Enemy hit! Damage: " + damageDealer.GetDamage());
        health -= damageDealer.GetDamage();
        Debug.Log("Enemy health now: " + health);
        AudioSource.PlayClipAtPoint(EnemyHurt, Camera.main.transform.position, enemyVolume);
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(EnemyDestroy, Camera.main.transform.position, enemyVolume);
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, explosionTime);
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            EnemyFire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }


    private void EnemyFire()
    {
        if (SceneManager.GetActiveScene().name == "KittyDefenderLvl2")
        {
            GameObject enemyLazer = Instantiate(enemyLazerPrefab, transform.position, Quaternion.identity) as GameObject;
            enemyLazer.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -enemyLazerSpeed);
        }



    }
}
