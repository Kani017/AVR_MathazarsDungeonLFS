using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            audioSource.Stop(); // Stoppt jegliche aktuell spielende Musik
        }
    }

    public void PlayEndMusic()
    {
        if (audioSource && endMusic)
        {
            StopBackgroundMusic(); // Stellt sicher, dass die Hintergrundmusik gestoppt wird
            audioSource.PlayOneShot(endMusic); // Spielt die Endmusik
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


