using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Import this namespace to use UI elements

public class MainMenuActions : MonoBehaviour
{
    public GameObject creditsText;  // Assign in Inspector
    public GameObject backButton;   // Assign in Inspector
    public Button startButton;      // Assign in Inspector
    public Button creditsButton;    // Assign in Inspector
    public Button exitButton;       // Assign in Inspector

    public void StartGame()
    {
        SceneManager.LoadScene("Room_0"); // Make sure the scene name matches exactly
    }

    public void ShowCredits()
    {
        // Activate the credits text and back button, deactivate other menu buttons
        creditsText.SetActive(true);
        backButton.SetActive(true);
        startButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        // Deactivate the credits text and back button, reactivate other menu buttons
        creditsText.SetActive(false);
        backButton.SetActive(false);
        startButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // This line is for exiting Play Mode in the Unity Editor
#endif
    }
}
