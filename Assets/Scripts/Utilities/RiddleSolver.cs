using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleSolver : MonoBehaviour
{
    private RiddleManager riddleManager;

    private void Start()
    {
        riddleManager = RiddleManager.Instance;
        riddleManager.SolveRiddle(1);
    }


}
