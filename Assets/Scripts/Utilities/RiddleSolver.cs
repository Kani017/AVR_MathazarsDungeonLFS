using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleSolver : MonoBehaviour
{
    private RiddleManager riddleManager;
    public int riddleIndex;

    private void Start()
    {
        riddleManager = RiddleManager.Instance;
        riddleManager.SolveRiddle(riddleIndex);
    }


}
