using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; }

    //public Animator transitionAnim;
    public float transitionTime = 1f;

    private int currentRoomIndex = 1;
    private string[] rooms = { "Room_0", "Room_1", "Room_2", "Room_3", "Room_4" };

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
        // Prevent loading a room out of sequence
        if (currentRoomIndex < rooms.Length - 1)
        {
            currentRoomIndex++;
            StartCoroutine(LoadScene(rooms[currentRoomIndex]));
        }
        else
        {
            Debug.Log("You are at the last room.");
            // You might want to handle end of game scenario here
        }
    }

    IEnumerator LoadScene(string sceneName)
    {
        // Play animation
        //transitionAnim.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
