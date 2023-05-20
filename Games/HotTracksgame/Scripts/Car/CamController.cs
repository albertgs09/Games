using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject Player;
    public GameObject child;
    public float speed;
   
   private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        child = Player.transform.Find("CameraConstraint").gameObject;        
    }

    
   private void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, child.transform.position, Time.deltaTime * speed) ;
        gameObject.transform.LookAt(Player.gameObject.transform.position);
    }
}
