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
