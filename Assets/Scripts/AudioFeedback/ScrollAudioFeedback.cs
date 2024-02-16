using UnityEngine;

// Handles audio feedback for scroll interactions such as picking up and dropping the scroll.
public class ScrollAudioFeedback : MonoBehaviour
{
    public AudioClip scrollPickupSound;
    public AudioClip scrollDropSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPickupSound()
    {
        if (audioSource && scrollPickupSound)
        {
            audioSource.PlayOneShot(scrollPickupSound);
        }
    }
    public void PlayDropSound()
    {
        if (audioSource && scrollDropSound)
        {
            audioSource.PlayOneShot(scrollDropSound);
        }
    }
}
