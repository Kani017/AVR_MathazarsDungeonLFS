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
    private bool scrollSpawned = false;


    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private LecternAudioFeedback lecternAudioFeedback;

    private void Start()
    {
        lecternAudioFeedback = GetComponentInChildren<LecternAudioFeedback>();
        // Store the original position and rotation
        originalPosition = helpScroll.transform.position;
        originalRotation = helpScroll.transform.rotation;

        // Initially, hide all pages except the first one
        UpdateScrollText();

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

        scrollSpawned = true; // Scroll has been spawned
        lecternAudioFeedback.PlayPageOneSound();
    }


    public void DespawnScroll()
    {
        lecternAudioFeedback.PlayStartEndHelpSound();
        helpScroll.SetActive(false);
        spawnHelpScrollButton.gameObject.SetActive(true);
        despawnHelpScrollButton.gameObject.SetActive(false);
        nextPageButton.gameObject.SetActive(false);
        previousPageButton.gameObject.SetActive(false);

        scrollSpawned = false; // Scroll has been despawned
    }


    public void NextPage()
    {
        if (currentPageIndex < pageTextComponents.Count - 1)
        {
            currentPageIndex++;
            
            UpdateScrollText();
        }
        CheckButtons();
    }

    public void PreviousPage()
    {
        if (currentPageIndex > 0)
        {
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
            PlayCurrentPageSound(currentPageIndex); // Play the sound for the current page
        }
    }

    private void PlayCurrentPageSound(int pageIndex)
    {
        if (!scrollSpawned) // Check if the scroll is not spawned
        {
            return; // Do not play any sound
        }

        switch (pageIndex)
        {
            case 0:
                lecternAudioFeedback.PlayPageOneSound();
                break;
            case 1:
                lecternAudioFeedback.PlayPageTwoSound();
                break;
            case 2:
                lecternAudioFeedback.PlayPageThreeSound();
                break;
            // Add more cases as needed for additional pages
            default:
                // Optionally, play a default sound or do nothing
                break;
        }
    }



    // Enable or disable navigation buttons based on the current page index
    private void CheckButtons()
    {
        nextPageButton.gameObject.SetActive(currentPageIndex < pageTextComponents.Count - 1);
        previousPageButton.gameObject.SetActive(currentPageIndex > 0);
    }
}
