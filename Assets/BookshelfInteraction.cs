using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookshelfInteraction : MonoBehaviour
{
    public TextMeshPro[] questions; // Assign in Inspector
    public TextMeshPro finalText;
    public List<GameObject> books = new();
    private readonly List<XRSocketInteractor> socketInteractors = new List<XRSocketInteractor>();

    public Material defaultMaterial; // Assign in Inspector
    public Material wrongMaterial; // Assign in Inspector

    private RiddleManager riddleManager;
    private int currentQuestionIndex = 0;
    private readonly int[] correctBookIndex = { 0, 1, 2, 3, 4, 5 }; // Adjust as needed

    private void Start()
    {
        Debug.Log("hello sockets");
        socketInteractors.AddRange(GetComponentsInChildren<XRSocketInteractor>());
        DisplayQuestion(currentQuestionIndex);
        riddleManager = FindObjectOfType<RiddleManager>();

        foreach (var socket in socketInteractors)
        {
            socket.selectEntered.AddListener(CheckBook);
        }
    }

    private void OnDestroy()
    {
        foreach (var socket in socketInteractors)
        {
            socket.selectEntered.RemoveListener(CheckBook);
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

    private void CheckBook(SelectEnterEventArgs args)
    {
        GameObject book = args.interactableObject.transform.gameObject;
        bool isCorrect = IsCorrectBook(book, currentQuestionIndex);

        if (isCorrect)
        {
            Debug.Log("Correct book");
            StartCoroutine(ApplyConstraintsAndDisableInteraction(book));
            ProceedWithNextQuestion();
        }
        else
        {
            ShowWrongAnswer(book);
        }
    }

    IEnumerator ApplyConstraintsAndDisableInteraction(GameObject book)
    {
        yield return new WaitForSeconds(0.5f);

        Rigidbody rb = book.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = book.AddComponent<Rigidbody>();
        }
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.useGravity = false;

        var grabInteractable = book.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.enabled = false;
        }
    }

    void ProceedWithNextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            DisplayQuestion(currentQuestionIndex);
        }
        else
        {
            CompleteRiddle();
        }
    }

    void ShowWrongAnswer(GameObject book)
    {
        // Change the book's material to indicate a wrong answer
        var renderer = book.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = wrongMaterial;
        }

        // Optionally, revert to the default material after a delay
        StartCoroutine(RevertMaterial(book));
    }

    IEnumerator RevertMaterial(GameObject book)
    {
        yield return new WaitForSeconds(2); // Wait for 2 seconds before reverting

        var renderer = book.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = defaultMaterial;
        }
    }

    bool IsCorrectBook(GameObject book, int questionIndex)
    {
        return books.IndexOf(book) == correctBookIndex[questionIndex];
    }

    void CompleteRiddle()
    {
        Debug.Log("Riddle completed");
        foreach (var question in questions)
        {
            question.gameObject.SetActive(false);
        }
        finalText.gameObject.SetActive(true);
    }
}
