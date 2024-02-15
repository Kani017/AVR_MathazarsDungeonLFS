using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LecternAudioFeedback : MonoBehaviour
{
    public AudioClip StartEndHelpSound;
    public AudioClip ForwardBackSound;
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
    public void PlayForwardBackSound()
    {
        if (audioSource && ForwardBackSound)
        {
            audioSource.PlayOneShot(ForwardBackSound);
        }
    }
}
