using UnityEngine;
using System.Collections;
public class PointPickUpSpawner : MonoBehaviour
{

   public PointPickUpConfig config;

   public int totalPickUps = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

            Instantiate(config.PointsPickUpPrefab, new Vector3(0 , 11 , 0), Quaternion.identity);
        }
    }
}
