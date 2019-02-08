using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea1 : MonoBehaviour
{
    public bool triggerable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && triggerable)
        {
            if (GameObject.Find("G4").GetComponent<G4>().isInPlace)
            {
                GameObject.Find("G4").GetComponent<G4>().StartSneezing();
            }
            else
            {
                GameObject.Find("Door").GetComponent<Door>().getG3andG4 = true;
                GameObject.Find("Door").GetComponent<Door>().openable = true;
                GameObject.Find("Door").GetComponent<Door>().audioSource.Play();
            }
        }
        triggerable = false;
    }
}
