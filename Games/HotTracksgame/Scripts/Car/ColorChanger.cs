using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private MeshFilter bodyRef;
    public Mesh[] color;
    private int i = 0;
    
    private void Start()
    {
        bodyRef = GetComponent<MeshFilter>();
        i = PlayerPrefs.GetInt("CarChoice", 0);
        bodyRef.mesh = color[i];
    }    
}
