using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    SpriteRenderer bg;
    public Sprite[] bgSprites;
    // Start is called before the first frame update
    void Start()
    {
        bg = GetComponent<SpriteRenderer>();
        var bgNum = Random.Range(0, bgSprites.Length);

        bg.sprite = bgSprites[bgNum];
    }


}
