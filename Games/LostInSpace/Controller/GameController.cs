using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText,highscoreText, yourScoreText;
    public GameObject instructions;
    public Slider healthBar;
    private int score, highScore;
    private bool isPaused = false;

    public GameObject spawner;
    public UIController ui;
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        instructions.SetActive(false);  
    }
    public void UpdateScore(int scoreNum)
    {
        score += scoreNum;
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateHealthBar(float health) => healthBar.value = health;
    

   public void PausedUnPause()
    {
        isPaused = !isPaused;
        if(isPaused) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void PlayerDead()
    {
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", highScore);
        }
        highscoreText.text = "Highscore: \n" + highScore.ToString();
        yourScoreText.text = "Your score: \n" + score.ToString();
        spawner.SetActive(false);
        ui.GameOver();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        foreach (GameObject enemy in enemies)
              Destroy(enemy);
        foreach(GameObject projectile in projectiles)
              Destroy(projectile);
    }  
}
