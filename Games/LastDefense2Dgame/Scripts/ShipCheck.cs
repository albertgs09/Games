using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCheck : MonoBehaviour
{
    public GameObject[] buttons, equipButtons, equippedText;
    int ship1 , ship2, ship3, ship4, ship5, ship6;
   
    // Start is called before the first frame update
    void Start()
    {      
        ship1 = PlayerPrefs.GetInt("Ship1", 0);
        ship2 = PlayerPrefs.GetInt("Ship2", 0);
        ship3 = PlayerPrefs.GetInt("Ship3", 0);
        ship4 = PlayerPrefs.GetInt("Ship4", 0);
        ship5 = PlayerPrefs.GetInt("Ship5", 0);
        ship6 = PlayerPrefs.GetInt("Ship6", 0);

        Execute1stButton();
    }

    void Execute1stButton()
    {
        if(ship1 == 0)
        {
            buttons[0].SetActive(true);
        }
        else
        {
            buttons[0].SetActive(false);
        }

         if(ship2 == 0)
        {
            buttons[1].SetActive(true);
        }
        else
        {
            buttons[1].SetActive(false);
        }

         if(ship3 == 0)
        {
            buttons[2].SetActive(true);
        }
        else
        {
            buttons[2].SetActive(false);
        }

         if(ship4 == 0)
        {
            buttons[3].SetActive(true);
        }
        else
        {
            buttons[3].SetActive(false);
        }

         if(ship5 == 0)
        {
            buttons[4].SetActive(true);
        }
        else
        {
            buttons[4].SetActive(false);
        }

         if(ship6 == 0)
        {
            buttons[5].SetActive(true);
        }
        else
        {
            buttons[5].SetActive(false);
        }

    } 
}
