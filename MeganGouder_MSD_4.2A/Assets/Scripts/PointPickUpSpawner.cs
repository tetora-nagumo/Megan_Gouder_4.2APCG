using UnityEngine;
using System.Collections;

public class PointPickUpSpawner : MonoBehaviour
{
    public PointPickUpConfig config;
    public int totalPickUps = 10;

    int activePickups = 0;
    bool finishedSpawning = false; 

    void Start()
    {
        StartCoroutine(PickUpSpawn());
    }

    IEnumerator PickUpSpawn()
    {
        for (int i = 0; i < totalPickUps; i++)
        {
            float waitTime = Random.Range(config.minSpawn, config.maxSpawn);
            yield return new WaitForSeconds(waitTime);

            float randomX = Random.Range(-8f, 8f);
            GameObject pickup = Instantiate(config.PointsPickUpPrefab, new Vector3(randomX, 11, 0), Quaternion.identity);

            PointPickupMovement ppm = pickup.GetComponent<PointPickupMovement>();
            if (ppm != null)
            {
                ppm.spawner = this;
            }

            activePickups++;
        }

        finishedSpawning = true;

        yield return new WaitUntil(() => activePickups <= 0);

        if (finishedSpawning)
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "KittyDefenderLvl2")
            {
                FindAnyObjectByType<Level>().LoadWinScreen();
            }
            else
            {
                FindAnyObjectByType<Level>().LoadLevel2();
            }

            finishedSpawning = false;
        }
    }

    public void PickupDestroyed()
    {
        activePickups--;
    }
}
