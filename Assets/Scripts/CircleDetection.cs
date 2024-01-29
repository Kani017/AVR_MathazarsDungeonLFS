using UnityEngine;
using TMPro;

public class CircleDetection : MonoBehaviour
{
    public TextMeshPro[] questions; // Assign in Inspector
    public GameObject[] cakePrefabs; // Assign in Inspector
    public Material whiteMaterial, redMaterial, greenMaterial; // Assign in Inspector
    public GameObject circle; // Assign in Inspector
    public Collider circleCollider; // Assign in Inspector
    private int currentQuestionIndex = 0;
    private int[] correctCakeIndex = { 0, 1, 2, 3, 4, 5 }; // Assign index of correct cakes

    void Start()
    {
        circle.GetComponent<Renderer>().material = whiteMaterial;
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
        // Determine if the correct cake was placed based on the current question
        if (IsCorrectCake(cake, currentQuestionIndex))
        {
            circle.GetComponent<Renderer>().material = greenMaterial;
            Destroy(cake, 2.0f); // Destroy the cake after a short delay
            currentQuestionIndex++;
            if (currentQuestionIndex < questions.Length)
            {
                DisplayQuestion(currentQuestionIndex);
                circle.GetComponent<Renderer>().material = whiteMaterial;
            }
            else
            {
                // All questions answered, riddle solved
                // Enable lever to open the door
            }
        }
        else
        {
            circle.GetComponent<Renderer>().material = redMaterial;
            // Maybe reset the cake's position or give feedback to the player
        }
    }

    bool IsCorrectCake(GameObject cake, int questionIndex)
    {
        // Implement logic to check if the cake matches the fraction required by the question
        // You might use the cake's name, tag, or a custom script/property to determine which fraction it represents
        return cake.name == cakePrefabs[correctCakeIndex[questionIndex]].name;
    }
}
