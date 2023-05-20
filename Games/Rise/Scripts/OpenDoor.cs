using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool canOpen = false;
    public string doorName;
   
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        doorName = this.gameObject.tag;
    }
    private void Update()
    {
        if (canOpen)
            animator.enabled = true;
    }

 
}
