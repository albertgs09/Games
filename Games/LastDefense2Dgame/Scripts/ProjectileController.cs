using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileController : MonoBehaviour
{
    public GameObject BulletPrefab;
 
    public void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, this.transform.position, transform.rotation, transform);

        Destroy(bullet, 1.5f);
    }
}
