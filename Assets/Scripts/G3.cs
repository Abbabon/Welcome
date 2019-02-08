using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G3 : BasicActorMonoBehaviour, IInteractableObject
{
    //TODO: change to state
    public bool justEntered;

    [SerializeField]
    public AudioSource talkingAudio;

    public AudioLowPassFilter lowPassFilter;

    void Start()
    {
        justEntered = true;
    }

    public string Interact(string heldItem)
    {
        Debug.Log("Interacting with G3");
        if (justEntered)
        {
            Debug.Log("Entering");
            talkingAudio.PlayOneShot(Resources.Load<AudioClip>("Blop"));
            talkingAudio.Play();
            GameObject.Find("Door").GetComponent<Door>().audioSource.Stop();

            transform.SetParent(GameObject.Find("Livingroom").transform);
            transform.position = GameObject.Find("G3Location").transform.position;

            justEntered = false;
        }

        return heldItem;
    }

    public bool IsInteractable()
    {
        return (justEntered);
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
