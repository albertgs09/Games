using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalGC : MonoBehaviour
{
    public GameObject playArea, pauseArea, redBG;
    public bool isPlaying = true;
    // Start is called before the first frame update
   
    public void Pause()
    {
        isPlaying = false;
        pauseArea.SetActive(true);
        playArea.SetActive(false);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        isPlaying = true;
        pauseArea.SetActive(false);
        playArea.SetActive(true);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
