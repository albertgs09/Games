using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    public Camera cam;

    private void Start()
    {
        cam = Camera.main;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            cam.fieldOfView = 30;
        }
        if(Input.GetMouseButtonUp(2))
        {
            cam.fieldOfView = 60;
        }
    }
}
