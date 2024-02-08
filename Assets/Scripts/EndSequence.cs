using UnityEngine;
using System.Collections;

public class EndSequence : MonoBehaviour
{
    public Animator mathazarAnimator;
    public ParticleSystem appearanceEffect;
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip voiceLine;
    public GameObject credits;
    public Animation creditsAnimation; // Reference to the Animation component for credits

    private void Start()
    {
        StartCoroutine(SequenceCoroutine());
    }

    private IEnumerator SequenceCoroutine()
    {
        // Initial delay
        yield return new WaitForSeconds(2f);

        // Particle effect for appearance
        appearanceEffect.Play();
        yield return new WaitForSeconds(appearanceEffect.main.duration);
        yield return new WaitForSeconds(2f); // Additional delay to observe the particle effect

        // Mathazar jumps in with sound
        mathazarAnimator.SetTrigger("Jump");
        audioSource.PlayOneShot(jumpSound);
        yield return new WaitForSeconds(jumpSound.length);
        yield return new WaitForSeconds(2f); // Additional delay to observe the jump and sound

        // Play Mathazar's voice line
        audioSource.PlayOneShot(voiceLine);
        yield return new WaitForSeconds(voiceLine.length);
        yield return new WaitForSeconds(2f); // Additional delay after the voice line

        // Mathazar disappears with jump animation
        mathazarAnimator.SetTrigger("Jump");
        yield return new WaitForSeconds(mathazarAnimator.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(2f); // Additional delay to observe the disappearance

        // Trigger the credits animation
        credits.SetActive(true);
        creditsAnimation.Play();
        yield return new WaitForSeconds(2f); // Additional delay before the credits scroll

        // Wait for the credits animation to finish, assuming it's not looped
        // If the credits animation is looped, you'll need to handle it differently
        yield return new WaitWhile(() => creditsAnimation.isPlaying);
    }
}
