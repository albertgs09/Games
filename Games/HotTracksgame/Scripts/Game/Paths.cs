using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys path block ways when player collides with triggers
//then activates the next one
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
