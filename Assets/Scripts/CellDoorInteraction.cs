using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CellDoorInteraction : MonoBehaviour
{
    public Animator cellDoorAnimator; // Assign in the inspector
    public BoxCollider boxCollider;
    public GameObject blockerToDestroy1;
    public GameObject blockerToDestroy2;
    private AudioSource audioSource;
    private RiddleManager riddleManager;

    void Start()
    {
        // Initialize the AudioSource component
        audioSource = GetComponentInChildren<AudioSource>();
        riddleManager = RiddleManager.Instance;
    }

    public void OpenCellDoor()
    {
        UnityEngine.Debug.Log("OpenCellDoor method called"); // Make sure the quotes and parentheses are correctly placed
        cellDoorAnimator.SetBool("Activated", true); // Assuming 'Activated' is your parameter to open the door
        PlayCreakingSound();
        Destroy(boxCollider);
        Destroy(blockerToDestroy1);
        Destroy(blockerToDestroy2);
        riddleManager.SolveRiddle(0);
    }

    private void PlayCreakingSound()
    {
        audioSource.Play();
    }
}
