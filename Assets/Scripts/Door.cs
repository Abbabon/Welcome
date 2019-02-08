using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractableObject
{
    public AudioSource audioSource;
    public AudioLowPassFilter lowPassFilter;

    public bool openable;
    public bool getG1 = false;
    public bool getG2 = false;
    public bool getG3andG4 = false; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        openable = false;
    }

    public string Interact(string heldItem)
    {
        if (openable)
        {
            audioSource.PlayOneShot(Resources.Load<AudioClip>("Opening_door"));

            //TODO: open door sprite
            GameObject.Find("OpenDoor").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("OpenDoorFrame").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("ClosedDoor").GetComponent<SpriteRenderer>().enabled = false;

            //TODO: summon the guests after opening the door
            if (getG1)
            {
                Debug.Log("SummonG1!");
                SummonG1();
                getG1 = false;
            }else if (getG2)
            {
                Debug.Log("SummonG2!");
                SummonG2();
                getG2 = false;
            }
            else if (getG3andG4)
            {
                Debug.Log("SummonG3 and G4!");
                SummonG3andG4();
                getG3andG4 = false;
            }
            openable = false;
        }
        return heldItem;
    }

    public bool IsInteractable()
    {
        return openable;
    }

    public void TurnSoundOff()
    {
        audioSource.volume = 0.05f;
        lowPassFilter.enabled = true;
    }

    public void TurnSoundOn()
    {
        audioSource.volume = 0.8f;
        lowPassFilter.enabled = false;
    }

    private void SummonG1()
    {
        GameObject.Find("G1").transform.position = GameObject.Find("GuestsStartingLocation").transform.position;
    }

    private void SummonG2()
    {
        GameObject.Find("G2").transform.position = GameObject.Find("GuestsStartingLocation").transform.position;
    }

    private void SummonG3andG4()
    {
        GameObject.Find("G3").transform.position = GameObject.Find("GuestsStartingLocation").transform.position;
        GameObject.Find("G4").transform.position = GameObject.Find("GuestsStartingLocation").transform.position;
        GameObject.Find("G4").GetComponent<G4>().x += 1;
        GameObject.Find("G4").GetComponent<G4>().y += 1;
    }

    //TODO: change door sprite
    public void CloseDoor()
    {
        GameObject.Find("OpenDoor").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("OpenDoorFrame").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("ClosedDoor").GetComponent<SpriteRenderer>().enabled = true;
    }

    public void ShowInteractableSprite()
    {
        GameObject.Find("Door_Halo").GetComponent<SpriteRenderer>().enabled = true;
    }

    public void HideInteractableSprite()
    {
        GameObject.Find("Door_Halo").GetComponent<SpriteRenderer>().enabled = false;
    }
}
