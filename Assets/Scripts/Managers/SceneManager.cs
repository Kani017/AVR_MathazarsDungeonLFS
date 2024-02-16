using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance { get; private set; }

    //public Animator transitionAnim;
    public float transitionTime = 1f;

    private int currentRoomIndex = 0;

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
        currentRoomIndex = 0;
        // Reset other necessary states if any
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
