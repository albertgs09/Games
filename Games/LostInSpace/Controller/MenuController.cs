using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menu, settings, loadingScreen, credits;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StartGame()
    {
        PlayAudio();
        loadingScreen.SetActive(true);
        menu.SetActive(false);
        settings.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void Settings()
    {
        PlayAudio();
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void Back()
    {
        PlayAudio();
        menu.SetActive(true);
        settings.SetActive(false);
        credits.SetActive(false);
    }

    public void Credits()
    {
        PlayAudio();
        menu.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(true);
    }
    void PlayAudio()
    {
        audioSource.Play();
    }
}
