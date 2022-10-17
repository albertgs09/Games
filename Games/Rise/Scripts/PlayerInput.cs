using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerInput : MonoBehaviour
{
    public float interactionDistance = 3;
    public GameObject reticle, activateColliders, instructions, death;
    GameObject door;
    public Text inGameText;
    public Sprite reticleHighlightedImage;
    public Sprite reticleDimmedImage;
    public AudioClip offSound, scare, fallAudio, doorOpen, doorLocked, pickedUpKey, lastMusic;
    private AudioSource audioSource;
    public AudioSource camAudio;
    public PauseController pauseController;
    readonly string lockedText = "Door is locked, you need the right key to open it.";
    readonly string headToFrontDoor = "Got it! Time to get out of here!";
    bool canOpenDoor = false;
    public bool hasKey = false, hasRoofKey = false, hasFrontDoorKey = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
       EnvironmentInteractions();
       Raycasting();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            door = other.gameObject;
            canOpenDoor = true; 
        }
        if (other.gameObject.CompareTag("RoofDoor"))
        {
            door = other.gameObject;
            canOpenDoor = true; 
        }
        if (other.gameObject.CompareTag("FrontDoor"))
        {
            door = other.gameObject;
            canOpenDoor = true; 
        }


        if (other.gameObject.CompareTag("Trigger1"))
        {
            audioSource.clip = scare;
            audioSource.Play();
        }

        if (other.gameObject.CompareTag("EnemyCrawlers"))
        {
            death.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            canOpenDoor = false;
            instructions.SetActive(false);

        }
        if (other.gameObject.CompareTag("FrontDoor"))
        {
            canOpenDoor = false;
            instructions.SetActive(false);

        }
        if (other.gameObject.CompareTag("RoofDoor"))
        {
            canOpenDoor = false;
            instructions.SetActive(false) ;

        } 
        if (other.gameObject.CompareTag("FollowCrawlers"))
        {
            instructions.SetActive(false) ;

        }

        if (other.gameObject.CompareTag("Trigger2"))
        {
            audioSource.clip = fallAudio;
            audioSource.Play();
        }
    }

    private void Raycasting()
    {
        // Create a line from the player's camera in the direction it's facing
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit; // variable to store whatever the ray hits


        // If the line hit something within the interactionDistance
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // If the object being looked at is a terminal
            if (hit.transform.gameObject.CompareTag("Key"))
            {
                
                // if left button pressed
                if (Input.GetMouseButtonDown(0))
                {
                    hasKey = true;
                    KeyPickedUp();// plays audio
                    pauseController.key1.color = Color.green;
                    Destroy(hit.transform.gameObject);
                }
            }

            if (hit.transform.gameObject.CompareTag("KeyFrontDoor"))
            {
          
                // if left button pressed
                if (Input.GetMouseButtonDown(0))
                {
                    KeyPickedUp();// plays audio
                    hasFrontDoorKey = true;
                    activateColliders.SetActive(true);
                    instructions.SetActive(true);
                    inGameText.text = headToFrontDoor;
                    pauseController.key3.color = Color.green;
                    Destroy(hit.transform.gameObject);
                }



            }
            if (hit.transform.gameObject.CompareTag("KeyRoof"))
            {
          
                // if left button pressed
                if (Input.GetMouseButtonDown(0))
                {
                    KeyPickedUp();// plays audio
                    hasRoofKey = true;
                    pauseController.key2.color = Color.green;
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
    private void EnvironmentInteractions()
    {
        if (canOpenDoor && hasKey && door.GetComponent<OpenDoor>().doorName == "Door")
        {
            if (Input.GetMouseButtonDown(0))
            {
                door.GetComponent<SphereCollider>().enabled = false;
                canOpenDoor = false;
                door.GetComponent<OpenDoor>().canOpen = true;
                DoorOpen();
            }
        }
        else if (canOpenDoor && hasKey == false && door.GetComponent<OpenDoor>().doorName == "Door")
        {
            if (Input.GetMouseButtonDown(0))
            {
                DoorLocked();
            }
        }



        if (canOpenDoor && hasFrontDoorKey && door.GetComponent<OpenDoor>().doorName == "FrontDoor")
        {
            if (Input.GetMouseButtonDown(0))
            {
                door.GetComponent<SphereCollider>().enabled = false;
                canOpenDoor = false;

                door.GetComponent<OpenDoor>().canOpen = true;
                DoorOpen();
            }
        } 
        else if (canOpenDoor && hasFrontDoorKey == false && door.GetComponent<OpenDoor>().doorName == "FrontDoor")
        {
            if (Input.GetMouseButtonDown(0))
            {
               DoorLocked();
            }
        }
        
       


        if (canOpenDoor && hasRoofKey && door.GetComponent<OpenDoor>().doorName == "RoofDoor")
        {
            if (Input.GetMouseButtonDown(0))
            {
                door.GetComponent<OpenDoor>().canOpen = true;
                door.GetComponent<SphereCollider>().enabled = false;
                canOpenDoor = false;

                camAudio.clip = lastMusic;
                camAudio.Play();    
                DoorOpen();
            }
        }
        else if (canOpenDoor && hasRoofKey == false && door.GetComponent<OpenDoor>().doorName == "RoofDoor")
        {
            if (Input.GetMouseButtonDown(0))
            {
                DoorLocked();
            }
        }

    }

    void DoorOpen()
    {
        audioSource.clip = doorOpen;
        audioSource.Play();
    }

    void DoorLocked()
    {
        instructions.SetActive(true);
        inGameText.text = lockedText;
        audioSource.clip = doorLocked;
        audioSource.Play();
    }

    void KeyPickedUp()
    {
        audioSource.clip = pickedUpKey;
        audioSource.Play();
    }
}
