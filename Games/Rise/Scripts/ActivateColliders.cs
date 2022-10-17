using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateColliders : MonoBehaviour
{
    public GameObject crawlers;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            crawlers.SetActive(true);
        }
    }
}
