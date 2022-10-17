using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject startMenu, modes;
    public Sprite bgSprite;
    public Image bg;


    public void Menu()
    {
        startMenu.SetActive(false);
        modes.SetActive(true);
        bg.sprite = bgSprite;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("ProblemLevel");
    }
    public void Normal ()
    {
        SceneManager.LoadScene("Normal");
    }


    public void AdditionMode()
    {
        PlayerPrefs.SetInt("Mode", 0);
    }
    public void SubtractionMode()
    {
        PlayerPrefs.SetInt("Mode", 1);
    }
    /*
    public void MultiplicationMode()
    {
        PlayerPrefs.SetInt("Mode", 2);
    }
    */
}
