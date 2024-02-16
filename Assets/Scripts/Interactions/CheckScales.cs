using UnityEngine;

// This script periodically checks whether all weights were used and if the totalWeight of both scales is equal. If it is, the riddle will be solved.
public class CheckScales : MonoBehaviour
{
    public ScaleInteraction scale1;
    public ScaleInteraction scale2;
    public int totalWeightsCount; // Total amount of weights that should be used
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
        // Check if the total number of weights on both scales equals the total weights count and if the scales have an equal totalWeight on them
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
                scalesAudioFeedback.Play(); // Plays a sound for solving the riddle
            }
            riddleManager.SolveRiddle(1);
            riddleSolved = true; // Set the flag to true to prevent re-execution
        }
    }
}
