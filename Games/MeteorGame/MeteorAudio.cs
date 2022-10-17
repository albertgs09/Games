using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorAudio : MonoBehaviour
{
    public AudioSource meteor,  explosionSound;
    public AudioClip[] numClips;

    [SerializeField]
    private bool numAudioOn;
    // Start is called before the first frame update
    void Start()
    {
        meteor = GetComponent<AudioSource>();
    }

    public void ChooseAudio(int num)
    {
        explosionSound.Play();
        if (numAudioOn)
        {
            meteor.clip = numClips[num];
            StartCoroutine(NumWait(.5f));
        }
        
    }

    IEnumerator NumWait(float time)
    {
        yield return new WaitForSeconds(time);
        meteor.Play();

    }
}
