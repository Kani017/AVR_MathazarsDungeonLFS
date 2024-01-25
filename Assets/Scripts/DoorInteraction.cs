using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public Animator doorAnimator; // Assign in the inspector

    public void OpenDoor()
    {
        UnityEngine.Debug.Log("OpenDoor method called"); // Make sure the quotes and parentheses are correctly placed
        doorAnimator.SetBool("Activated", true); // Assuming 'Activated' is your parameter to open the door
    }
}
