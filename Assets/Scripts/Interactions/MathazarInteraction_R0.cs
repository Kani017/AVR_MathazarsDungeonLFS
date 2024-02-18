using UnityEngine;
using System.Collections;

public class MathazarInteraction_R0 : MonoBehaviour
{
    public GameObject mathazarGameObject; 
    public ParticleSystem appearEffect; 
    public AudioSource audioSource; 
    public AudioClip voiceline_R0; 
    public AudioClip teleportSound; 
    public AudioClip appearSound; 
    private RiddleManager riddleManager; 

    private void Start()
    {
        riddleManager = RiddleManager.Instance;
    }
    void OnEnable() 
    {
        StartCoroutine(SequenceCoroutine());
    }

    // Sequence that spawns Mathazar, plays a voiceline, despawns him with a sound effect and finally makes this room's lever interactable
    private IEnumerator SequenceCoroutine()
    {
        appearEffect.Play();
        audioSource.PlayOneShot(appearSound);
        yield return new WaitForSeconds(1f);
        mathazarGameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        appearEffect.Stop();
        audioSource.PlayOneShot(voiceline_R0);
        yield return new WaitForSeconds(voiceline_R0.length);
        audioSource.PlayOneShot(teleportSound);
        appearEffect.Play();
        yield return new WaitForSeconds(1f);
        mathazarGameObject.SetActive(false);
        appearEffect.Stop();

        riddleManager.SolveRiddle(0);
    }
}
