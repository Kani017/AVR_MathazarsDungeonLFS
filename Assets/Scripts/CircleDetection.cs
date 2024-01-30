using UnityEngine;
using TMPro;
using System.Collections; // Needed for IEnumerator

public class CircleDetection : MonoBehaviour
{
    public TextMeshPro[] questions; // Assign in Inspector
    public GameObject[] cakePrefabs; // Assign in Inspector
    public GameObject circle; // Assign the parent GameObject "MagicCircle" in Inspector
    public GameObject redCircle; // Assign the red plane child in Inspector
    public GameObject whiteCircle; // Assign the white plane child in Inspector
    public GameObject greenCircle; // Assign the green plane child in Inspector
    private int currentQuestionIndex = 0;
    private int[] correctCakeIndex = { 0, 1, 2, 3, 4, 5 }; // Assign index of correct cakes

    void Start()
    {
        SetCircleColor("white"); // Set initial state to white
        DisplayQuestion(currentQuestionIndex);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cake"))
        {
            CheckCake(other.gameObject);
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

    void CheckCake(GameObject cake)
    {
        bool isCorrect = IsCorrectCake(cake, currentQuestionIndex);
        SetCircleColor(isCorrect ? "green" : "red");
        Destroy(cake, 2.0f); // Destroy the cake after a short delay

        if (isCorrect)
        {
            currentQuestionIndex++;
            if (currentQuestionIndex < questions.Length)
            {
                StartCoroutine(ResetCircleColor());
                DisplayQuestion(currentQuestionIndex);
            }
            else
            {
                // All questions answered, riddle solved
                // Enable lever to open the door
                // Implement the code to enable the lever here
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

    bool IsCorrectCake(GameObject cake, int questionIndex)
    {
        // Implement logic to check if the cake matches the fraction required by the question
        // You might use the cake's name, tag, or a custom script/property to determine which fraction it represents
        return cake.name == cakePrefabs[correctCakeIndex[questionIndex]].name;
    }

    void SetCircleColor(string color)
    {
        // Enable the correct color and disable the others
        redCircle.SetActive(color == "red");
        whiteCircle.SetActive(color == "white");
        greenCircle.SetActive(color == "green");
    }
}
