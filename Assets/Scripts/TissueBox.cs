using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueBox : MonoBehaviour, IInteractableObject
{
    private bool hasTissue;
    public AudioSource audioSource;

    void Start()
    {
        hasTissue = false;
    }

    public string Interact(string heldItem)
    {
        if (string.IsNullOrEmpty(heldItem) && hasTissue)
        {
            Debug.Log("GivingTissues!");
            hasTissue = false;
            audioSource.PlayOneShot(Resources.Load<AudioClip>("Take_Tissue"));

            GameObject.Find("TriggerArea2").GetComponent<TriggerArea2>().triggerable = true; 
            return "Tissue";
        }
        return heldItem;
    }

    public bool IsInteractable()
    {
        return hasTissue;
    }

    public void TissueBoxReady()
    {
        hasTissue = true;
    }

    public void ShowInteractableSprite()
    {
        GameObject.Find("Tissue_Halo").GetComponent<SpriteRenderer>().enabled = true;
    }

    public void HideInteractableSprite()
    {
        GameObject.Find("Tissue_Halo").GetComponent<SpriteRenderer>().enabled = false;
    }
}
