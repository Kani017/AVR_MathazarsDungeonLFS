using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PodiumScrollInteraction : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public ParticleSystem scrollIdleParticles;
    private ScrollAudioFeedback scrollAudioFeedback;
    private bool isDropped = false;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    public float floorThreshold = -10f; // Threshold for y-coordinate
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        scrollAudioFeedback = GetComponentInChildren<ScrollAudioFeedback>();
        scrollIdleParticles.Play();

        // Store the original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    { 
        if (transform.position.y < floorThreshold)
        {
            RespawnScroll();
        }
    }

    private void RespawnScroll()
    {
        // Reset the scroll's position and rotation to its original state
        transform.SetPositionAndRotation(originalPosition, originalRotation);
    }

    public void OnScrollPickedUp()
    {
        // Set isDropped to false to avoid playing the sound again
        isDropped = false;
        scrollAudioFeedback.PlayPickupSound();
        scrollIdleParticles.Stop();
    }

    public void OnScrollDropped()
    {
        isDropped = true;
        scrollIdleParticles.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check if the scroll has been dropped and it's the first collision after being dropped
        if (isDropped)
        {
            // Play the drop sound
            scrollAudioFeedback.PlayDropSound();
        }
    }
}
