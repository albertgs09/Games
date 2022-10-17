using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCreatures : MonoBehaviour
{
    [SerializeField]
     GameObject creatures;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            creatures.SetActive(true);
            Destroy(gameObject);
        } 
    }
}
