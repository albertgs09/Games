using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    private int enemy;

    [SerializeField] private float timeBetweenShips;
    private float timer = 0;
   
    void LateUpdate()
    {
        timer += Time.deltaTime;
        if(timeBetweenShips< timer)
            Ordered(Random.Range(0, spawnPoints.Length));
    }

    void Ordered(int rand)
    {
        Instantiate(enemies[enemy], spawnPoints[rand].transform.position, Quaternion.identity);
        if (enemy != enemies.Length - 1) enemy++;
        else enemy = 0;
        timer = 0;
    }

    void RandomEnemy(int randpoint, int randEnemy)
    {
        Instantiate(enemies[randEnemy], spawnPoints[randpoint].transform.position, Quaternion.identity);
        timer = 0;
    }
}
