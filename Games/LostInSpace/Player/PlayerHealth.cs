using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private int health;
    public GameController gc;
    private AudioSource hit;
    private SpriteRenderer body;

    private void Start()
    {
        hit = GetComponent<AudioSource>();
        body = GetComponentInChildren<SpriteRenderer>();    
    }
    void LateUpdate()
    {
        if(health <= 0)
        {
            gc.PlayerDead();
            gameObject.SetActive(false);    
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyProjectile"))
        {
            if (health > 0) hit.Play();
            StartCoroutine(Hurt(.2f));
            health -= 25;
            gc.UpdateHealthBar(health);
            if(collision.gameObject.CompareTag("EnemyProjectile"))
                Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            health = 0;
            gc.UpdateHealthBar(health);
        }
    }

    IEnumerator Hurt(float time)
    {
        body.color = Color.red;
        yield return new WaitForSeconds(time);
        body.color = Color.white;
    }
}
