using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paths : MonoBehaviour
{
    public GameObject blockadePrev, blockadeNext;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(blockadePrev);
            Destroy(gameObject);
            blockadeNext.SetActive(true);
        }
    }
}
