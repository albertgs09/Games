using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseScreen;
    public AudioSource camAudio;
    public PauseController pc;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Paused();    
    }

   private void Paused()
    {
        isPaused = !isPaused;
        if (isPaused == true)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            camAudio.volume = 0.1f;
            pc.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            camAudio.volume = 0.5f;
            pc.Main();
            pc.enabled = false;

        }
    }
}
