using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedRocket : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 100;
    private GameObject lockedTarget;

   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();       
    }

    private void Update()
    {
        lockedTarget = GameObject.FindGameObjectWithTag("Enemy"); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            Destroy(gameObject);
    }
}
