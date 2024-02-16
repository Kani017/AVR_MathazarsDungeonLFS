using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseInteraction : MonoBehaviour
{
    private CheeseAudioFeedback cheeseAudioFeedback;
    private bool isDropped = false;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    public float floorThreshold = -10f; // Threshold for y-coordinate

    private void Start()
    {
        cheeseAudioFeedback = GetComponentInChildren<CheeseAudioFeedback>();

        // Store the original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (isDropped)
        {
            cheeseAudioFeedback.PlayDropSound();
        }

        if (transform.position.y < floorThreshold)
        {
            RespawnCheese();
        }
    }

    private void RespawnCheese()
    {
        // Reset the cheese's position and rotation to its original state
        transform.SetPositionAndRotation(originalPosition, originalRotation);
    }

    public void OnCheeseDropped()
    {
        isDropped = true;
    }

    public void OnCheesePickedUp()
    {
        isDropped = false;
        cheeseAudioFeedback.PlayPickupSound();
    }
}
