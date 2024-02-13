using UnityEngine;
using System.Collections;

public class MathazarInteraction_R0 : MonoBehaviour
{
    public GameObject mathazarGameObject; // Assign in Inspector
    public ParticleSystem appearEffect; // Assign in Inspector
    public AudioSource audioSource; // Assign in Inspector
    public AudioClip voiceline_R0; // Assign in Inspector
    public AudioClip teleportSound; // Assign in Inspector
    public AudioClip appearSound; // Assign in Inspector
    private RiddleManager riddleManager; // Referenz auf den RiddleManager
    void OnEnable() // Verwenden Sie OnEnable anstelle von Start
    {
        StartCoroutine(SequenceCoroutine());
    }


    private IEnumerator SequenceCoroutine()
    {
        UnityEngine.Debug.Log("M R0 worked");
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
