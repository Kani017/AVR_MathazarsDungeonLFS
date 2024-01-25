using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    public Animator leverAnimator; // Animator for the lever, assign in the inspector
    public DoorInteraction doorInteraction; // DoorInteraction script, assign in the inspector
    public int riddleIndex; // Index for the specific riddle this lever is associated with, assign in the inspector

    private RiddleManager riddleManager; // Automatically assigned using Singleton pattern
    private bool hasBeenActivated = false; // Flag to track if the lever has been activated once

    private void Start()
    {
        riddleManager = RiddleManager.Instance;
    }

    void Update()
    {
        // Press the 'L' key to simulate pulling the lever
        if (Input.GetKeyDown(KeyCode.L))
        {
            PullLever();
        }
    }

    public void PullLever()
    {
        // Check if the specific riddle associated with this lever is solved
        if (riddleManager.isRiddleSolved[riddleIndex])
        {
            // Check if the lever has not been activated before
            if (!hasBeenActivated)
            {
                // Activate the lever and open the door
                leverAnimator.SetBool("Activated", true);
                hasBeenActivated = true;
                CoroutineUtilities.DelayedAction(this, 1, doorInteraction.OpenDoor);
            }
        }
        else
        {
            // Provide feedback that the riddle isn't solved yet
            Debug.Log("The riddle is not solved yet.");
        }
    }
}
