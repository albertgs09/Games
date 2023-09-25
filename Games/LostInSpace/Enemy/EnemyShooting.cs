using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform barrelEnd;
    [SerializeField] private float timeBetweenShots;
    private float timer = 0;

    void LateUpdate()
    {
        timer += Time.deltaTime;
        if(timeBetweenShots < timer)
        {
            Instantiate(projectile, barrelEnd.position, Quaternion.identity);
            timer = 0;
        }
    }
}
