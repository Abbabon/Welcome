using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea2 : MonoBehaviour
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
            //restart sequence!
            GameObject.Find("TV").GetComponent<TV>().StartStatic();
            triggerable = false;
        }
    }
}
