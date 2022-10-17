using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pauseScreen;
    public AudioSource camAudio;
    public PauseController pc;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused();
        }    
    }

   void Paused()
    {

        isPaused = !isPaused;
       // playerAudio.clip = click;
       // playerAudio.Play();
        //try a switch
        if (isPaused == true)
        {
            Time.timeScale = 0;
           // topPanel.SetActive(false);
            pauseScreen.SetActive(true);
            camAudio.volume = 0.1f;
            pc.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            //topPanel.SetActive(true);
            pauseScreen.SetActive(false);
            camAudio.volume = 0.5f;
            pc.Main();
            pc.enabled = false;

        }
    }
}
