using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// Handles head collision events 
public class HeadCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private HeadCollisionDetector _detector; // Detects collisions with the player's head.
    [SerializeField]
    private CharacterController _characterController; // Controls player movement.
    [SerializeField]
    private float pushBackStrength = 0.5f; // Strength of the pushback when a collision is detected.
    [SerializeField]
    private FadeEffect _blackScreenFade; // Controls the black screen fade effect.
    [SerializeField]
    private FadeText _peekWarningMessage; // Displays a warning message when peeking through objects.
    [SerializeField]
    private XRRayInteractor _interactor1; // First hand interactor.
    [SerializeField]
    private XRRayInteractor _interactor2; // Second hand interactor.
    [SerializeField]
    private XRInteractorLineVisual _lineVisual1; // Visual for the first interactor's ray.
    [SerializeField]
    private XRInteractorLineVisual _lineVisual2; // Visual for the second interactor's ray.

    // Calculates the combined normal direction from multiple collision points.
    private Vector3 CalculatePushBackDirection(List<RaycastHit> colliderHits)
    {
        Vector3 combinedNormal = Vector3.zero;
        foreach (RaycastHit hitPoint in colliderHits)
        {
            combinedNormal += new Vector3(hitPoint.normal.x, 0, hitPoint.normal.z);
        }
        return combinedNormal;
    }

    private void Update()
    {
        // If the player's head is inside a collider, trigger effects and disable interactions.
        if (_detector.InsideCollider)
        {
            _blackScreenFade.Fade(true);
            _peekWarningMessage.Fade(true);
            _interactor1.enabled = false;
            _interactor2.enabled = false;
            _lineVisual1.enabled = false;
            _lineVisual2.enabled = false;
            return;
        }

        // If no colliders are detected, revert effects and enable interactions.
        if (_detector.DetectedColliderHits.Count <= 0)
        {
            _blackScreenFade.Fade(false);
            _peekWarningMessage.Fade(false);
            _interactor1.enabled = true;
            _interactor2.enabled = true;
            _lineVisual1.enabled = true;
            _lineVisual2.enabled = true;
            return;
        }

        // Calculate and apply a pushback force if colliders are detected.
        Vector3 pushBackDirection = CalculatePushBackDirection(_detector.DetectedColliderHits);
        Debug.DrawRay(transform.position, pushBackDirection.normalized, Color.magenta);
        _characterController.Move(pushBackDirection.normalized * pushBackStrength * Time.deltaTime);
    }
}
