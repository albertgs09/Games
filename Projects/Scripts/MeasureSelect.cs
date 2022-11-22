using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeasureSelect : MonoBehaviour
{
    public static  GameObject tip, tape;
    public GameObject currentInches;
    public Text currentReadings;
    private Vector3 selectedMeasurement;
    private float distance;
    private decimal measurementsInInches;


    private void Update()
    {
        Raycasting();
    }
    public static void GetTip()
    {
        //Finds these objects
        tip = GameObject.Find("Tip");
        tape = GameObject.Find("Tape");
    }

    void Raycasting()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 1000) && tape != null)
            {
                Debug.DrawRay(Camera.main.transform.position, Vector3.forward, Color.green);
                if (hit.transform.name == tape.name)
                {
                    selectedMeasurement = hit.point;
                    GetDistance();
                }
            }
        }
    }

    public void GetDistance()
    {
        //Gets distance between the two 
        distance = Vector3.Distance(tip.transform.position, selectedMeasurement);
        currentInches.SetActive(true);
        CalculateMeasurements((decimal)distance);
    }

    void CalculateMeasurements(decimal dist)
    {
        measurementsInInches = dist * 39.701m;//converts meters to inches
        measurementsInInches = Decimal.Round(measurementsInInches * 4) / 4;//rounds to nearest quarter
        currentReadings.text = "Current  measurements in inches: \n" + measurementsInInches.ToString();
    }
}
