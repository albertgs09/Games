using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowFall : MonoBehaviour
{
    public GameObject[] fallObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //inputs mass to 50 and enables gravity
            fallObjects[0].GetComponent<Rigidbody>().mass = 50;
            fallObjects[0].GetComponent<Rigidbody>().useGravity = true;
            fallObjects[1].GetComponent<Rigidbody>().mass = 50;
            fallObjects[1].GetComponent<Rigidbody>().useGravity = true;
            fallObjects[2].GetComponent<Rigidbody>().mass = 50;
            fallObjects[2].GetComponent<Rigidbody>().useGravity = true;
            fallObjects[3].GetComponent<Rigidbody>().mass = 50;
            fallObjects[3].GetComponent<Rigidbody>().useGravity = true;

            //turns on colliders
            fallObjects[0].GetComponent<MeshCollider>().enabled = true;
            fallObjects[1].GetComponent<MeshCollider>().enabled = true;
            fallObjects[2].GetComponent<MeshCollider>().enabled = true;
            fallObjects[3].GetComponent<MeshCollider>().enabled = true;
            Destroy(gameObject, 1f);
        }
    }
}
