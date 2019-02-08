using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2 : BasicActorMonoBehaviour, IInteractableObject
{
    //TODO: change to state
    public bool justEntered;
    public bool wantsFood;
    public bool isInPlace;

    [SerializeField]
    public AudioSource talkingAudio;

    public AudioLowPassFilter lowPassFilter;

    void Start()
    {
        justEntered = true;
        wantsFood = false;
    }

    public string Interact(string heldItem)
    {
        Debug.Log("Interacting with G2");
        if (justEntered)
        {
            Debug.Log("Entering");
            talkingAudio.PlayOneShot(Resources.Load<AudioClip>("Blop"));
            talkingAudio.Play();
            GameObject.Find("Door").GetComponent<Door>().audioSource.Stop();
            GameObject.Find("Door").GetComponent<Door>().CloseDoor();

            transform.SetParent(GameObject.Find("Livingroom").transform);
            transform.position = GameObject.Find("G2Location").transform.position;

            justEntered = false;
            wantsFood = true;
            isInPlace = true;
            GameObject.Find("Oven").GetComponent<Oven>().OvenReady();
        }
        else if (wantsFood && heldItem == "Food")
        {
            Debug.Log("Thanks!");
            wantsFood = false;
            return "";
        }
        return heldItem;
    }

    public bool IsInteractable()
    {
        return (justEntered || wantsFood);
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
