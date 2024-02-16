// Manages audio feedback for lectern interactions, such as starting, ending help, and flipping pages.

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
            audioSource.Stop(); // Stop any currently playing voicelines to stop them overlapping
            audioSource.PlayOneShot(StartEndHelpSound);
        }
    }
    public void PlayPageOneSound()
    {
        if (audioSource && PageOneSound)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(PageOneSound);
        }
    }

    public void PlayPageTwoSound()
    {
        if (audioSource && PageTwoSound)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(PageTwoSound);
        }
    }

    public void PlayPageThreeSound()
    {
        if (audioSource && PageThreeSound)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(PageThreeSound);
        }
    }
}
