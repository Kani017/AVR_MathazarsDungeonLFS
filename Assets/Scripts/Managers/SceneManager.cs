using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance { get; private set; }

    //public Animator transitionAnim;
    public float transitionTime = 1f;

    private int currentRoomIndex = 0;

    // Singleton declaration so that one instance can be used throughout all scenes
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextScene()
    {
        // Increment and load next scene
        if (currentRoomIndex < 4) // 5 rooms (0 to 4)
        {
            currentRoomIndex++;
            StartCoroutine(LoadScene("Room_" + currentRoomIndex));
        }
    }

    public void ResetManager()
    {
        // Reset manager for when a player goes back to the start menu from the pause menu
        currentRoomIndex = 0;
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
