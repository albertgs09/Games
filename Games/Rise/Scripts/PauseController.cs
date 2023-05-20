using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMain, controls;
    public Text key1, key2, key3;
    private void Start()
    {
        pauseMain.SetActive(true);
        controls.SetActive(false);
    }

    public void Main()
    {
        pauseMain.SetActive(true);
        controls.SetActive(false);
    }

   public void Controls()
    {
        pauseMain.SetActive(false);
        controls.SetActive(true) ;
    }

    
    public void Quit()
    {
        SceneManager.LoadScene("TitleMenu");
    }
}
