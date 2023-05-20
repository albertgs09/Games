using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 1;
    public  int lives;
    public GameObject smoke;
    public GameObject explosion;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Moves enemy
        rb.velocity = new Vector2(0f, -speed);
        
        if(lives <= 0)
        {
            ScoreManager.score += 10;//updates score
            playExplosion();
            Destroy(gameObject);
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.tag == "Bullet")
        {
            lives--;
            playSmoke();
        }
    }

    private void playSmoke()
    {
        GameObject e = Instantiate(smoke) as GameObject;
        e.transform.position = transform.position;

        Destroy(e, 0.15f);
    }
    private void playExplosion()
    {
        GameObject e = Instantiate(explosion) as GameObject;
        e.transform.position = transform.position;
        Destroy(e, 0.15f);
    }
}
