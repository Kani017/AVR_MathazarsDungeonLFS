using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  

public class MainMenuActions : MonoBehaviour
{
    public GameObject creditsText;  
    public GameObject backButton;   
    public Button startButton;      
    public Button creditsButton;    
    public Button exitButton;       

    public void StartGame()
    {
        // load first ingame scene
        SceneManager.LoadScene("Room_0"); 
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

    // Quit Game and exit play mode in Unity editor
    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  
#endif
    }
}
