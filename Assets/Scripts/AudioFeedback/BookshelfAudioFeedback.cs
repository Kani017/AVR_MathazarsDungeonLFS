using UnityEngine;

// This script provides audio feedback for interactions with the bookshelf, such as placing the correct book and solving all questions.
public class BookshelfAudioFeedback : MonoBehaviour
{
    //public AudioClip wrongBookSound;
    public AudioClip correctBookSound;
    public AudioClip allQuestionsSolvedSound;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /*public void PlayWrongBookSound()
    {
        if (audioSource && wrongBookSound)
        {
            audioSource.PlayOneShot(wrongBookSound);
        }
    }*/

    public void PlayCorrectBookSound()
    {
        if (audioSource && correctBookSound)
        {
            audioSource.PlayOneShot(correctBookSound);
        }
    }

    public void PlayAllQuestionsSolvedSound()
    {
        if (audioSource && allQuestionsSolvedSound)
        {
            audioSource.PlayOneShot(allQuestionsSolvedSound);
        }
    }
}
