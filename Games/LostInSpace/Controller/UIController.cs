using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject pausePage, inGameUI, gameOverScreen, loadingScreen;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void InGame()
    {
        PlayAudio();
        pausePage.SetActive(false);
        inGameUI.SetActive(true);
    }

    public void Paused()
    {
        PlayAudio();
        pausePage.SetActive(true);
        inGameUI.SetActive(false);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true); 
        pausePage.SetActive(false);
        inGameUI.SetActive(false);
    }

    public void Menu()
    {
        PlayAudio();
        loadingScreen.SetActive(true);
        SceneManager.LoadScene("Menu");
    }

    public void RestartLevel()
    {
        PlayAudio();
        loadingScreen.SetActive(true);
        SceneManager.LoadScene("Game");
    }

    void PlayAudio()
    {
        audioSource.Play();
    }
}
