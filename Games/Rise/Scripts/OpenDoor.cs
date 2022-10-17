using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool canOpen = false;
    public string doorName;
   
   Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        doorName = this.gameObject.tag;
    }
    // Update is called once per frame
    void Update()
    {
        if (canOpen)
        {
            animator.enabled = true;
        }
    }

 
}
