using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Slams furniture down to the ground
public class NowFall : MonoBehaviour
{
    public GameObject[] fallObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //inputs mass to 50, enables gravity and turns on colliders
            foreach(var furn in fallObjects){
                furn.GetComponent<Rigidbody>().mass = 50;
                furn..GetComponent<Rigidbody>().useGravity = true;
                furn.GetComponent<MeshCollider>().enabled = true;
            }
            Destroy(gameObject, 1f);
        }
    }
}
