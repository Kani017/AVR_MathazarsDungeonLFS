using UnityEngine;

public class RiddleManager : MonoBehaviour
{
    public static RiddleManager Instance { get; private set; }

    public bool[] isRiddleSolved; // Array to keep track of solved riddles

    void Start()
    {
        // Temporarily mark all riddles as solved for testing
        isRiddleSolved[0] = true;
        isRiddleSolved[1] = true;
        isRiddleSolved[2] = true;
        isRiddleSolved[3] = true;
        isRiddleSolved[4] = true;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

           
            isRiddleSolved = new bool[5];
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
