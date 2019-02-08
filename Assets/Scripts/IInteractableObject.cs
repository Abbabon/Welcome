using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableObject
{
    bool IsInteractable();
    void ShowInteractableSprite();
    void HideInteractableSprite();
    string Interact(string heldItem);
}
