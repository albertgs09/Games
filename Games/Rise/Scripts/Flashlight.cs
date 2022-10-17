using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    bool lightOn = true;
    Light flashLight;


    private void Start()
    {
        flashLight = GetComponent<Light>();  
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lightOn = !lightOn;
        }

        if (lightOn)
        {
            flashLight.enabled = true;  
        }
        else
        {
            flashLight.enabled = false;  
        }
    }
}
