using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroidCamera : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D cameraBox;

    [SerializeField]
    private GameObject player;

    public float smoothSpeed = 2.0f;
    public Vector3 offset = new Vector3(0, 0, -1);

    public AudioSource firstAudioSource;
    public AudioSource secondAudioSource;
    public AudioLowPassFilter lowPassFilter;

    void Start()
    {
        player = GameObject.Find("Player");
        cameraBox = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //AspectBoxRatioChange();
        FollowPlayer();
    }

    private void AspectBoxRatioChange()
    {
        throw new NotImplementedException();
    }   

    private void FollowPlayer()
    {
        if (GameObject.Find("Boundary"))
        {
            float x = Mathf.Clamp(player.transform.position.x, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.x + cameraBox.size.x / 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.x - cameraBox.size.x / 2);
            float y = Mathf.Clamp(player.transform.position.y, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.y + cameraBox.size.y / 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.y - cameraBox.size.y / 2);

          
            Vector3 desiredPosition = new Vector3(x, y, transform.position.z) + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        }
    }

    public void TurnSoundOff()
    {
        firstAudioSource.volume = 0.15f;
        secondAudioSource.volume = 0.15f;
        lowPassFilter.enabled = true;
    }

    public void TurnSoundOn()
    {
        firstAudioSource.volume = 0.3f;
        secondAudioSource.volume = 0.3f;
        lowPassFilter.enabled = false;
    }
}
