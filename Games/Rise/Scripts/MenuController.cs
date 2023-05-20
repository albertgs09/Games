using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public string sceneToLoad;

    private AsyncOperation loadingOperation;
    public Slider progressBar;
    public GameObject loadingScreen, mainMenu, controlsMenu, credits;

    public Text title;

    private AudioSource click;

    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (loadingOperation != null)
        {
            float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        }

    }
    public void Menu()
    {
        controlsMenu.SetActive(false);
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }

    public void LoadScreen()
    {
        loadingScreen.SetActive(true);
        loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);

    }
    public void Controls()
    {
        controlsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Credits()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
