using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text problemsText, scoreText, highscore;
    public GameObject playArea, pauseArea, redBG, greenBG, deadArea;
    public bool isPlaying;
    private int num1, num2, result, currentScore, mode;
    public int selectedMeteorNum, health;
    private string add = " + ", sub = " - ", mult = " x ";
    
    private void Start()
    {
        isPlaying = true;
        Time.timeScale = 1;
        mode = PlayerPrefs.GetInt("Mode", 0);
        UpdateProblem();
    }

    private void Update()
    {
        if(health <= 0)
        {
            Dead();
        }
    }
    private void Dead()
    {
        isPlaying = false;
        highscore.text = "Score: " + currentScore.ToString();
        deadArea.SetActive(true);
        playArea.SetActive(false);
        Time.timeScale = 0;
    }
    public void MeteorNumber(int num)
    {
        if(num == result)
        {
            //correct!
            currentScore++;
            scoreText.text = "Score: " + currentScore.ToString();
            greenBG.SetActive(true);
            StartCoroutine(Right(.25f));
            //move on to next problem
            UpdateProblem();
          
        }
        else
        {
            //Wrong!
            health--;
            redBG.SetActive(true);
            StartCoroutine(Hurt(.25f));
        }
    }

    private IEnumerator Hurt(float time)
    {
        yield return new WaitForSeconds(time);
        redBG.SetActive(false);
    }
     private IEnumerator Right(float time)
    {
        yield return new WaitForSeconds(time);
        greenBG.SetActive(false);
    }

    private void UpdateProblem()
    {
        // gets 2 random numbers from 0-5
        num1 = Random.Range(0, 5);
        num2 = Random.Range(0, 5);

        //checks which mode theuser selected
        switch (mode)
        {
            case 0:
                problemsText.text = num1.ToString() + add + num2.ToString();
                result = num1 + num2;

                break;
            case 1:
                //checks problem so answer won't be a negative number
                //if num1 is not >= to num2 then it will keep generating a random number till it is
                if(num1 >= num2)
                {                   
                    problemsText.text = num1.ToString() + sub + num2.ToString();
                    result = num1 - num2;
                }
                else
                {
                    UpdateProblem();
                }
                break;
                //Multiplication
                /*
            case 2:
                problemsText.text = num1.ToString() + mult + num2.ToString();
                result = num1 * num2;
                break;
                */
        }
    }
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

    public void Restart()
    {
        SceneManager.LoadScene("ProblemLevel");
    }
}
