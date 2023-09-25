using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScript : MonoBehaviour
{
    private float speed = 3f;
    public float num;
    public GameObject bg;
   
    void LateUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Destroyer"))
        {
            Instantiate(bg, new Vector2(transform.position.x + num, transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
