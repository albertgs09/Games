using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public int times;
    private AudioSource camAudio;
    public AudioClip[] clip;


    private void Start()
    {
        camAudio = GetComponent<AudioSource>(); 
        times = Random.Range(0, clip.Length);
        PlayTrack(times);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && times < 3)
        {
            ++times;
            PlayTrack(times);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && times >= 3)
        {
            times = 0;
            PlayTrack(times);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && times > 0)
        {
            --times;
            PlayTrack(times);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && times <= 0)
        {
            times = 3;
            PlayTrack(times);
        }
    }

   private void PlayTrack(int i)
    {
        camAudio.clip = clip[i];
        camAudio.Play();
    }
}
