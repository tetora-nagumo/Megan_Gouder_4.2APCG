using UnityEngine;
using System.Collections.Generic;

public class enemyPath : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    

    [SerializeField] WaveConfig waveConfig;

    int waypointIndex = 0;
    //shows the next waypoint that the enemy would want to go
    
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
      //makes sure the enemy starts is the first waypoint  
    }
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        if (waypointIndex <= waypoints.Count -1)
        {
            //target position is where we want it to go
            var targetPosition = waypoints[waypointIndex].transform.position;

            targetPosition.z = 0f;
            //to make sure the z position is zero

            var movementThisFrame = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
            if (waypointIndex >= waypoints.Count)
            {
                Destroy(gameObject);
            }


        }
    }
    public void SetWaveConfig(WaveConfig config)
    {
        waveConfig = config;
    }
    
}



