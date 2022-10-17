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
    public bool isOffTrack = false;
    public float timer = 0;

    private void Awake()
    {
        isOnTrack = true;
        isOffTrack = false;
    }
    private void Update()
    {
        if(isOffTrack && !isOnTrack)
            BackToTrack(1.5f);
    }
   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            isOnTrack = true;
            isOffTrack = false;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            isOnTrack = false;
            isOffTrack = true;
        }
    }
    void BackToTrack(float time)
    {
        timer += Time.deltaTime;
        if(timer > time)
            SceneManager.LoadScene(sceneName);

    }
}
