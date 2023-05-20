using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveCharacter : MonoBehaviour
{
    private Rigidbody2D rb;
    private float x_dir;
    private float horizontal;
    private float moveSpeed = 5.0f;
   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    { 
        //mobile input
        x_dir = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(x_dir, 0f);
    }
}
