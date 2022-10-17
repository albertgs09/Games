using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiring : MonoBehaviour
{
    public float timeTillShot = 3f;
    ProjectileController missile;
    public GameObject chargeLight;
    public AudioSource audioSound;
    public AudioClip missileDetection;
    // Start is called before the first frame update
    void Start()
    {
        missile = GetComponentInChildren<ProjectileController>();

    }

    // Update is called once per frame
    void Update()
    {
        timeTillShot -= Time.deltaTime;
        if(timeTillShot > 2f)
        {
            audioSound.clip = missileDetection;
            audioSound.Play();
        }
        if(timeTillShot < 2f && timeTillShot > 0)
        {
            chargeLight.SetActive(true);
           
        }
        if (timeTillShot < 0)
        {
                missile.Shoot();
            chargeLight.SetActive(false);
                timeTillShot = 3;
        }
    }
}
