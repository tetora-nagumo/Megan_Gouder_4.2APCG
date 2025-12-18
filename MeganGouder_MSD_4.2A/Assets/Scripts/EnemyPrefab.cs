using UnityEngine;

public class EnemyPrefab : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject deathVFX;

    [SerializeField] float explosionTime = 1f;

    [SerializeField] AudioClip EnemyDestroy;

    [SerializeField] AudioClip EnemyHurt;

    [SerializeField] [ Range(0,1)] float enemyVolume = 0.75f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (collision.gameObject.CompareTag("Player"))
        {
            Die();
        }
        else if(damageDealer!=null)
        {
            ProcessHit(damageDealer);
        }

    }

    private void ProcessHit(DamageDealer damageDealer)
    {

        health -= damageDealer.GetDamage();
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
    
}
