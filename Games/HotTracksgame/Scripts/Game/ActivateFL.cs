using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Activates finishline collider and enables light color and wrong way signa
public class ActivateFL : MonoBehaviour
{
    public GameObject finishLine, wrongWay, thisWay;
    public Light finishLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            finishLine.SetActive(true);
            if(finishLight != null)
                finishLight.color = Color.green;
            if (thisWay != null)
                thisWay.SetActive(true);
            Destroy(gameObject);
            Destroy(wrongWay);
        }
    }
}
