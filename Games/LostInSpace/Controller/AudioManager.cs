using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider musicslider, soundEffectSlider;
    public AudioSource musicSource, soundSource, buttonSource;
    private void Start()
    {
        musicslider.value = PlayerPrefs.GetFloat("MusicVolume", .5f);
        soundEffectSlider.value = PlayerPrefs.GetFloat("SoundEffectVolume", .5f);
    }

    public void Volume(Slider slider)
    {
        if (slider.gameObject.name == "MusicSlider")
        {
            PlayerPrefs.SetFloat("MusicVolume", slider.value);
            musicSource.volume  = slider.value; 
        }
        else if (slider.gameObject.name == "SoundEfectsSlider")
        {
            PlayerPrefs.SetFloat("SoundEffectVolume", slider.value);
            if(soundSource != null) soundSource.volume = slider.value;
            if(buttonSource != null) buttonSource.volume = slider.value;
        }
    }
}
