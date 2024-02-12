using UnityEngine;
using System.Collections;

public class EndSequence : MonoBehaviour
{
    public Animator mathazarAnimator;
    public ParticleSystem appearanceEffect;
    public AudioSource audioSource;
    public AudioClip voiceLine;
    public AudioClip jumpSound;
    public GameObject credits;
    public Animator creditsAnimation; // Reference to the Animation component for credits

    private void Start()
    {
        StartCoroutine(SequenceCoroutine());
    }

    private IEnumerator SequenceCoroutine()
    {

        // Play Anim
        mathazarAnimator.SetTrigger("Jump");
        yield return new WaitForSeconds(1f);


        // Play Mathazar's voice line
        audioSource.PlayOneShot(voiceLine);
        yield return new WaitForSeconds(voiceLine.length);


        //Mathazar despawn
        appearanceEffect.Play();
        audioSource.PlayOneShot(jumpSound);
        yield return new WaitForSeconds(0.5f);
        mathazarAnimator.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        appearanceEffect.Stop();
        yield return new WaitForSeconds(2f);


        // Trigger the credits animation
        credits.SetActive(true);
        creditsAnimation.SetBool("Activated", true);
        yield return new WaitForSeconds(28f);
        credits.SetActive(false);



        //End Menü hier
    }
}
