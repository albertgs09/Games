using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public float time;
    public string scene;
    
    private void Start()
    {
        StartCoroutine(StartTime(time));
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

   private IEnumerator StartTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }
}
