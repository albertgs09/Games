using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string sceneToLoad;

    AsyncOperation loadingOperation;
    public Slider progressBar;
    public Text percentLoaded;
    public GameObject loadingScreen, settingsButton, playButton, backButton;

    public Text title;

    AudioSource click;

    private void Start()
    {
        click = GetComponent<AudioSource>();
        Time.timeScale = 1;

    }
    void Update()
    {
        if (loadingOperation != null)
        {
            float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            percentLoaded.text = Mathf.Round(progressValue * 100) + "%";
            progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);

        }

    }

    public void LoadScreen()
    {
        click.Play();
        loadingScreen.SetActive(true);
        loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);

    }  public void LoadShop()
    {
        click.Play();
        SceneManager.LoadScene("Shop");

    }

    public void Settings()
    {
        click.Play();
        title.text = "Settings";
        settingsButton.SetActive(false);
        playButton.SetActive(false);
        backButton.SetActive(true);
    }

    public void Back()
    {
        click.Play();
        title.text = "Title";
        settingsButton.SetActive(true);
        backButton.SetActive(false);
        playButton.SetActive(true);
    }


}