using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    private Animator anim;
    private bool follow;
    private AudioSource audioWalk;
    public AudioClip clip, growl;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();  
        anim = GetComponentInChildren<Animator>();
        audioWalk = GetComponent<AudioSource>();
        follow = true;
        audioWalk.clip = growl;
        audioWalk.Play();
    }

    private void Update()
    {
        if (follow)
        {
            anim.SetBool("move", follow);
            agent.SetDestination(player.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          
            anim.SetBool("move", false);
            anim.SetTrigger("attack");
            anim.SetBool("move", true);
            audioWalk.clip = clip;
            audioWalk.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {          
            anim.SetBool("move", true);
            audioWalk.clip = growl;
            audioWalk.Play();
        }
    }
}
