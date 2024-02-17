using UnityEngine;

public class RiddleSolver : MonoBehaviour
{

    // Utility class that solves any riddle as a placeholder for when the riddle is not far enough in developmebt to be solved by a player yet
    private RiddleManager riddleManager;
    public int riddleIndex;

    private void Start()
    {
        riddleManager = RiddleManager.Instance;
        riddleManager.SolveRiddle(riddleIndex);
    }


}
