using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls pop up for the eating witch
public class EatingWitch : MonoBehaviour
{
    public GameObject torch;
    private AudioSource witchAudio;
    public AudioClip clip, heartBeat, scare;
    private Animator anim;
    private int i = 0;
    public GameObject player;
    public AudioSource camAudio, scareAudio;
    public TimedDeath deathTime;
    
    private void Start()
    {
        witchAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        //looks at player and screams
            transform.LookAt(player.transform);
            witchAudio.clip = clip;
            witchAudio.loop = false;
            anim.SetTrigger("Scream");
            if(i == 0)
                StartCoroutine(TurnOffTorch(1));
            Destroy(gameObject, 5f);
        } 
    }

    private IEnumerator TurnOffTorch(float time)
    {
        i++;
        yield return new WaitForSeconds(time);
        witchAudio.Play();

        yield return new WaitForSeconds(time);
        torch.SetActive(false);
        deathTime.StartDeath();
      
    }
}
