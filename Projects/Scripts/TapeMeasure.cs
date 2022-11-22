using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeMeasure : MonoBehaviour
{
    public Transform tape_Pos;
    private Transform tape_Org_Pos;
    private Vector3 scaleChange;
    private float dist = .5f;

       private void Start()
    {
        scaleChange = new Vector3(dist, 0, 0);
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
            tape_Pos.localScale += scaleChange * Time.deltaTime * 5;
    }


}
