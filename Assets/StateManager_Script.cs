using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    // Singleton instance
    public static StateManager Instance { get; private set; }

    private int currentRoomIndex = 0; // Start from Room_0
    private const int maxRoomIndex = 4; // Maximum room index (Room_4)

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the instance alive across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextRoom()
    {
        currentRoomIndex++;
        if (currentRoomIndex > maxRoomIndex)
        {
            Debug.Log("No more rooms to load. Game completed or restart.");
            // Optional: Add logic for what happens when all rooms are completed
        }
        else
        {
            SceneManager.LoadScene($"Room_{currentRoomIndex}");
        }
    }

    // Method to load a specific room by index
    public void LoadRoomByIndex(int roomIndex)
    {
        if (roomIndex >= 0 && roomIndex <= maxRoomIndex)
        {
            currentRoomIndex = roomIndex;
            SceneManager.LoadScene($"Room_{roomIndex}");
        }
        else
        {
            Debug.LogError($"Invalid room index: {roomIndex}. Please provide a valid index between 0 and {maxRoomIndex}.");
        }
    }
}
