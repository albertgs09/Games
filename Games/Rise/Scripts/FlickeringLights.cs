using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    public Light _light;

    public float MinTime;
    public float MaxTime;
    public float Timer;

    public AudioSource aS;
    public AudioClip lightAudio;
    private void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
    }

    void Update()
    {
        FlickerLights();
    }

    void FlickerLights()
    {
        if(Timer > 0)
            Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            _light.enabled = !_light.enabled;
            Timer = Random.Range(MinTime, MaxTime);
        }
    }
}
