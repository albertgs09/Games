using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetter : MonoBehaviour
{
    private AudioSource myAudio;
    [SerializeField] private string audioName;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.volume = PlayerPrefs.GetFloat(audioName);
    }
}
