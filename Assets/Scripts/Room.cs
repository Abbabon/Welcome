using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : BasicActorMonoBehaviour
{
    [SerializeField]
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        if (!GetComponent<Collider2D>().bounds.Contains(player.transform.position))
        {
            DarkenRoom();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entering");
            //StartCoroutine(FadeToFullAlpha(0.5f, GetComponent<SpriteRenderer>()));
            LightenRoom();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Leaving");
            //StartCoroutine(FadeToZeroAlpha(0.5f, GetComponent<SpriteRenderer>()));
            DarkenRoom();
        }
    }

    private void LightenRoom()
    {
        for (int i=0; i < transform.childCount; i++)
        {
            SpriteRenderer sr = transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            if (sr){
                sr.color = Color.white;
            }

        }

    }

    private void DarkenRoom()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            SpriteRenderer sr = transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            if (sr)
            {
                sr.color = Color.grey;
            }
        }
    }
}
