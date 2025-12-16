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
        StartCoroutine(SpawnAllWaves());

        var currentWave = waveConfigs[startingWave];
        //making the current wave to first wave

        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        //a coroutine that will spawn all the enemies in our current wave

        StartCoroutine(LoopAllWaves());


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
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {

            var newEnemy = Instantiate(
            waveConfig.GetEnemyPrefab(),
            waveConfig.GetWaypoints()[0].transform.position,
            Quaternion.identity);

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
