using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Store where you can buy different cars
public class Store : MonoBehaviour
{
    public MeshFilter bodyRef;
    public Mesh[] color;
    public Image selector;
    public Sprite locked;
    public Sprite available;
    public Text moneyText, costText;
    private int i = 0;
    private int money = 100;
    private int carCost = 50;
    private bool unlocked, enoughMoney;
    private Navigate menu;
    public PlayerData data;

    private void Start()
    {
        menu = GetComponent<Navigate>();
        i = PlayerPrefs.GetInt("CarChoice", 0);
        carCost = PlayerPrefs.GetInt("Cost", 50);
        bodyRef.mesh = color[i];
        money = PlayerPrefs.GetInt("Money", 75);
        moneyText.text = money.ToString();
        costText.text = carCost.ToString();
        CheckingAvailability(i);
        CheckCost();
    }

    public void SelectedCar()
    {
        if (unlocked)
        {
            PlayerPrefs.SetInt("CarChoice", i);
            PlayerPrefs.SetInt("Cost", carCost);
            menu.StartLevel();
        }
        else if (enoughMoney)
        {
            money -= carCost;
            moneyText.text = money.ToString();
            data.SaveData(i, 1, money, carCost);
            CheckingAvailability(i);
            menu.AudioEffects(0);
        }
        else
        {
            menu.AudioEffects(1);
        }
    }

    public void ChangeForward()
    {
        if (i < color.Length - 1)
        {
            i++;
            carCost += carCost;
            costText.text = carCost.ToString();
            CheckCost();
            bodyRef.mesh = color[i];
            CheckingAvailability(i);
        }
    }
    public void ChangeBackward()
    {
        if (i != 0)
        {
            i--;
            carCost -= carCost / 2 ;
            CheckCost();
            costText.text = carCost.ToString();
            bodyRef.mesh = color[i];
            CheckingAvailability(i);
        }
    }

    private void CheckCost()
    {
        if (money >= carCost)
        {
            enoughMoney = true;
            costText.color = Color.green;
        }
        else
        {
            enoughMoney = false;
            costText.color = Color.red;
        }
    }

   private void CheckingAvailability(int j)
    {
        unlocked = data.CheckData(j);
        if (unlocked)
            Unlocked();
        else
            Locked();
    }

    private void Unlocked()
    {
        selector.sprite = available;
        selector.color = Color.green;
        costText.enabled = false; 
    }

    private void Locked()
    {
        selector.sprite = locked;
        selector.color = Color.white;
        costText.enabled = true;
    }

}
