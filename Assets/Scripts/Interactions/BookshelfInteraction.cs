using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookshelfInteraction : MonoBehaviour
{
    public TextMeshPro[] questions; // Question text displays
    public TextMeshPro finalText; // Text to display upon completing all questions
    public List<GameObject> books = new();
    private readonly List<XRSocketInteractor> socketInteractors = new();

    public ParticleSystem bookshelfInteractableParticles; // Particle effect for the bookshelf

    private RiddleManager riddleManager;
    private int currentQuestionIndex = 0;
    private readonly int[] correctBookIndex = { 0, 1, 2, 3, 4, 5 }; // Indexes of the correct books for each question

    private BookshelfAudioFeedback bookshelfAudioFeedback;
    [SerializeField]
    private SocketHighlightingEffect socketHighlightingEffect; // Effect for highlighting sockets
    public BookMaterialManager bookMaterialManager; // Manages material changes for books

    private void Start()
    {
        socketInteractors.AddRange(GetComponentsInChildren<XRSocketInteractor>());
        DisplayQuestion(currentQuestionIndex);
        riddleManager = RiddleManager.Instance;
        bookshelfAudioFeedback = GetComponentInChildren<BookshelfAudioFeedback>();

        // Add listeners for when a book is placed in a socket
        foreach (var socket in socketInteractors)
        {
            socket.selectEntered.AddListener(CheckBook);
        }
    }

    private void OnDestroy()
    {
        // Remove listeners to avoid memory leaks
        foreach (var socket in socketInteractors)
        {
            socket.selectEntered.RemoveListener(CheckBook);
        }
    }

    // Displays the current question to the player
    void DisplayQuestion(int index)
    {
        foreach (var question in questions)
        {
            question.gameObject.SetActive(false);
        }
        questions[index].gameObject.SetActive(true);
    }

    // Checks if the placed book is correct and handles the result
    private void CheckBook(SelectEnterEventArgs args)
    {
        GameObject book = args.interactableObject.transform.gameObject;
        bool isCorrect = IsCorrectBook(book, currentQuestionIndex);
        BookAudioFeedback audioFeedback = book.GetComponentInChildren<BookAudioFeedback>();
        audioFeedback.PlaySnappingSound();

        if (isCorrect)
        {
            StartCoroutine(ApplyConstraintsAndDisableInteraction(book));
            ProceedWithNextQuestion();

            if (currentQuestionIndex < questions.Length)
            {
                bookshelfAudioFeedback.PlayCorrectBookSound();
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
            ShowWrongAnswer(book);
        }
    }

    // Disables the socket after a delay to prevent further interactions
    IEnumerator DisableSocketAfterDelay(XRSocketInteractor socketInteractor)
    {
        yield return new WaitForSeconds(0.5f);
        socketInteractor.enabled = false;
    }

    // Applies constraints to the correct book and disables its interaction
    IEnumerator ApplyConstraintsAndDisableInteraction(GameObject book)
    {
        yield return new WaitForSeconds(0.5f);
        Rigidbody rb = book.GetComponent<Rigidbody>() ?? book.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.useGravity = false;
        if (book.TryGetComponent(out XRGrabInteractable grabInteractable))
        {
            grabInteractable.enabled = false;
        }
        ParticleSystem bookIdleParticles = book.GetComponentInChildren<ParticleSystem>();
        bookIdleParticles.Stop();
    }

    // Proceeds to the next question or completes the riddle if all questions are answered
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

    // Shows visual feedback for a wrong answer
    void ShowWrongAnswer(GameObject book)
    {
        bookMaterialManager.SetBookMaterialWrong(book);
    }

    // Checks if the selected book is the correct answer for the current question
    bool IsCorrectBook(GameObject book, int questionIndex)
    {
        return books.IndexOf(book) == correctBookIndex[questionIndex];
    }

    // Handles the completion of the riddle
    void CompleteRiddle()
    {
        bookshelfAudioFeedback.PlayAllQuestionsSolvedSound();
        finalText.gameObject.SetActive(true);
        bookshelfInteractableParticles.Stop();
        riddleManager.SolveRiddle(3);
    }
}
