using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LecternInteraction : MonoBehaviour
{
    public GameObject helpScroll; // The scroll object
    public List<TextMeshPro> pageTextComponents; // Assign TextMeshPro components for each page in the inspector
    public Button spawnHelpScrollButton;
    public Button despawnHelpScrollButton;
    public Button nextPageButton;
    public Button previousPageButton;

    private int currentPageIndex = 0;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private LecternAudioFeedback lecternAudioFeedback;

    private void Start()
    {
        // Ensure there's at least one page to prevent errors
        if (pageTextComponents.Count > 0)
        {
            // Store the original position and rotation
            originalPosition = helpScroll.transform.position;
            originalRotation = helpScroll.transform.rotation;

            // Initially, hide all pages except the first one
            UpdateScrollText();
        }

        lecternAudioFeedback = GetComponentInChildren<LecternAudioFeedback>();
    }

    public void SpawnScroll()
    {   
        lecternAudioFeedback.PlayStartEndHelpSound();
        currentPageIndex = 0; // Reset to the first page
        UpdateScrollText();
        helpScroll.SetActive(true);

        spawnHelpScrollButton.gameObject.SetActive(false);
        despawnHelpScrollButton.gameObject.SetActive(true);
        nextPageButton.gameObject.SetActive(pageTextComponents.Count > 1); // Only show if more than one page
        previousPageButton.gameObject.SetActive(false); // Can't go back on the first page
        helpScroll.transform.SetPositionAndRotation(originalPosition, originalRotation);
    }

    public void DespawnScroll()
    {
        lecternAudioFeedback.PlayStartEndHelpSound();
        helpScroll.SetActive(false);
        spawnHelpScrollButton.gameObject.SetActive(true);
        despawnHelpScrollButton.gameObject.SetActive(false);
        nextPageButton.gameObject.SetActive(false);
        previousPageButton.gameObject.SetActive(false);
    }

    public void NextPage()
    {
        if (currentPageIndex < pageTextComponents.Count - 1)
        {
            lecternAudioFeedback.PlayForwardBackSound();
            currentPageIndex++;
            UpdateScrollText();
        }
        CheckButtons();
    }

    public void PreviousPage()
    {
        if (currentPageIndex > 0)
        {
            lecternAudioFeedback.PlayForwardBackSound();
            currentPageIndex--;
            UpdateScrollText();
        }
        CheckButtons();
    }

    private void UpdateScrollText()
    {
        // Hide all pages
        foreach (var textComponent in pageTextComponents)
        {
            textComponent.gameObject.SetActive(false);
        }

        // Show the current page
        if (currentPageIndex >= 0 && currentPageIndex < pageTextComponents.Count)
        {
            pageTextComponents[currentPageIndex].gameObject.SetActive(true);
        }
    }

    // Enable or disable navigation buttons based on the current page index
    private void CheckButtons()
    {
        nextPageButton.gameObject.SetActive(currentPageIndex < pageTextComponents.Count - 1);
        previousPageButton.gameObject.SetActive(currentPageIndex > 0);
    }
}
