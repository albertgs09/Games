using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    AudioSource click;
    public int currentCoins = 100;
    int shipCost;
    public GameObject[] buttons, equipButtons, equippedText;
    public GameObject notEnoughText;
    public Text coins;
    private void Start()
    {

        click = GetComponent<AudioSource>();
        coins.text = "Coins: " + currentCoins;
    }

    public void Ship1()
    {
        shipCost = 100;
        click.Play();
        Check(shipCost, 0);
    }
    public void Ship2()
    {
        shipCost = 200;
        click.Play();
        Check(shipCost, 1);
    }
    public void Ship3()
    {
        shipCost = 300;
        click.Play();
        Check(shipCost, 2);
    }
    public void Ship4()
    {
        shipCost = 400;
        click.Play();
        Check(shipCost, 3);
    }
    public void Ship5()
    {
        shipCost = 500;
        click.Play();
        Check(shipCost, 4);
    }
    public void Ship6()
    {
        shipCost = 600;
        click.Play();
        Check(shipCost, 5);
    }
   
    public void Back()
    {
        notEnoughText.SetActive(false);
    }

    private int Check(int cost, int num)
    {
        if (currentCoins < shipCost)
        {
            notEnoughText.SetActive(true);
        }
        else
        {
            buttons[num].SetActive(false);
            currentCoins -= cost;
            coins.text = "Coins: " + currentCoins;
        }
        return currentCoins;
    }
    public void ToMeu()
    {
        click.Play();
        SceneManager.LoadScene("Menu");
    }
}
