using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public CarController carController;
    public CarOffTrack carOffTrack;
    public CoinCollecter coinCollecter;
    public Text timerText, countDownText, yourTimeText, bestTimeText, coins;
    public GameObject scores;
    public float timer, countDown = 3;
    private bool startCountdown, startTimer;
    public bool finished;
    private int i = 0, currentCoins;
    
    private void Start()
    {
        StartCoroutine(StartCountDown(2));
        carController.enabled = false;
        currentCoins = PlayerPrefs.GetInt("Money", 0);
    }

    
    private void Update()
    {
        if(countDown > 0) CountDown();
        if (startTimer) Timer();
        CheckGameState();
    }

    private void CheckGameState(){
       if (finished)
        {
            startTimer = false;
            timerText.enabled = false;
            scores.SetActive(true);
            yourTimeText.text = timer.ToString();
            carOffTrack.enabled = false;
            coins.text = "+" +coinCollecter.totalCoins.ToString();
            
            //saves coin data
            while (i == 0)
            {
               PlayerPrefs.SetInt("Money", currentCoins + coinCollecter.totalCoins);
                i++;
            }
            StartCoroutine(GoToMenu(5));
        }
    }

    private void Timer()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString();
    }

    private void CountDown()
    {
        if (startCountdown) countDown -= Time.deltaTime;
        if (countDown < 0)
        {
            startCountdown = false;
            startTimer = true;
            timerText.enabled = true;
            carController.enabled = true;
            countDownText.enabled = false;
        }

        countDownText.text = countDown.ToString();
    }

    private IEnumerator StartCountDown(float time)
    {
        yield return new WaitForSeconds(time);
        countDownText.enabled = true;
        startCountdown = true;
    }

    private IEnumerator GoToMenu(float time)
    {
        yield return new WaitForSeconds(time);
        Menu();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
