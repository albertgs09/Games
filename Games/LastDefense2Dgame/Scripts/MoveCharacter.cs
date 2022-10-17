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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
        //mobile input
        x_dir = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(x_dir, 0f);
        

        /*
        //pc input
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal, 0f) * moveSpeed;
        */
    }
}
