using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour, IInteractableObject
{
    private bool soundStatic;
    private AudioSource audioSource;
    public AudioLowPassFilter lowPassFilter;

    // Start is called before the first frame update
    void Start()
    {
        soundStatic = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string Interact(string heldItem)
    {
        if (soundStatic)
        {
            //TODO: change audio clip to normal tv sound
            audioSource.Stop();
            soundStatic = false;

            if (GameObject.Find("G2").GetComponent<G2>().isInPlace)
            {
                GameObject.Find("Oven").GetComponent<Oven>().OvenReady();
                GameObject.Find("G2").GetComponent<G2>().wantsFood = true;
            }
            else //first time around
            {
                GameObject.Find("Door").GetComponent<Door>().getG2 = true;
                GameObject.Find("Door").GetComponent<Door>().openable = true;
                GameObject.Find("Door").GetComponent<Door>().audioSource.Play();
            }
        }
        return heldItem;
    }

    public bool IsInteractable()
    {
        return soundStatic;
    }

    public void StartStatic()
    {
        audioSource.Play();
        soundStatic = true;
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

    public void ShowInteractableSprite()
    {
        GameObject.Find("TV_Halo").GetComponent<SpriteRenderer>().enabled = true;
    }

    public void HideInteractableSprite()
    {
        GameObject.Find("TV_Halo").GetComponent<SpriteRenderer>().enabled = false;
    }
}
