using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = 100;
    public GameObject explosion;
    
   private void Start()
    {
    //Moves bullet up
        rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
            Destroy(gameObject);  
    }
  
}
