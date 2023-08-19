using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//AI for witch that chases you around
public class ChasingWitch : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private GameObject player;
    private bool chase;
    private int i;
    private SphereCollider col;
    private AudioSource audio;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        col = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (chase)
        {
            anim.SetBool("IsWalking", true);
            agent.SetDestination(player.transform.position);
        }
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
                anim.SetTrigger("Scream");
            audio.Play();
                transform.LookAt(player.transform);
                StartCoroutine(Scream(2));         
        }
    }

    private IEnumerator Scream(float time)
    {
        yield return new WaitForSeconds(time);
        chase = true;
    }
}
