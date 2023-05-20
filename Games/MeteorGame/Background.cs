using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Sets a random background
public class Background : MonoBehaviour
{
    private SpriteRenderer bg;
    public Sprite[] bgSprites;
 
    private void Start()
    {
        bg = GetComponent<SpriteRenderer>();
        var bgNum = Random.Range(0, bgSprites.Length);
        bg.sprite = bgSprites[bgNum];
    }
}
