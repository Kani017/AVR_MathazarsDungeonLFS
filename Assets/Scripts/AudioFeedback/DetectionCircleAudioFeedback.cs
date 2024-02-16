// Manages audio feedback for events within the detection circle, such as solving a question or all questions.

using UnityEngine;

public class DetectionCircleAudioFeedback : MonoBehaviour
{
    public AudioClip questionSolvedSound;
    public AudioClip allQuestionsSolvedSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayQuestionSolvedSound()
    {
        if (audioSource && questionSolvedSound)
        {
            audioSource.PlayOneShot(questionSolvedSound);
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
