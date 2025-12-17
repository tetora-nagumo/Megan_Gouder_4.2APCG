using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{

     [SerializeField] List<WaveConfig> waveConfigs;

     int startingWave = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] bool looping = false;
    void Start()
    {
       if (looping)
        {
            StartCoroutine(LoopAllWaves());
        }
        else
        {
            StartCoroutine(SpawnAllWaves());
        }


    }


    private IEnumerator LoopAllWaves()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while(looping);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        yield return new WaitForSeconds(waveConfig.GetTimeBetweenWave());
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {

            var newEnemy = Instantiate(
            waveConfig.GetEnemyPrefab(),
            waveConfig.GetWaypoints()[0].transform.position,
            Quaternion.identity);

            DamageDealer damageDealer = newEnemy.GetComponent<DamageDealer>();
            if (damageDealer != null)
            {
                damageDealer.SetDamage(waveConfig.GetEnemyDamage());
            }

            newEnemy.GetComponent<enemyPath>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }


    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}

