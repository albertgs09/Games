using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularMeteorNum : MonoBehaviour
{

    public GameObject rockExplode, meteorAudio;
    public Sprite[] numbers;
    int num;
    SpriteRenderer mySprite;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        num = Random.Range(0, 10);
        mySprite.sprite = numbers[num];
        meteorAudio = GameObject.FindGameObjectWithTag("Audio");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 14) * Time.deltaTime);
    }

    private void OnMouseDown()
    {  
        Instantiate(rockExplode, transform.position, transform.rotation);
        meteorAudio.GetComponent<MeteorAudio>().ChooseAudio(num);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
