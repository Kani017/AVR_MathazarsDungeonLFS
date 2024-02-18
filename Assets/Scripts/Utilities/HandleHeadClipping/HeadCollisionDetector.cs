using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionDetector : MonoBehaviour
{
    [SerializeField, Range(0, 0.5f)]
    private float _detectionDelay = 0.05f; // Delay between detection checks to optimize performance.
    [SerializeField]
    private float _detectionDistance = 0.2f; // The distance within which to detect collisions.
    [SerializeField]
    private LayerMask _detectionLayers; // The layers against which detection is performed.
    public List<RaycastHit> DetectedColliderHits { get; private set; } // Stores hits detected by raycasts.

    private float _currentTime = 0; // Tracks time elapsed since last detection check.

    [field: SerializeField]
    public bool InsideCollider { get; private set; } // Flag to indicate if inside a collider.

    // Performs detection using raycasts in specific directions.
    private List<RaycastHit> PreformDetection(Vector3 position, float distance, LayerMask mask)
    {
        List<RaycastHit> detectedHits = new List<RaycastHit>();
        List<Vector3> directions = new List<Vector3> { transform.forward, transform.right, -transform.right }; // Directions to cast rays.

        RaycastHit hit;
        foreach (var dir in directions)
        {
            if (Physics.Raycast(position, dir, out hit, distance, mask))
            {
                detectedHits.Add(hit);
            }
        }
        return detectedHits;
    }

    private void Start()
    {
        // Initial detection to populate DetectedColliderHits.
        DetectedColliderHits = PreformDetection(transform.position, _detectionDistance, _detectionLayers);
    }

    void Update()
    {
        _currentTime += Time.deltaTime;
        // Perform detection at intervals specified by _detectionDelay.
        if (_currentTime > _detectionDelay)
        {
            _currentTime = 0; // Reset timer.
            DetectedColliderHits = PreformDetection(transform.position, _detectionDistance, _detectionLayers);
            InsideCollider = DetectedColliderHits.Count <= 0
                ? CheckIfInsideCollider(transform.position, _detectionDistance, _detectionLayers)
                : false; // Update InsideCollider based on detection results.
        }
    }

    // Checks if the position is inside a collider within a given distance.
    public bool CheckIfInsideCollider(Vector3 position, float distance, LayerMask mask)
    {
        return Physics.CheckSphere(position, distance, mask, QueryTriggerInteraction.Ignore);
    }

    // Visualizes detection area and rays in the Scene view for debugging.
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        // Change gizmo color based on whether a collision was detected.
        Color c = DetectedColliderHits.Count > 0 ? new Color(1, 0, 0, 0.5f) : new Color(0, 1, 0, 0.5f);
        Gizmos.color = c;
        Gizmos.DrawWireSphere(transform.position, _detectionDistance);

        // Draw rays for visual debugging.
        List<Vector3> directions = new List<Vector3> { transform.forward, transform.right, -transform.right };
        Gizmos.color = Color.magenta;
        foreach (var dir in directions)
        {
            Gizmos.DrawRay(transform.position, dir * _detectionDistance);
        }
    }
}
