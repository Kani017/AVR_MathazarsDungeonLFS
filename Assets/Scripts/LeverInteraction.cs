using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    public Animator leverAnimator; // Animator for the lever, assign in the inspector
    public DoorInteraction doorInteraction; // DoorInteraction script, assign in the inspector
    public int riddleIndex; // Index for the specific riddle this lever is associated with, assign in the inspector

    private RiddleManager riddleManager; // Automatically assigned using Singleton pattern

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
            // Toggle the 'Activated' state of the lever
            bool isActive = leverAnimator.GetBool("Activated");
            leverAnimator.SetBool("Activated", !isActive);

            // If the lever is activated, open the door
            if (!isActive)
            {
                doorInteraction.OpenDoor();
            }
        }
        else
        {
            // Provide feedback that the riddle isn't solved yet
            Debug.Log("The riddle is not solved yet.");
        }
    }
}
