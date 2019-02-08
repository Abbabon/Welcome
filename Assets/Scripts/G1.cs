using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1 : BasicActorMonoBehaviour, IInteractableObject
{
    //TODO: change to state
    public bool justEntered;

    [SerializeField]
    private AudioSource talkingAudio;

    public AudioLowPassFilter lowPassFilter;

    void Start()
    {
        justEntered = true;
    }

    public string Interact(string heldItem)
    {
        Debug.Log("Interacting with G1");
        if (justEntered)
        {
            Debug.Log("Entering");
            talkingAudio.PlayOneShot(Resources.Load<AudioClip>("Blop"));
            talkingAudio.Play();
            GameObject.Find("Door").GetComponent<Door>().audioSource.Stop();
            GameObject.Find("Door").GetComponent<Door>().CloseDoor();

            transform.SetParent(GameObject.Find("Livingroom").transform);
            transform.position = GameObject.Find("G1Location").transform.position;

            justEntered = false;


            //TODO: change the sound if the tv will have other sounds
            GameObject.Find("TV").GetComponent<TV>().StartStatic();
        }
        return heldItem;
    }

    public bool IsInteractable()
    {
        return justEntered;
    }

    public void TurnSoundOff()
    {
        talkingAudio.volume = 0.15f;
        lowPassFilter.enabled = true;
    }

    public void TurnSoundOn()
    {
        talkingAudio.volume = 0.8f;
        lowPassFilter.enabled = false;
    }

    public void ShowInteractableSprite()
    {

    }

    public void HideInteractableSprite()
    {

    }
}
