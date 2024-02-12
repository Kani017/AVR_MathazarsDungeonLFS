using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSequenceAudioFeedback : MonoBehaviour
{
    public AudioClip mathazarOutroVoiceline;
    public AudioClip mathazarJumpSound;
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
}


