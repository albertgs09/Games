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
    bool startCountdown, startTimer;
    public bool finished;
    int i = 0, currentCoins;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountDown(2));
        carController.enabled = false;
        currentCoins = PlayerPrefs.GetInt("Money", 0);
        Debug.Log("Money: " + currentCoins);
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown > 0)
            CountDown();
        if (startTimer)
            Timer();
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

    void Timer()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString();
    }

    void CountDown()
    {
        if (startCountdown)
            countDown -= Time.deltaTime;
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

    IEnumerator StartCountDown(float time)
    {
        yield return new WaitForSeconds(time);
        countDownText.enabled = true;
        startCountdown = true;
    }

    IEnumerator GoToMenu(float time)
    {
        yield return new WaitForSeconds(time);
        Menu();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
