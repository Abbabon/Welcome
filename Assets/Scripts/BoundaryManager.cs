using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D managerBox;

    [SerializeField]
    public GameObject boundary;

    [SerializeField]
    private GameObject player;

    void Start()
    {
        managerBox = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        ManageBoundary();
    }

    private void ManageBoundary()
    {
        if (boundary && managerBox.bounds.Contains(player.transform.position)){
            boundary.SetActive(true);
        }
        else{
            boundary.SetActive(false);
        }
    }
}
