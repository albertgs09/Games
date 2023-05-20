using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Spawns Meteors in random points
public class Spawner : MonoBehaviour
{
    public GameObject meteors;
    public Transform[] spawnPoints;
    public float spawnTime, repeatRate;

    private void Start()
    {
        InvokeRepeating("SpawnMeteors", spawnTime, repeatRate) ;
    }

    private void SpawnMeteors()
    {
        var randNum = Random.Range(0, spawnPoints.Length);
        Instantiate(meteors, spawnPoints[randNum].position, spawnPoints[randNum].rotation);        
    }
}
