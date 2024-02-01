using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeverInteraction : MonoBehaviour
{
    public Animator leverAnimator; // Animator for the lever, assign in the inspector
    public DoorInteraction doorInteraction; // DoorInteraction script, assign in the inspector
    public int riddleIndex; // Index for the specific riddle this lever is associated with, assign in the inspector
    private XRSimpleInteractable interactable;
    private ParticleSystem leverInteractableParticles;

    private bool hasBeenActivated = false; // Flag to track if the lever has been activated once

    private void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.enabled = false; // Start with the lever as non-interactable
        leverInteractableParticles = GetComponentInChildren<ParticleSystem>();
        leverInteractableParticles.Stop(); // Ensure the particle system is not playing initially
    }

    private void OnEnable()
    {
        RiddleManager.OnRiddleSolved += CheckRiddleSolved;
    }

    private void OnDisable()
    {
        RiddleManager.OnRiddleSolved -= CheckRiddleSolved;
    }

    private void CheckRiddleSolved()
    {
        // Check if the riddle for this lever is solved
        if (RiddleManager.Instance.isRiddleSolved[riddleIndex])
        {
            MakeLeverInteractable();
        }
    }

    public void PullLever()
    {
        // Ensure the lever has not been previously activated
        if (!hasBeenActivated)
        {
            leverInteractableParticles.Stop();
            leverAnimator.SetBool("Activated", true);
            hasBeenActivated = true;
            CoroutineUtilities.DelayedAction(this, 1, doorInteraction.OpenDoor);
        }
    }

    private void MakeLeverInteractable()
    {
        if (!hasBeenActivated)
        {
            leverInteractableParticles.Play();
            interactable.enabled = true;
        }
    }
}
