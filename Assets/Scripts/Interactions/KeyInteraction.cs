using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyInteraction : MonoBehaviour
{
    // Transform of the lock and the script controlling the cell door interaction.
    public Transform lockTransform;
    public CellDoorInteraction cellDoorInteraction;

    // Key interaction components and effects.
    private XRGrabInteractable grabInteractable;
    private Rigidbody _rigidbody;
    public float unlockDistance = 0.2f;
    private bool hasUnlocked = false; // Tracks if the key has unlocked the door.
    private KeyAudioFeedback keyAudioFeedback; // Handles audio feedback for key interactions.
    public ParticleSystem keyUnlockParticles, keyIdleParticles; // Visual effects for the key.
    public KeyHighlightEffect keyHighlightEffect; // Visual effect for highlighting the key.
    private bool isDropped = false;

    // Used for respawning the key if dropped below a certain height.
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    public float floorThreshold = -10f;

    void Start()
    {
        // Initialize components and store the key's original position for possible respawn.
        grabInteractable = GetComponent<XRGrabInteractable>();
        _rigidbody = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        grabInteractable.enabled = false; // Interaction is enabled under specific conditions.
    }

    // Check for unlock conditions or if the key needs to be respawned.
    void Update()
    {
        if (grabInteractable.isSelected && !hasUnlocked)
        {
            float distanceToLock = Vector3.Distance(transform.position, lockTransform.position);
            if (distanceToLock <= unlockDistance)
            {
                StartCoroutine(UnlockProcedure());
            }
        }
        if (transform.position.y < floorThreshold)
        {
            RespawnKey();
        }
    }

    // Resets the key's position, orientation, and physics.
    private void RespawnKey()
    {
        transform.SetPositionAndRotation(originalPosition, originalRotation);

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.isKinematic = false;
    }

    public void OnKeyPickedUp()
    {
        // Set isDropped to false to avoid playing the sound again
        isDropped = false;
        keyAudioFeedback.PlayPickupSound();
        keyHighlightEffect.StartHighlighting();
        keyIdleParticles.Stop();
    }

    // Handles the key being dropped, playing effects and adjusting state.
    public void OnKeyDropped()
    {
        isDropped = true;
        keyHighlightEffect.StopHighlighting();
        keyIdleParticles.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the key has been dropped and it's the first collision after being dropped
        if (isDropped && !hasUnlocked)
        {
            // Play the drop sound
            keyAudioFeedback.PlayDropSound();
        }
    }

    // Enables key interaction and initializes feedback mechanisms.
    public void MakeKeyInteractable()
    {
        grabInteractable.enabled = true;
        keyAudioFeedback = GetComponentInChildren<KeyAudioFeedback>();
        keyIdleParticles.gameObject.SetActive(true);

    }

    // Coroutine handling the key unlocking the door, with visual and audio feedback.
    private IEnumerator UnlockProcedure()
    {
        // Ensure this procedure runs only once
        if (hasUnlocked) yield break;
        hasUnlocked = true;

        // Snap to lock position
        transform.position = lockTransform.position;
        transform.SetParent(lockTransform, true);
        transform.rotation = Quaternion.Euler(0, -90, 90);

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(-90, 0, 0) * startRotation;
        float duration = 1.0f;
        float elapsed = 0;

        keyAudioFeedback.PlayUnlockSound();
        keyUnlockParticles.gameObject.SetActive(true);
        keyUnlockParticles.Play();
        grabInteractable.enabled = false;
        _rigidbody.isKinematic = true;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsed / duration);
            yield return null;
        }

        cellDoorInteraction.OpenCellDoor();
        gameObject.SetActive(false);
    }
}
