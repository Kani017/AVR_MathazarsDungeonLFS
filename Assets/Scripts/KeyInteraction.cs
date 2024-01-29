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
    private AudioFeedback audioFeedback;
    public ParticleSystem keyUnlockParticles;
    public ParticleSystem keyIdleParticles;
    private bool isDropped = false;
    public KeyHighlightEffect keyHighlightEffect;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        _rigidbody = GetComponent<Rigidbody>();
        audioFeedback = GetComponentInChildren<AudioFeedback>();
        keyIdleParticles.Play();
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
    }

    public void OnKeyPickedUp()
    {
        // Set isDropped to false to avoid playing the sound again
        isDropped = false;
        audioFeedback?.PlayPickupSound();
        keyHighlightEffect?.StartHighlighting();
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
            audioFeedback?.PlayDropSound();
        }
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

        audioFeedback?.PlayUnlockSound();
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
        Destroy(gameObject);
    }
}
