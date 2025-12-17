using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
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

    [SerializeField] int enemyDamage = 2;

    [SerializeField] int timeBetweenWave = 3;


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
        var waveWayPoints = new List<Transform>();
        

        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
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

    public int GetEnemyDamage()
    {
        return enemyDamage;
    }

    public int GetTimeBetweenWave()
    {
        return timeBetweenWave;
    }
    // making all of them accessiable to other scripts 

}
