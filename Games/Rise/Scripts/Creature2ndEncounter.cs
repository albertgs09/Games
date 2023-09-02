using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature2ndEncounter : MonoBehaviour
{
    public Transform point;
    public float speed = 5;
    public float smooth = 5;
    private Animator animator;
    private string creature;
    public float moveTime = 4;
   
    private void Start()
    {
        animator = GetComponent<Animator>();
        creature = gameObject.name;
    }

    private void Update()
    {
        if(creature == "crawler1") Creature1();
        else if(creature == "crawler2") Creature2();
    }

    private void Creature1()
    {
        moveTime -= Time.deltaTime;        

        if(moveTime < 0)
        {
            //rotates object smoothly to target
            var rotation = Quaternion.LookRotation(point.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * smooth);
            //moves object forward
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            animator.SetBool("move", true);
            Destroy(gameObject, 1.5f);
        }    
    }

    private void Creature2()
    {
        moveTime -= Time.deltaTime;
        if(moveTime < 0)
        {
            //moves object forward based on the creatures postion
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            animator.SetBool("move", true);
            Destroy(gameObject, 1.5f);
        }
       
    }
}
