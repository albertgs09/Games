using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int health;
    private bool crashedPlayer = false;
    private GameObject gc;
    public GameObject explosion;
    private AudioSource hit;
    private SpriteRenderer body;

    private void Start()
    {
        gc = GameObject.Find("GameController");
        hit = GetComponent<AudioSource>();
        body = GetComponentInChildren<SpriteRenderer>();

    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if(health<=0)
        {
            if(!crashedPlayer)gc.GetComponent<GameController>().UpdateScore(20);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // deactives projectile so it can go back to the object pool
            collision.gameObject.SetActive(false);
            if (health > 0) hit.Play();
            health--;
            StartCoroutine(Hurt(.2f));

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            crashedPlayer = true;
            health = 0;
        }
    }

    IEnumerator Hurt(float time)
    {
        body.color = Color.red;
        yield return new WaitForSeconds(time);
        body.color = Color.white;
    }
}
