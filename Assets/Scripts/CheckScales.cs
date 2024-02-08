using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScales : MonoBehaviour
{
    public ScaleInteraction scale1;
    public ScaleInteraction scale2;
    public int totalWeightsCount; // Assuming you have a way to know how many weights should be used in total
    private RiddleManager riddleManager;
    private AudioSource scalesAudioFeedback;
    private bool riddleSolved = false; // Flag to check if the riddle has already been solved

    private void Start()
    {
        scalesAudioFeedback = GetComponentInChildren<AudioSource>();
        riddleManager = RiddleManager.Instance;
    }

    // Method to check if the scales are balanced and all weights are used
    public bool CompareScalesWeights()
    {
        // Check if the total number of weights on both scales equals the total weights count
        bool allWeightsUsed = (scale1.weightsOnScale.Count + scale2.weightsOnScale.Count) == totalWeightsCount;

        return allWeightsUsed && scale1.totalWeight == scale2.totalWeight;
    }

    void Update()
    {
        // Only check the scales if the riddle hasn't been solved yet
        if (!riddleSolved && CompareScalesWeights())
        {
            Debug.Log("Scales are balanced and all weights are used.");

            if (!scalesAudioFeedback.isPlaying)
            {
                scalesAudioFeedback.Play();
            }
            riddleManager.SolveRiddle(1);
            riddleSolved = true; // Set the flag to true to prevent re-execution
        }
    }
}
