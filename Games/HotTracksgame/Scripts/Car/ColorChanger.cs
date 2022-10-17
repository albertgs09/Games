using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private MeshFilter bodyRef;
    public Mesh[] color;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        bodyRef = GetComponent<MeshFilter>();
        i = PlayerPrefs.GetInt("CarChoice", 0);
        bodyRef.mesh = color[i];

    }

    
}
