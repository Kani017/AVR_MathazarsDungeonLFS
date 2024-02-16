// This script manages audio feedback for cheese pickup and drop interactions within the game.

using UnityEngine;

public class CheeseAudioFeedback : MonoBehaviour
{
    public AudioClip cheesePickupSound;
    public AudioClip cheeseDropSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPickupSound()
    {
        if (audioSource && cheesePickupSound)
        {
            audioSource.PlayOneShot(cheesePickupSound);
        }
    }

    public void PlayDropSound()
    {
        if (audioSource && cheeseDropSound)
        {
            audioSource.PlayOneShot(cheeseDropSound);
        }
    }
}
