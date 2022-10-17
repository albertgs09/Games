using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    Animator anim;
    bool follow;
    AudioSource audioWalk;
    public AudioClip clip, growl;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  
        anim = GetComponentInChildren<Animator>();
        audioWalk = GetComponent<AudioSource>();
        follow = true;
        audioWalk.clip = growl;
        audioWalk.Play();
    }

    // Update is called once per frame
    void Update()
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
