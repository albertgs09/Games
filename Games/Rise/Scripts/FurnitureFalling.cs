using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureFalling : MonoBehaviour
{
    public GameObject[] fallObjects;
    public GameObject furniture, readyObject;
    private BoxCollider col;

    private void Start()
    {
        col = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Slams furniture down
            furniture.transform.position = new Vector3(0, 3.75f, 0);
            foreach(var furn in fallObjects){
                furn.GetComponent<MeshCollider>().enabled = false;
                furn.GetComponent<Rigidbody>().useGravity = false;
                furn.GetComponent<Rigidbody>().mass = 0;
            }
            readyObject.SetActive(true);
            Destroy(col);
        }    
    }
}
