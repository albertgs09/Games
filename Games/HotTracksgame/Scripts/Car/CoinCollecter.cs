using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecter : MonoBehaviour
{
    public int totalCoins = 0;
    public AudioSource soundEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
            soundEffect.Play();
            totalCoins += 50;
        }
    }
}
