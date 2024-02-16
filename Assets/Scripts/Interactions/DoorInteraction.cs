using UnityEngine;

// Manages door opening interactions, including animation and sound.
public class DoorInteraction : MonoBehaviour
{
    public Animator doorAnimator;
    private MeshCollider meshCollider;
    private AudioSource woodenDoorAudioSource;

    private void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        woodenDoorAudioSource = GetComponentInChildren<AudioSource>();
    }

    // Triggers the door to open, playing an audio clip and starting an animation.
    public void OpenDoor()
    {
        woodenDoorAudioSource.Play();
        doorAnimator.SetBool("Activated", true);
        Destroy(meshCollider);
    }
}
