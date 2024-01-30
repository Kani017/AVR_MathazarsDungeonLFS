using System.Collections;
using System.Collections.Generic;
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

    public void BackToMenu()
    {
        Time.timeScale = 1;

        HideExitGameWarning();
        HideStartMenuWarning();

        MySceneManager.Instance.ResetManager();
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

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
