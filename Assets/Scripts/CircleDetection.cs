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
    public AudioSource audioSource; // Assign the AudioSource component in Inspector
    public AudioClip soundCakesGrabbed; // Assign in Inspector
    public AudioClip soundCakesThrown; // Assign in Inspector
    public AudioClip soundCakesTouchGround; // Assign in Inspector
    public AudioClip soundQuestionSolved; // Assign in Inspector
    public AudioClip soundAllQuestionsSolved; // Assign in Inspector
    public ParticleSystem leverParticles; // Assign your particle system for the lever
    public TextMeshPro finalText; // Assign a TextMeshPro for the final text
    private int currentQuestionIndex = 0;
    private int[] correctCakeIndex = { 0, 1, 2, 3, 4, 5 }; // Assign index of correct cakes

    void Start()
    {
        SetCircleColor("white"); // Set initial state to white
        DisplayQuestion(currentQuestionIndex);
        finalText.gameObject.SetActive(false); // Hide final text initially
        leverParticles.Stop(); // Ensure the particle system is not playing initially
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cake"))
        {
            PlaySound(soundCakesGrabbed); // Play sound when a cake is grabbed/placed
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

        if (isCorrect)
        {
            PlaySound(soundQuestionSolved); // Play sound when a question is solved
            Destroy(cake, 2.0f); // Destroy the cake after a short delay
            currentQuestionIndex++;

            if (currentQuestionIndex < questions.Length)
            {
                StartCoroutine(ResetCircleColor());
                DisplayQuestion(currentQuestionIndex);
            }
            else
            {
                // All questions answered, riddle solved
                PlaySound(soundAllQuestionsSolved); // Play sound when all questions are solved
                leverParticles.Play(); // Start particle effect

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

    bool IsCorrectCake(GameObject cake, int questionIndex)
    {
        // Implement logic to check if the cake matches the fraction required by the question
        return cake.name == cakePrefabs[correctCakeIndex[questionIndex]].name;
    }

    void SetCircleColor(string color)
    {
        // Enable the correct color and disable the others
        redCircle.SetActive(color == "red");
        whiteCircle.SetActive(color == "white");
        greenCircle.SetActive(color == "green");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cake"))
        {
            PlaySound(soundCakesTouchGround); // Play sound when cake touches the ground
        }
    }

    // Function to play a sound
    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is missing!");
        }
    }
}
