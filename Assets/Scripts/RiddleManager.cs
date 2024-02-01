using UnityEngine;
using System;

public class RiddleManager : MonoBehaviour
{
    public static RiddleManager Instance { get; private set; }

    // Declare an event for when a riddle is solved
    public static event Action OnRiddleSolved;

    public bool[] isRiddleSolved; // Array to keep track of solved riddles

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // Initialize the array here or in Start depending on your needs
            isRiddleSolved = new bool[4]; // Adjust the size according to your riddles
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Set all riddles to unsolved from the start
        isRiddleSolved[0] = false;
        isRiddleSolved[1] = false;
        isRiddleSolved[2] = false;
        isRiddleSolved[3] = false;
    }

    // Call this method when a riddle is solved, passing the index of the riddle
    public void SolveRiddle(int riddleIndex)
    {
        // Ensure the index is within bounds and the riddle hasn't been marked as solved before
        if (riddleIndex >= 0 && riddleIndex < isRiddleSolved.Length && !isRiddleSolved[riddleIndex])
        {
            isRiddleSolved[riddleIndex] = true;
            // Invoke the OnRiddleSolved event to notify any listeners
            OnRiddleSolved?.Invoke();
        }
    }
}
