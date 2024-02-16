using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

public class ScaleInteraction : MonoBehaviour
{
    public List<GameObject> weightsOnScale = new();
    public float totalWeight = 0f;
    private readonly List<XRSocketInteractor> socketInteractors = new();

    private void Awake()
    {
        Debug.Log("hello sockets");
        // Find all XRSocketInteractor components in children of this GameObject
        socketInteractors.AddRange(GetComponentsInChildren<XRSocketInteractor>());

        // Subscribe to their events
        foreach (var socket in socketInteractors)
        {
            socket.selectEntered.AddListener(AddWeight);
            socket.selectExited.AddListener(RemoveWeight);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from their events to clean up
        foreach (var socket in socketInteractors)
        {
            socket.selectEntered.RemoveListener(AddWeight);
            socket.selectExited.RemoveListener(RemoveWeight);
        }
    }

    public void UpdateTotalWeight()
    {
        totalWeight = 0f;
        foreach (GameObject weight in weightsOnScale)
        {
            WeightInteraction weightComponent = weight.GetComponent<WeightInteraction>();
            if (weightComponent != null)
            {
                totalWeight += weightComponent.weightValue;
            }
        }
    }

    public void AddWeight(SelectEnterEventArgs args)
    {
        GameObject weight = args.interactableObject.transform.gameObject;
        if (!weightsOnScale.Contains(weight))
        {
            weightsOnScale.Add(weight);
            // Play snapping sound
            WeightAudioFeedback audioFeedback = weight.GetComponentInChildren<WeightAudioFeedback>();
            if (audioFeedback != null)
            {
                audioFeedback.PlaySnappingSound();
            }
            UpdateTotalWeight();
            Debug.Log($"Weight of {weight.name} added. Total weight now: {totalWeight}");
        }
    }


    public void RemoveWeight(SelectExitEventArgs args)
    {
        GameObject weight = args.interactableObject.transform.gameObject;
        if (weightsOnScale.Contains(weight))
        {
            weightsOnScale.Remove(weight);
            UpdateTotalWeight();
            Debug.Log($"Weight of {weight.name} removed. Total weight now: {totalWeight}");
        }
    }

}
