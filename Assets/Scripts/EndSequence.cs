using UnityEngine;
using System.Collections;

public class EndSequence : MonoBehaviour
{
    public Animator mathazarAnimator;
    public ParticleSystem appearanceEffect;
    public AudioClip voiceLine;
    public GameObject credits;
    public Animator creditsAnimation; // Reference to the Animation component for credits
    private EndSequenceAudioFeedback endSequenceAudioFeedback;
    public PauseMenuActions pauseMenuActions;

    private void Start()
    {
        endSequenceAudioFeedback = GetComponentInChildren<EndSequenceAudioFeedback>();
        StartCoroutine(SequenceCoroutine());
    }

    private IEnumerator SequenceCoroutine()
    {
        endSequenceAudioFeedback.PlayGlobalBgMusic();
        // Play Anim
        mathazarAnimator.SetTrigger("Jump");
        yield return new WaitForSeconds(1f);


        // Play Mathazar's voice line
        endSequenceAudioFeedback.PlayMathazarOutroVoiceline();
        yield return new WaitForSeconds(voiceLine.length);


        //Mathazar despawn
        endSequenceAudioFeedback.PlayMathazarJumpSound();
        yield return new WaitForSeconds(0.5f);
        appearanceEffect.Play();
        yield return new WaitForSeconds(0.5f);
        mathazarAnimator.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        appearanceEffect.Stop();
        yield return new WaitForSeconds(4f);


        // Trigger the credits animation
        endSequenceAudioFeedback.PlayEndMusic();
        credits.SetActive(true);
        creditsAnimation.SetBool("Activated", true);
        yield return new WaitForSeconds(28f);
        credits.SetActive(false);



        //End Men� hier
        pauseMenuActions.OnActivate();
    }
}
