using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bedroom : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private AudioSource audioSource;

    void Start()
    {
        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(AudioFadeIn(audioSource, 1f));
        GameObject.Find("Main Camera").GetComponent<MetroidCamera>().TurnSoundOff();
        GameObject.Find("G1").GetComponent<G1>().TurnSoundOff();
        GameObject.Find("G2").GetComponent<G2>().TurnSoundOff();
        GameObject.Find("G3").GetComponent<G3>().TurnSoundOff();
        GameObject.Find("G4").GetComponent<G4>().TurnSoundOff();

        GameObject.Find("Door").GetComponent<Door>().TurnSoundOff();
        GameObject.Find("TV").GetComponent<TV>().TurnSoundOff();
        GameObject.Find("Oven").GetComponent<Oven>().TurnSoundOff();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(AudioFadeOut(audioSource, 1f));
        GameObject.Find("Main Camera").GetComponent<MetroidCamera>().TurnSoundOn();
        GameObject.Find("G1").GetComponent<G1>().TurnSoundOn();
        GameObject.Find("G2").GetComponent<G2>().TurnSoundOn();
        GameObject.Find("G3").GetComponent<G3>().TurnSoundOn();
        GameObject.Find("G4").GetComponent<G4>().TurnSoundOn();

        GameObject.Find("Door").GetComponent<Door>().TurnSoundOn();
        GameObject.Find("TV").GetComponent<TV>().TurnSoundOn();
        GameObject.Find("Oven").GetComponent<Oven>().TurnSoundOn();
    }

    public static IEnumerator AudioFadeOut(AudioSource fadeAudioSource, float FadeTime)
    {
        float startVolume = fadeAudioSource.volume;

        while (fadeAudioSource.volume > 0)
        {
            fadeAudioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }

        fadeAudioSource.Stop();
    }

    public static IEnumerator AudioFadeIn(AudioSource fadeAudioSource, float FadeTime)
    {
        fadeAudioSource.Play();

        while (fadeAudioSource.volume < 1f)
        {
            fadeAudioSource.volume += 1f * Time.deltaTime / FadeTime;
            yield return null;
        }
    }
}
