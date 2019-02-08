using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : BasicActorMonoBehaviour
{
    public float speed = 3.5f;

    [SerializeField]
    public HashSet<IInteractableObject> interactableObjects;

    //TODO: needs to be changed if we want to drop objects (or deliver them somehow)
    public GameObject heldItem;
    public string heldItemType;

    // Player Capabilities
    void Start () {
        interactableObjects = new HashSet<IInteractableObject>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        HandleMovement();
        HandleInteraction();
    }

    void HandleMovement()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float xTranslation = Input.GetAxis("Horizontal") * speed;
        float yTranslation = Input.GetAxis("Vertical") * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        xTranslation *= Time.deltaTime;
        yTranslation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(new Vector3(xTranslation, yTranslation, 0));
    }

    void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (IInteractableObject interactableObject in interactableObjects)
            {
                if (interactableObject.IsInteractable())
                {
                    heldItemType = interactableObject.Interact(heldItemType);
                    if (string.IsNullOrEmpty(heldItemType))
                    {
                        heldItem.GetComponent<SpriteRenderer>().sprite = null;
                    }
                    else
                    {
                        heldItem.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(heldItemType);
                    }

                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        if (collision.gameObject.GetComponent<IInteractableObject>() != null)
        {
            interactableObjects.Add(collision.GetComponent<IInteractableObject>());
            collision.GetComponent<IInteractableObject>().ShowInteractableSprite();
            Debug.Log(collision.gameObject.GetComponent<IInteractableObject>().ToString());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnTriggerExit2D");
        if (collision.gameObject.GetComponent<IInteractableObject>() != null)
        {
            collision.GetComponent<IInteractableObject>().HideInteractableSprite();
            interactableObjects.Remove(collision.gameObject.GetComponent<IInteractableObject>());
            Debug.Log(collision.gameObject.GetComponent<IInteractableObject>().ToString());
        }
    }
}
