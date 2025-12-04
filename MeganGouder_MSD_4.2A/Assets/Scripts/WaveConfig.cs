using System.Collections.Generic;
using System.IO;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy Wave Config")]


public class WaveConfig : ScriptableObject
{

    [SerializeField] GameObject enemyPrefab;
    //this is the enemy
    [SerializeField] GameObject pathPrefab;
    //this is the enemys path
    [SerializeField] float timeBetweenSpawns = 0.5f;
    //time between each enemys spawn

    [SerializeField] float spawnRandomFactor = 0.3f;
    //random time difference in spawns

    [SerializeField] int numberOfEnemies = 5;
    //the number of enemies in this wave

    [SerializeField] float enemyMoveSpeed = 2f;
    //the speed the enemies will have


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        

        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }
    // making all of them accessiable to other scripts 

}
