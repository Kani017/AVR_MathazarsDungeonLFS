using UnityEngine;

// Handles the playback of specific audio clips associated with the end sequence, including outro lines, jump sounds, and music transitions.
public class EndSequenceAudioFeedback : MonoBehaviour
{
    public AudioClip mathazarOutroVoiceline;
    public AudioClip mathazarJumpSound;
    public AudioClip endMusic;
    public AudioClip globalBgMusic;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMathazarOutroVoiceline()
    {
        if (audioSource && mathazarOutroVoiceline)
        {
            audioSource.PlayOneShot(mathazarOutroVoiceline);
        }
    }

    public void PlayMathazarJumpSound()
    {
        if (audioSource && mathazarJumpSound)
        {
            audioSource.PlayOneShot(mathazarJumpSound);
        }
    }

    public void StopBackgroundMusic()
    {
        if (audioSource)
        {
            audioSource.Stop(); // Stops any currently playing music
        }
    }

    public void PlayEndMusic()
    {
        if (audioSource && endMusic)
        {
            StopBackgroundMusic(); // Ensures the background music is stopped
            audioSource.PlayOneShot(endMusic); // Plays the ending music
        }
    }

    public void PlayGlobalBgMusic()
    {
        if (audioSource && globalBgMusic)
        {
            audioSource.PlayOneShot(globalBgMusic);
        }
    }
}
