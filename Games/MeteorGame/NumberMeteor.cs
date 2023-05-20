using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Sets random Sprite for meteors
public class NumberMeteor : MonoBehaviour
{
    public GameObject gameController, rockExplode, meteorAudio;
    private int num;
    public Sprite[] numbers;
    private SpriteRenderer mySprite;
    private Vector3 targetScale;
    public float speed = 3.0f;
    
    private void Start()
    {     
        gameController = GameObject.Find("GameController");
        mySprite = GetComponent<SpriteRenderer>();
        num = Random.Range(0, 10);
        mySprite.sprite = numbers[num];
        meteorAudio = GameObject.FindGameObjectWithTag("Audio");
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0,0,14) * Time.deltaTime);
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
            Destroy(gameObject);        
    }
}
