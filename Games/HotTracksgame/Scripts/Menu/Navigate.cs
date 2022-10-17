using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class Navigate : MonoBehaviour
{
    public GameObject startScreen, chooseCarScreen, mapScreen, loadScreen, creditsScreen;
    public Image loadingImage;
    public Animator animator, startAnim;
    public Slider progressBar;
    bool started;
    private AudioSource soundEffectAudio;
    public AudioClip[] sounds;
    public Sprite[] loadingSprites;
    AsyncOperation loadingOperation;
    string scene;
    private void Start()
    {
        soundEffectAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        ProgressBar();
    }
    public void ToStart()
    {
        chooseCarScreen.SetActive(true);
        startAnim.SetTrigger("Back");
    }


    public void CarColor()
    {
        chooseCarScreen.SetActive(true);
    }

    public void Credits()
    {
        creditsScreen.SetActive(true);
        startAnim.SetTrigger("Back");

    }

    public void StartLevel()
    {
        soundEffectAudio.clip = sounds[2];
        soundEffectAudio.Play();
        chooseCarScreen.SetActive(false);
        animator.enabled = true;
        if (started)
            animator.SetTrigger("Forward");
        StartCoroutine(WaitTime(1.5f));
    }

    IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        mapScreen.SetActive(true);
    }

    public void MapSelect(int i)
    {
        switch (i)
        {
            case 0: LoadingScreen("Lake"); loadingImage.sprite = loadingSprites[i];
                break; 
            case 1: LoadingScreen("Mountain-Day"); loadingImage.sprite = loadingSprites[i];
                break;
            case 2: LoadingScreen("Mountain-Night");  loadingImage.sprite = loadingSprites[i];
                break;
        }
    }

    public void Back(string i)
    {
        switch (i)
        {
            case "Credits":
                startAnim.SetTrigger("Forward");
                creditsScreen.SetActive(false);
                break;
            case "Car":
                chooseCarScreen.SetActive(false);
                startAnim.SetTrigger("Forward");
                break;
            case "Map":
                mapScreen.SetActive(false);
                chooseCarScreen.SetActive(true);
                animator.SetTrigger("Back");
                started = true;
                break;
        }
       
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void AudioEffects(int i)
    {
        soundEffectAudio.clip = sounds[i];
        soundEffectAudio.Play();
    }

    void LoadingScreen(string scene)
    {
        loadScreen.SetActive(true);
        loadingOperation = SceneManager.LoadSceneAsync(scene);
    }

    void ProgressBar()
    {
        if (loadingOperation != null)
        {
            float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);

        }
    }
}
