using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyInteraction : MonoBehaviour
{
    public Transform lockTransform;
    public CellDoorInteraction cellDoorInteraction;
    private XRGrabInteractable grabInteractable;
    private Rigidbody _rigidbody;
    public float unlockDistance = 0.2f;
    private bool hasUnlocked = false;
    private KeyAudioFeedback keyAudioFeedback;
    public ParticleSystem keyUnlockParticles;
    public ParticleSystem keyIdleParticles;
    private bool isDropped = false;
    public KeyHighlightEffect keyHighlightEffect;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    public float floorThreshold = -10f; // Threshold for y-coordinate

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        _rigidbody = GetComponent<Rigidbody>();
        grabInteractable.enabled = false;

        // Store the original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

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

    private void RespawnKey()
    {
        // Reset the key's position and rotation to its original state
        transform.SetPositionAndRotation(originalPosition, originalRotation);

        // Reset physics state
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

    public void MakeKeyInteractable()
    {
        grabInteractable.enabled = true;
        keyAudioFeedback = GetComponentInChildren<KeyAudioFeedback>();
        keyIdleParticles.gameObject.SetActive(true);

    }

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
