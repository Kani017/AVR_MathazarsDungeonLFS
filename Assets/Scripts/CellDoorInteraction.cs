using System.Collections;
using UnityEngine;

public class CellDoorInteraction : MonoBehaviour
{
    public Animator cellDoorAnimator;
    public BoxCollider boxCollider;
    public GameObject blockerToDestroy1;
    public GameObject blockerToDestroy2;
    private AudioSource audioSource;
    private RiddleManager riddleManager;
    public GameObject mathazarGameObject; // Direct reference to Mathazar GameObject

    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        riddleManager = RiddleManager.Instance;
    }

    public void OpenCellDoor()
    {
        Debug.Log("OpenCellDoor method called");
        cellDoorAnimator.SetBool("Activated", true);
        PlayCreakingSound();
        Destroy(boxCollider);
        Destroy(blockerToDestroy1);
        Destroy(blockerToDestroy2);

        // Aktiviere das Mathazar GameObject, um die Sequenz zu starten
        if (mathazarGameObject != null)
            mathazarGameObject.SetActive(true);

        Debug.Log("function ran through");
    }

    private void PlayCreakingSound()
    {
        audioSource.Play();
    }
}
