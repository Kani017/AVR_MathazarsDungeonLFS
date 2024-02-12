using System;
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
    private readonly List<XRSocketInteractor> socketInteractors = new();

    public ParticleSystem bookshelfInteractableParticles;

    private RiddleManager riddleManager;
    private int currentQuestionIndex = 0;
    private readonly int[] correctBookIndex = { 0, 1, 2, 3, 4, 5 }; // Adjust as needed

    private BookshelfAudioFeedback bookshelfAudioFeedback;
    [SerializeField]
    private SocketHighlightingEffect socketHighlightingEffect;
    public BookMaterialManager bookMaterialManager;

    private void Start()
    {
        Debug.Log("hello sockets");
        socketInteractors.AddRange(GetComponentsInChildren<XRSocketInteractor>());
        DisplayQuestion(currentQuestionIndex);
        riddleManager = RiddleManager.Instance;
        bookshelfAudioFeedback = GetComponentInChildren<BookshelfAudioFeedback>();

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
        BookAudioFeedback audioFeedback = book.GetComponentInChildren<BookAudioFeedback>();
        audioFeedback.PlaySnappingSound();

        if (isCorrect)
        {
            if (audioFeedback != null)
            {
                //audioFeedback.PlaySnappingSound(); // Play the snapping sound for the book
            }
            Debug.Log("Correct book");
            StartCoroutine(ApplyConstraintsAndDisableInteraction(book));

            ProceedWithNextQuestion();

            if (currentQuestionIndex < questions.Length) // This means there are more questions left, not the last book
            {
                bookshelfAudioFeedback.PlayCorrectBookSound();
                Debug.Log("Correct book");
            }

            XRSocketInteractor socketInteractor = args.interactorObject as XRSocketInteractor;
            if (socketInteractor != null)
            {
                socketHighlightingEffect.DisablePlusSign(socketInteractor.gameObject);
                StartCoroutine(DisableSocketAfterDelay(socketInteractor));
            }
        }
        else
        {
            //audioFeedback.PlaySnappingSound();
            ShowWrongAnswer(book);
        }
    }


IEnumerator DisableSocketAfterDelay(XRSocketInteractor socketInteractor)
    {
        // Wait for a brief moment to allow the book to settle in the socket
        yield return new WaitForSeconds(0.5f); // Adjust the delay as needed

        // Disable the socket to prevent further interactions
        socketInteractor.enabled = false;
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

        if (book.TryGetComponent<XRGrabInteractable>(out var grabInteractable))
        {
            grabInteractable.enabled = false;
        }
        ParticleSystem bookIdleParticles = book.GetComponentInChildren<ParticleSystem>();
        bookIdleParticles.Stop();
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
        // Use the BookMaterialChanger to set the book's material to the wrong material
        if (bookMaterialManager != null)
        {
            bookMaterialManager.SetBookMaterialWrong(book);
        }

        else
        {
            Debug.LogError("BookMaterialChanger reference not set in BookshelfInteraction.");
        }
    }


    bool IsCorrectBook(GameObject book, int questionIndex)
    {
        return books.IndexOf(book) == correctBookIndex[questionIndex];
    }

    void CompleteRiddle()
    {
        bookshelfAudioFeedback.PlayAllQuestionsSolvedSound();
        Debug.Log("Riddle completed");
        foreach (var question in questions)
        {
            question.gameObject.SetActive(false);
        }
        finalText.gameObject.SetActive(true);
        bookshelfInteractableParticles.Stop();
        //riddleManager.SolveRiddle(3);
    }
}
