using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureFalling : MonoBehaviour
{
    public GameObject[] fallObjects;
    public GameObject furniture, readyObject;
    BoxCollider col;

    private void Start()
    {
        col = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //try using force to slam the furniture down faster


            furniture.transform.position = new Vector3(0, 3.75f, 0);
            fallObjects[0].GetComponent<MeshCollider>().enabled = false;
            fallObjects[1].GetComponent<MeshCollider>().enabled = false;
            fallObjects[2].GetComponent<MeshCollider>().enabled = false;
            fallObjects[3].GetComponent<MeshCollider>().enabled = false;

            fallObjects[0].GetComponent<Rigidbody>().useGravity = false;
            fallObjects[1].GetComponent<Rigidbody>().useGravity = false;
            fallObjects[2].GetComponent<Rigidbody>().useGravity = false;
            fallObjects[3].GetComponent<Rigidbody>().useGravity = false;

            fallObjects[0].GetComponent<Rigidbody>().mass = 0;
            fallObjects[1].GetComponent<Rigidbody>().mass = 0;
            fallObjects[2].GetComponent<Rigidbody>().mass = 0;
            fallObjects[3].GetComponent<Rigidbody>().mass = 0;

            readyObject.SetActive(true);
            Destroy(col);
        }    
    }
}
