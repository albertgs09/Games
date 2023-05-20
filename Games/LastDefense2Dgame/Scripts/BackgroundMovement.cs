using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Moves background 
public class BackgroundMovement : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        rb.velocity = new Vector2(0f, -speed);//moves enemy
        Destroy(this.gameObject, destroyTime);
    }
}
