using UnityEngine;

// Manages opening of the cell door, removing the raycast blockers and the mathazar sequence.
public class CellDoorInteraction : MonoBehaviour
{
    public Animator cellDoorAnimator;
    public BoxCollider boxCollider;
    public GameObject blockerToDestroy1, blockerToDestroy2;
    private AudioSource audioSource;
    public GameObject MathazarInteraction, mathazarGameObject;

    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }

    public void OpenCellDoor()
    {
        // Open the door and trigger related interactions
        cellDoorAnimator.SetBool("Activated", true);
        audioSource.Play(); // Door creaking sound
        Destroy(boxCollider);
        Destroy(blockerToDestroy1);
        Destroy(blockerToDestroy2);
        mathazarGameObject.SetActive(true); // Start Mathazar interaction sequence
        MathazarInteraction.SetActive(true);
    }
}
