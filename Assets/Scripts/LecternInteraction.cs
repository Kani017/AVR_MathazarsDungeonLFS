using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add this to use TextMeshPro components

public class LecternInteraction : MonoBehaviour
{
    public GameObject helpScroll; // The scroll object
    public TextMeshPro scrollText; // TextMeshProUGUI component to display the current page text
    public Button spawnHelpScrollButton;
    public Button despawnHelpScrollButton;
    public Button nextPageButton;
    public Button previousPageButton;

    private int currentPageIndex = 0;
    private readonly List<string> pages = new(); // List to hold the text for each page

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        // Example pages, replace with your actual text
        pages.Add("Page 1 text here");
        pages.Add("Page 2 text here");
        pages.Add("Page 3 text here");

        // Store the original position and rotation
        originalPosition = helpScroll.transform.position;
        originalRotation = helpScroll.transform.rotation;
    }

    public void SpawnScroll()
    {
        currentPageIndex = 0; // Reset to the first page
        UpdateScrollText();
        helpScroll.SetActive(true);

        spawnHelpScrollButton.gameObject.SetActive(false);
        despawnHelpScrollButton.gameObject.SetActive(true);
        nextPageButton.gameObject.SetActive(pages.Count > 1); // Only show if more than one page
        previousPageButton.gameObject.SetActive(false); // Can't go back on the first page
        helpScroll.transform.SetPositionAndRotation(originalPosition, originalRotation);
    }

    public void DespawnScroll()
    {
        helpScroll.SetActive(false);
        spawnHelpScrollButton.gameObject.SetActive(true);
        despawnHelpScrollButton.gameObject.SetActive(false);
        nextPageButton.gameObject.SetActive(false);
        previousPageButton.gameObject.SetActive(false);
    }

    public void NextPage()
    {
        if (currentPageIndex < pages.Count - 1)
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
        if (currentPageIndex >= 0 && currentPageIndex < pages.Count)
        {
            scrollText.text = pages[currentPageIndex];
        }
    }

    // Enable or disable navigation buttons based on the current page index
    private void CheckButtons()
    {
        nextPageButton.gameObject.SetActive(currentPageIndex < pages.Count - 1);
        previousPageButton.gameObject.SetActive(currentPageIndex > 0);
    }
}
