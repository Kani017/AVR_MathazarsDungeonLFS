using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public Animator doorAnimator; // Assign in the inspector
    private MeshCollider meshCollider;
    private AudioSource woodenDoorAudioSource;

    private void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        woodenDoorAudioSource = GetComponentInChildren<AudioSource>();
    }

    public void OpenDoor()
    {
        woodenDoorAudioSource.Play();
        UnityEngine.Debug.Log("OpenDoor method called"); // Make sure the quotes and parentheses are correctly placed
        doorAnimator.SetBool("Activated", true); // Assuming 'Activated' is your parameter to open the door
        Destroy(meshCollider); 
    }
}
