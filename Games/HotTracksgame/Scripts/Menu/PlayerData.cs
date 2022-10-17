using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    string[] cars = new string[16];

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    public void SaveData(int i, int j, int money, int cost)
    {
        PlayerPrefs.SetInt(cars[i], j);
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("Cost", cost);
        Debug.Log("Data Saved for Car: " + cars[i]);
        Debug.Log("Data Saved for money: " + money);
        Debug.Log("Data Saved for cost: " + cost);
    }

    public void LoadData()
    {
        for(int i = 0; i < cars.Length; i++)    
        {
            cars[i] = i.ToString();
        }
    }

    public bool CheckData(int i)
    {
        if (PlayerPrefs.GetInt(cars[i]) == 1)
            return true;
        return false;
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(string car in cars)
            {
                PlayerPrefs.SetInt(car, 0);
            }
            PlayerPrefs.SetInt("CarChoice", 0);
            PlayerPrefs.SetInt("Money", 75);
            PlayerPrefs.SetInt("Cost", 50);
            Debug.Log("Game data has been reset");

        }
        */
    }
}
