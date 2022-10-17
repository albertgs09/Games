using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject meteors;
    public Transform[] spawnPoints;
    public float spawnTime, repeatRate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMeteors", spawnTime, repeatRate) ;
    }

    void SpawnMeteors()
    {
        var randNum = Random.Range(0, spawnPoints.Length);
        Instantiate(meteors, spawnPoints[randNum].position, spawnPoints[randNum].rotation);
        
    }
}
