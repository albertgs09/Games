using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberMeteor : MonoBehaviour
{
    public GameObject gameController, rockExplode, meteorAudio;
  
    int num;
    public Sprite[] numbers;
    SpriteRenderer mySprite;
    private Vector3 targetScale;
    public float speed = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
       
        gameController = GameObject.Find("GameController");
        mySprite = GetComponent<SpriteRenderer>();
        num = Random.Range(0, 10);
        mySprite.sprite = numbers[num];
        meteorAudio = GameObject.FindGameObjectWithTag("Audio");

        // targetScale = new Vector3(2, 2, 0);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0,0,14) * Time.deltaTime);
        //transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        if (gameController.GetComponent<GameController>().isPlaying)
        {
            gameController.GetComponent<GameController>().MeteorNumber(num);
            Instantiate(rockExplode, transform.position, transform.rotation);
            meteorAudio.GetComponent<MeteorAudio>().ChooseAudio(num);
            Destroy(gameObject);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
