using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HeadCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private HeadCollisionDetector _detector;
    [SerializeField]
    private CharacterController _characterController;
    [SerializeField]
    public float pushBackStrength = 1.0f;
    [SerializeField]
    private FadeEffect _blackScreenFade;
    [SerializeField]
    private XRRayInteractor _interactor1;
    [SerializeField]
    private XRRayInteractor _interactor2;
    [SerializeField]
    private XRInteractorLineVisual _lineVisual1;
    [SerializeField]
    private XRInteractorLineVisual _lineVisual2;



    private Vector3 CalculatePushBackDirection(List<RaycastHit> colliderHits)
    {
        Vector3 combinedNormal = Vector3.zero;
        foreach (RaycastHit hitPoint in colliderHits)
        {
            combinedNormal +=
                new Vector3(hitPoint.normal.x, 0, hitPoint.normal.z); ;
        }
        return combinedNormal;
    }

    private void Update()
    {
        if (_detector.InsideCollider)
        {
            _blackScreenFade.Fade(true);
            _interactor1.enabled = false;
            _interactor2.enabled = false;
            _lineVisual1.enabled = false;
            _lineVisual2.enabled = false;
            return;
        }
        if (_detector.DetectedColliderHits.Count <= 0)
        {
            _blackScreenFade.Fade(false);
            _interactor1.enabled = true;
            _interactor2.enabled = true;
            _lineVisual1.enabled = true;
            _lineVisual2.enabled = true;
            return;
        }
        Vector3 pushBackDirection
            = CalculatePushBackDirection(_detector.DetectedColliderHits);

        Debug.DrawRay(transform.position, pushBackDirection.normalized, Color.magenta);

        _characterController
            .Move(pushBackDirection.normalized * pushBackStrength * Time.deltaTime);
    }
}