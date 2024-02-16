using UnityEngine;
using TMPro;
using System.Collections; // Needed for IEnumerator

public class CircleDetection : MonoBehaviour
{
    public TextMeshPro[] questions; // Assign in Inspector
    public GameObject[] cheesePrefabs; // Assign in Inspector
    public GameObject circle; // Assign the parent GameObject "MagicCircle" in Inspector
    public GameObject redCircle; // Assign the red plane child in Inspector
    public GameObject whiteCircle; // Assign the white plane child in Inspector
    public GameObject greenCircle; // Assign the green plane child in Inspector
    public TextMeshPro finalText; // Assign a TextMeshPro for the final text
    private DetectionCircleAudioFeedback detectionCircleAudioFeedback;
    private RiddleManager riddleManager;
    private int currentQuestionIndex = 0;
    private int[] correctCheeseIndex = { 0, 1, 2, 3, 4, 5 }; // Assign index of correct cheeses

    void Start()
    {
        detectionCircleAudioFeedback = GetComponentInChildren<DetectionCircleAudioFeedback>();
        SetCircleColor("white"); // Set initial state to white
        DisplayQuestion(currentQuestionIndex);
        finalText.gameObject.SetActive(false); // Hide final text initially
        riddleManager = RiddleManager.Instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cheese"))
        {
            CheckCheese(other.gameObject);
        }
    }

    void DisplayQuestion(int index)
    {
        foreach (var question in questions)
        {
            question.gameObject.SetActive(false);
        }
        questions[index].gameObject.SetActive(true);
    }

    void CheckCheese(GameObject cheese)
    {
        bool isCorrect = IsCorrectCheese(cheese, currentQuestionIndex);
        SetCircleColor(isCorrect ? "green" : "red");

        if (isCorrect)
        {
            detectionCircleAudioFeedback.PlayQuestionSolvedSound(); // Play sound when a question is solved
            Destroy(cheese, 2.0f); // Destroy the cheese after a short delay
            currentQuestionIndex++;

            if (currentQuestionIndex < questions.Length)
            {
                StartCoroutine(ResetCircleColor());
                DisplayQuestion(currentQuestionIndex);
            }
            else
            {
                // All questions answered, riddle solved
                detectionCircleAudioFeedback.PlayAllQuestionsSolvedSound(); // Play sound when all questions are solved
                riddleManager.SolveRiddle(2); // Start particle effect

                // Deactivate all questions
                foreach (var question in questions)
                {
                    question.gameObject.SetActive(false);
                }

                // Activate the final text
                finalText.gameObject.SetActive(true);
            }
        }
        else
        {
            StartCoroutine(ResetCircleColor());
            // Provide feedback to the player
            // Implement the feedback logic here
        }
    }

    IEnumerator ResetCircleColor()
    {
        // Wait for 2 seconds to show the color, then reset to white
        yield return new WaitForSeconds(2.0f);
        SetCircleColor("white");
    }

    bool IsCorrectCheese(GameObject cheese, int questionIndex)
    {
        // Implement logic to check if the cake matches the fraction required by the question
        return cheese.name == cheesePrefabs[correctCheeseIndex[questionIndex]].name;
    }

    void SetCircleColor(string color)
    {
        // Enable the correct color and disable the others
        redCircle.SetActive(color == "red");
        whiteCircle.SetActive(color == "white");
        greenCircle.SetActive(color == "green");
    }
}
