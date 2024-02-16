using UnityEngine;
using System.Collections;

// Manages the end sequence of the game, including animations, effects, and audio.
public class EndSequence : MonoBehaviour
{
    public Animator mathazarAnimator;
    public ParticleSystem appearanceEffect;
    public AudioClip voiceLine;
    public GameObject credits;
    public Animator creditsAnimation;
    private EndSequenceAudioFeedback endSequenceAudioFeedback;
    public PauseMenuActions pauseMenuActions;

    private void Start()
    {
        endSequenceAudioFeedback = GetComponentInChildren<EndSequenceAudioFeedback>();
        StartCoroutine(SequenceCoroutine());
    }

    // Handles the sequence of events for the end game animation and transition to credits.
    private IEnumerator SequenceCoroutine()
    {
        endSequenceAudioFeedback.PlayGlobalBgMusic();
        mathazarAnimator.SetTrigger("Jump");
        yield return new WaitForSeconds(1f);

        endSequenceAudioFeedback.PlayMathazarOutroVoiceline();
        yield return new WaitForSeconds(voiceLine.length);

        // Mathazar despawns with visual and audio effects.
        endSequenceAudioFeedback.PlayMathazarJumpSound();
        yield return new WaitForSeconds(0.5f);
        appearanceEffect.Play();
        yield return new WaitForSeconds(0.5f);
        mathazarAnimator.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        appearanceEffect.Stop();
        yield return new WaitForSeconds(4f);

        // Triggers and displays the credits along with ending music.
        endSequenceAudioFeedback.PlayEndMusic();
        credits.SetActive(true);
        creditsAnimation.SetBool("Activated", true);
        yield return new WaitForSeconds(28f);
        credits.SetActive(false);

        // Activates the pause menu at the end.
        pauseMenuActions.OnActivate();
    }
}
