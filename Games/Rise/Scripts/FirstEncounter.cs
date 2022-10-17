using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEncounter : MonoBehaviour
{
  public Creature1stEncounter Creature1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Creature1.enabled = true ;
            Destroy(gameObject, 1f);
        }
    }
}
