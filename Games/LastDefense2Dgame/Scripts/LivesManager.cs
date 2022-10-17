using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LivesManager : MonoBehaviour
{
    public TextMeshProUGUI lives_textholder;
    public  int lives_count = 5;

    public GameObject gameOver_panel;
    public TextMeshProUGUI sorru_textholder;
    string sorry = "Sorry, you ran out of lives.";

    public GameObject game_panel, pauseScreen, topPanel;
    public GameObject smoke, enemySpawn;

    public AudioSource camAudio;
    public AudioSource playerAudio;
    public AudioClip loseClip, playerExplosion, click, playerHit, menuButton;
    bool isPaused = false;

    private void Start()
    {
        lives_textholder.text = "Lives: " + lives_count.ToString();

    }
    // Update is called once per frame
    void Update()
    {

        if(lives_count == 0)
        {
            camAudio.clip = loseClip;
            camAudio.Play();
            //Time.timeScale = 0;// 1 to resume
            sorru_textholder.text = sorry;
            gameOver_panel.SetActive(true);
            game_panel.SetActive(false);
            enemySpawn.SetActive(false);
            Destroy(gameObject, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            if(lives_count > 1)
            {
                playerAudio.clip = playerHit;
                playerAudio.Play();

            }
            else 
            {
                playerAudio.clip = playerExplosion;
                playerAudio.Play();

            }
            lives_count--;
            lives_textholder.text = "Lives: " + lives_count.ToString();

            playSmoke();
        }
    }

    private void playSmoke()
    {
        GameObject e = Instantiate(smoke) as GameObject;
        e.transform.position = transform.position;

        Destroy(e, 0.15f);
    }

    public void Pause()
    {
        isPaused = !isPaused;
        playerAudio.clip = click;
        playerAudio.Play();
        //try a switch
        if (isPaused == true)
        {
            Time.timeScale = 0;
            topPanel.SetActive(false);
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            topPanel.SetActive(true);
            pauseScreen.SetActive(false);
        }
    }

    public void Menu()
    {
        playerAudio.clip = menuButton;
        playerAudio.Play();
        SceneManager.LoadScene("Menu");
    }
}
