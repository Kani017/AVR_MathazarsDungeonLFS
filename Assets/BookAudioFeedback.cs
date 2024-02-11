using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAudioFeedback : MonoBehaviour
{
    public AudioClip bookSnappingSound;
    public AudioClip bookPickupSound;
    public AudioClip bookDropSound;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPickupSound()
    {
        if (audioSource && bookPickupSound)
        {
            audioSource.PlayOneShot(bookPickupSound);
        }
    }
    public void PlayDropSound()
    {
        if (audioSource && bookDropSound)
        {
            audioSource.PlayOneShot(bookDropSound);
        }
    }

    public void PlaySnappingSound()
    {
        if (audioSource && bookSnappingSound)
        {
            audioSource.PlayOneShot(bookSnappingSound);
        }
    }
}
