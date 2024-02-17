using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuActions : MonoBehaviour
{
    public Button resumeButton;
    public Button startMenuButton;
    public Button exitGameButton;

    public GameObject exitGameWarning;
    public GameObject startMenuWarning;

    private bool isMenuActive = false;

    // Method to toggle the pause menu depending on whether it is active or not with the left trigger button
    public void OnActivate()
    {
        if (!isMenuActive)
        {
            isMenuActive = true;
            resumeButton.gameObject.SetActive(true);
            startMenuButton.gameObject.SetActive(true);
            exitGameButton.gameObject.SetActive(true);
            Time.timeScale = 0;

        }
        else
        {
            isMenuActive = false;
            exitGameWarning.SetActive(false);
            resumeButton.gameObject.SetActive(false);
            startMenuButton.gameObject.SetActive(false);
            exitGameButton.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    // Unfreeze time and resume game
    public void ResumeGame()
    {
        isMenuActive = false;

        HideExitGameWarning();
        HideStartMenuWarning();

        resumeButton.gameObject.SetActive(false);
        startMenuButton.gameObject.SetActive(false);
        exitGameButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    // back to start menu
    public void BackToMenu()
    {
        Time.timeScale = 1;

        HideExitGameWarning();
        HideStartMenuWarning();

        MySceneManager.Instance.ResetManager();
        SceneManager.LoadScene("MainMenu");
    }

    // Quit game and exit play mode in Unity editor
    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // Methods to handle the warnings about losing your progress
    public void ShowExitGameWarning()
    {
        exitGameWarning.SetActive(true);
        HideStartMenuWarning();
    }

    public void HideExitGameWarning()
    {
        exitGameWarning.SetActive(false);
    }

    public void ShowStartMenuWarning()
    {
        startMenuWarning.SetActive(true);
        HideExitGameWarning ();
    }

    public void HideStartMenuWarning()
    {
        startMenuWarning.SetActive(false);
    }
}
