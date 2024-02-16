using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LecternAudioFeedback : MonoBehaviour
{
    public AudioClip StartEndHelpSound;
    public AudioClip PageOneSound;
    public AudioClip PageTwoSound;
    public AudioClip PageThreeSound;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayStartEndHelpSound()
    {
        if (audioSource && StartEndHelpSound)
        {
            audioSource.PlayOneShot(StartEndHelpSound);
        }
    }
    public void PlayPageOneSound()
    {
        if (audioSource && PageOneSound)
        {
            audioSource.PlayOneShot(PageOneSound);
        }
    }

    public void PlayPageTwoSound()
    {
        if (audioSource && PageTwoSound)
        {
            audioSource.PlayOneShot(PageTwoSound);
        }
    }

    public void PlayPageThreeSound()
    {
        if (audioSource && PageThreeSound)
        {
            audioSource.PlayOneShot(PageThreeSound);
        }
    }
}
