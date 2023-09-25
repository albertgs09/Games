using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public Transform barrelEnd;
    public GameObject projectile;

   
    public void Fire()
    {
        //Instantiate(projectile, barrelEnd.transform.position, Quaternion.identity);
        GameObject bullet = ObjectPool.instance.GetPooledObject();

        if(bullet != null)
        {
            bullet.transform.position = barrelEnd.position;
            bullet.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SoundEffectVolume");
            bullet.SetActive(true);

        }
    }
}
