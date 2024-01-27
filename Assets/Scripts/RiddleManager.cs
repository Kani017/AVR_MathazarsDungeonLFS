using UnityEngine;

public class RiddleManager : MonoBehaviour
{
    public static RiddleManager Instance { get; private set; }

    public bool[] isRiddleSolved; // Array to keep track of solved riddles

    void Start()
    {
        // Temporarily mark the first riddle as solved for testing
        isRiddleSolved[0] = true;
        isRiddleSolved[1] = true;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Initialize the array based on the number of riddles
            isRiddleSolved = new bool[3]; // Assuming 3 riddles
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this method when a riddle is solved, passing the index of the riddle
    public void SolveRiddle(int riddleIndex)
    {
        if (riddleIndex >= 0 && riddleIndex < isRiddleSolved.Length)
        {
            isRiddleSolved[riddleIndex] = true;
        }
    }
}
