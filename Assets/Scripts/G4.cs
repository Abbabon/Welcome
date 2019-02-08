using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G4 : BasicActorMonoBehaviour, IInteractableObject
{
    //TODO: change to state
    public bool justEntered;
    public bool sneezing;
    public bool isInPlace;

    [SerializeField]
    public AudioSource talkingAudio;
    public AudioSource achooAudioSource;

    public AudioLowPassFilter lowPassFilter;

    void Start()
    {
        justEntered = true;
        sneezing = false;
    }

    public string Interact(string heldItem)
    {
        Debug.Log("Interacting with G4");
        if (justEntered)
        {
            Debug.Log("G4 Entering");
            achooAudioSource.PlayOneShot(Resources.Load<AudioClip>("Blop"));
            talkingAudio.Play();
            GameObject.Find("Door").GetComponent<AudioSource>().Stop();
            GameObject.Find("Door").GetComponent<Door>().CloseDoor();

            transform.SetParent(GameObject.Find("Livingroom").transform);
            transform.position = GameObject.Find("G4Location").transform.position;

            justEntered = false;
            isInPlace = true;
            StartSneezing();
        }
        else if (sneezing && heldItem == "Tissue") 
        {
            Debug.Log("Thanks!");
            sneezing = false;
            achooAudioSource.Stop();
            achooAudioSource.PlayOneShot(Resources.Load<AudioClip>("Give_Tissue"));

            return "";
        }
        return heldItem;
    }

    public bool IsInteractable()
    {
        return (justEntered || sneezing);
    }

    public void StartSneezing()
    {
        sneezing = true;
        achooAudioSource.Play();
        GameObject.Find("TissueBox").GetComponent<TissueBox>().TissueBoxReady();
    }

    public void TurnSoundOff()
    {
        talkingAudio.volume = 0.15f;
        achooAudioSource.volume = 0.15f;
        lowPassFilter.enabled = true;
    }

    public void TurnSoundOn()
    {
        talkingAudio.volume = 0.8f;
        achooAudioSource.volume = 0.8f;
        lowPassFilter.enabled = false;
    }

    public void ShowInteractableSprite()
    {

    }

    public void HideInteractableSprite()
    {

    }
}
