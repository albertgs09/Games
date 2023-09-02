using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Checks if car is off track and restarts the game
public class CarOffTrack : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    public bool isOnTrack = true;
    public float timer = 0;

    private void Awake()
    {
        isOnTrack = true;
    }
    private void Update()
    {
        if(!isOnTrack)
            BackToTrack(1.5f);
    }
   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Track"))
            isOnTrack = true;     
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Track"))
            isOnTrack = false;
    }
    void BackToTrack(float time)
    {
        timer += Time.deltaTime;
        if(timer > time)
            SceneManager.LoadScene(sceneName);
    }
}
