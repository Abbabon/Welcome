using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, IInteractableObject
{
    public bool ringable;

    void Start()
    {
        ringable = true;
    }

    public string Interact(string heldItem)
    {
        Debug.Log("Answering!");

        //TODO: make this delayed:
        //TODO: keep the guests ordered

        GameObject.Find("Door").GetComponent<Door>().getG1 = true;
        GameObject.Find("Door").GetComponent<Door>().openable = true;
        GameObject.Find("Door").GetComponent<Door>().audioSource.Play();

        ringable = false;
        return heldItem;
    }

    public bool IsInteractable()
    {
        return ringable;
    }

    public void ShowInteractableSprite()
    {
        GameObject.Find("Phone_Halo").GetComponent<SpriteRenderer>().enabled = true;
    }

    public void HideInteractableSprite()
    {
        GameObject.Find("Phone_Halo").GetComponent<SpriteRenderer>().enabled = false;
    }
}
