// This script handles the audio feedback for book interactions such as picking up, dropping, and snapping into place.

using UnityEngine;

public class BookAudioFeedback : MonoBehaviour
{
    public AudioClip bookPickupSound;
    public AudioClip bookDropSound;
    public AudioClip bookSnappingSound;
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
