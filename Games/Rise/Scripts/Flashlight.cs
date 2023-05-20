using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool lightOn = true;
    privateLight flashLight;

    private void Start()
    {
        flashLight = GetComponent<Light>();  
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            lightOn = !lightOn;

        if (lightOn)
            flashLight.enabled = true;  
        else
            flashLight.enabled = false;  
    }
}
