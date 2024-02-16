using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightAudioFeedback : MonoBehaviour
{
    public AudioClip weightSnappingSound;
    public AudioClip weightPickupSound;
    public AudioClip weightDropSound;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPickupSound()
    {
        if (audioSource && weightPickupSound)
        {
            audioSource.PlayOneShot(weightPickupSound);
        }
    }
    public void PlayDropSound()
    {
        if (audioSource && weightDropSound)
        {
            audioSource.PlayOneShot(weightDropSound);
        }
    }

    public void PlaySnappingSound()
    {
        if (audioSource && weightSnappingSound)
        {
            audioSource.PlayOneShot(weightSnappingSound);
        }
    }
}
