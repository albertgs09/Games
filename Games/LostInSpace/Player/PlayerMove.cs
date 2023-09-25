using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float jumpSpeed = 5;
    private Rigidbody2D rb;
    private Animator animator;
    private bool fireTimer;
    private float firetime;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void LateUpdate()
    {
        if (fireTimer) firetime += Time.deltaTime;
        if(firetime > 1.85f) animator.SetBool("IsFlying", false);
    }
    public void Jump()
    {
        rb.velocity = Vector2.up * jumpSpeed;
        fireTimer = true;
        firetime = 0;
        animator.SetBool("IsFlying", true);
    }
}
