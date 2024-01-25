using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyInteraction : MonoBehaviour
{
    public Transform lockTransform; // Assign the lock position transform in the inspector
    public DoorInteraction doorInteraction; // Reference to the DoorInteraction script
    private XRGrabInteractable grabInteractable; // XRGrabInteractable component
    private Rigidbody rigidbody; // Rigidbody component
    public float unlockDistance = 0.5f; // Distance within which the key can unlock the door
    private bool hasUnlocked = false; // To ensure the door opens only once
    [SerializeField]
    public GameObject blockerToDestroy;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rigidbody = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    void Update()
    {
        if (!hasUnlocked && grabInteractable.isSelected)
        {
            float distanceToLock = Vector3.Distance(transform.position, lockTransform.position);
            if (distanceToLock <= unlockDistance)
            {
                // Make the Rigidbody kinematic to remove it from physics calculations
                rigidbody.isKinematic = true;

                // Snap to lock position and rotate to unlock
                transform.position = lockTransform.position;
                transform.rotation = Quaternion.Euler(0, 0, 90); // Adjust rotation as needed

                // Disable XRGrabInteractable
                grabInteractable.enabled = false;

                // Make the key a child of the lock transform
                transform.SetParent(lockTransform, true);

                // Open the door after a delay
                hasUnlocked = true;
                CoroutineUtilities.DelayedAction(this, 1, doorInteraction.OpenDoor);
                Destroy(blockerToDestroy);

            }
        }
    }

}
