using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCreatures : MonoBehaviour
{
  public GameObject m_Creatures, m_Creatures2, growl;
    public Light ceilingLight;
    public AudioSource playerAudio;
    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_Creatures.GetComponent<Creature2ndEncounter>().enabled = true;
            m_Creatures2.GetComponent<Creature2ndEncounter>().enabled = true;
            StartCoroutine(FlashLights(.2f));
        }
    }

    private IEnumerator FlashLights(float light)
    {
        yield return new WaitForSeconds(light);
        ceilingLight.enabled = true;
         yield return new WaitForSeconds(light);
        ceilingLight.enabled = false;
         yield return new WaitForSeconds(.2f);
        ceilingLight.enabled = true;
         yield return new WaitForSeconds(.4f);
        ceilingLight.enabled = false;
         yield return new WaitForSeconds(.6f);
        ceilingLight.enabled = true;
        yield return new WaitForSeconds(1.2f);
        ceilingLight.enabled = false;
        yield return new WaitForSeconds(.5f);
        playerAudio.clip = clip;
        playerAudio.Play();
       
       
        Destroy(gameObject);
        Destroy(growl);
    }
}
