using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature2ndEncounter : MonoBehaviour
{
    public Transform point;
    public float speed = 5;
    public float smooth = 5;
    Animator animator;
    string creature;
    public float moveTime = 4;
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        creature = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(creature == "crawler1")
        {
            Creature1();
        }
        else if(creature == "crawler2")
        {
            Creature2();
        }

    }

    void  Creature1()
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

    void Creature2()
    {
        moveTime -= Time.deltaTime;
        if(moveTime < 0)
        {
            //moves object forward
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            animator.SetBool("move", true);
            Destroy(gameObject, 1.5f);
        }
       
    }
}
