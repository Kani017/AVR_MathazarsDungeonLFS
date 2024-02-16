using UnityEngine;

// Manages audio feedback for key interactions such as picking up, dropping, and unlocking.
public class KeyAudioFeedback : MonoBehaviour
{
    public AudioClip keyPickupSound;
    public AudioClip keyDropSound;
    public AudioClip keyUnlockSound;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPickupSound()
    {
        if (audioSource && keyPickupSound)
        {
            audioSource.PlayOneShot(keyPickupSound);
        }
    }

    public void PlayDropSound()
    {
        if (audioSource && keyDropSound)
        {
            audioSource.PlayOneShot(keyDropSound);
        }
    }

    public void PlayUnlockSound()
    {
        if (audioSource && keyUnlockSound)
        {
            audioSource.PlayOneShot(keyUnlockSound);
        }
    }
}
