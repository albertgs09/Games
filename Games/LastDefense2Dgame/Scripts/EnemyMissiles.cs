using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissiles : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = 5;

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
