using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour, IInteractableObject
{
    private bool hasFood;
    private AudioSource audioSource;
    public AudioLowPassFilter lowPassFilter;

    void Start()
    {
        hasFood = false;
        audioSource = GetComponent<AudioSource>();
    }

    public string Interact(string heldItem)
    {
        if (string.IsNullOrEmpty(heldItem) && hasFood)
        {
            Debug.Log("GivingFood!");
            audioSource.Stop();
            hasFood = false;

            GameObject.Find("TriggerArea1").GetComponent<TriggerArea1>().triggerable = true;
            return "Food";
        }
        return heldItem;
    }

    public bool IsInteractable()
    {
        return hasFood;
    }

    public void OvenReady()
    {
        hasFood = true;
        audioSource.Play();
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
        GameObject.Find("Oven_Halo").GetComponent<SpriteRenderer>().enabled = true;
    }

    public void HideInteractableSprite()
    {
        GameObject.Find("Oven_Halo").GetComponent<SpriteRenderer>().enabled = false;
    }
}
