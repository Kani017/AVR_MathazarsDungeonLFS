using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookInteraction : MonoBehaviour
{
    public ParticleSystem bookIdleParticles;
    private BookAudioFeedback bookAudioFeedback;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    public float floorThreshold = -10f; // Threshold for y-coordinate
    public bool isDropped = false;
    public SocketHighlightingEffect socketHighlightingEffect;

    private void Start()
    {
        bookIdleParticles.Play();
        bookAudioFeedback = GetComponentInChildren<BookAudioFeedback>();

        // Store the original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void Update()
    {
        if (transform.position.y < floorThreshold)
        {
            RespawnBook();
        }
    }

    public void OnBookPickedUp()
    {
        isDropped = false;
        bookIdleParticles.Stop();
        socketHighlightingEffect.StartHighlighting();
        bookAudioFeedback.PlayPickupSound();
    }

    public void OnBookDropped() {
        isDropped = true;
        socketHighlightingEffect.StopHighlighting();
        bookIdleParticles.Play();
    }

    private void RespawnBook()
    {
        // Reset the key's position and rotation to its original state
        transform.SetPositionAndRotation(originalPosition, originalRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the key has been dropped and it's the first collision after being dropped
        if (isDropped)
        {
            // Play the drop sound
            bookAudioFeedback.PlayDropSound();

        }
    }
}
