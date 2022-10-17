using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LAstEnemy : MonoBehaviour
{
    public GameObject m_Enemy, light;
    public AudioSource playerAudio, camAudio;
    public AudioClip lastClipl, lastMusic;
    public FirstPersonAIO playerMovement;
    public PlayerInput playerInput;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_Enemy.SetActive(true);
           // light.SetActive(false);
            playerAudio.clip = lastClipl;
            playerAudio.Play();
            camAudio.clip = lastMusic;
            camAudio.Play();
            Cursor.visible = true ;
            Cursor.lockState = CursorLockMode.None;

            // playerInput.enabled = false;
            //playerMovement.playerCanMove = false;
            //playerMovement.enableCameraMovement = false;
            SceneManager.LoadScene("TitleMenu");

            StartCoroutine(LeaveToMenu(3));
        }
    }

    IEnumerator LeaveToMenu(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0;
        SceneManager.LoadScene("TitleMenu");
    }
}
