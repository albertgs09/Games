using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;

   
   private void LateUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
