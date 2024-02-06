using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScales : MonoBehaviour
{
    public ScaleInteraction scale1;
    public ScaleInteraction scale2;
    // Assuming you have a way to know how many weights should be used in total
    public int totalWeightsCount;
    private RiddleManager riddleManager;

    private void Start()
    {
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
        // Example: Check the scales whenever you need, like in Update or in response to an event
        if (CompareScalesWeights())
        {
            Debug.Log("Scales are balanced and all weights are used.");
            // Uncomment the next line if you want to call a method when the puzzle is solved
            riddleManager.SolveRiddle(1);
            // Trigger any actions needed to indicate the puzzle is solved
        }
    }
}
