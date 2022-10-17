using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score_textholder;
    public TextMeshProUGUI final_score_textholder;
    public static int score = 0;

    private void Start()
    {
        score = 0;
    }
    // Update is called once per frame
    void Update()
    {
        score_textholder.text = "Score: " + score.ToString();
        final_score_textholder.text = score.ToString();
    }
}
