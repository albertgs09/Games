using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedRocket : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed = 100;
    GameObject lockedTarget;

    // Start is called before the first frame update
    void Start()
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
        {
            Destroy(gameObject);
        }
    }

}
