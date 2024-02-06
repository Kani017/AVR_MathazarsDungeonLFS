using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightInteraction : MonoBehaviour
{
    public float weightValue;
    private WeightAudioFeedback weightAudioFeedback;
    private Rigidbody _rigidbody;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    public float floorThreshold = -10f; // Threshold for y-coordinate
    public bool isDropped = false;

    public SocketHighlightingEffect scale1SocketHighlighting;
    public SocketHighlightingEffect scale2SocketHighlighting;

    private void Start()
    {
        weightAudioFeedback = GetComponentInChildren<WeightAudioFeedback>();
        _rigidbody = GetComponent<Rigidbody>();
        // Store the original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void Update()
    {
        if (transform.position.y < floorThreshold)
        {
            RespawnWeight();
        }
    }

    private void RespawnWeight()
    {
        // Reset the key's position and rotation to its original state
        transform.SetPositionAndRotation(originalPosition, originalRotation);

        // Reset physics state
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.isKinematic = false;
    }

    public void OnWeightPickedUp() {
        // Set isDropped to false to avoid playing the sound again
        isDropped = false;
        weightAudioFeedback.PlayPickupSound();

        // Highlight sockets
        scale1SocketHighlighting.StartHighlighting();
        scale2SocketHighlighting.StartHighlighting();
    }

    public void OnWeightDropped()
    {
        isDropped = true;

        // Stop highlighting sockets
        scale1SocketHighlighting.StopHighlighting();
        scale2SocketHighlighting.StopHighlighting();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the key has been dropped and it's the first collision after being dropped
        if (isDropped)
        {
            // Play the drop sound
            weightAudioFeedback.PlayDropSound();
        }
    }
}