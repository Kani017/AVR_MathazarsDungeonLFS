using System;
using UnityEngine;

public class SocketHighlightingEffect : MonoBehaviour
{
    // Class that highlights sockets by making a Plus Sign appear on each one when the corresponding interactable is held

    [SerializeField]
    private GameObject[] sockets; // Manually assign sockets in the Inspector.

    private GameObject[] plusSigns;

    private void Awake()
    {
        plusSigns = new GameObject[sockets.Length];
        for (int i = 0; i < sockets.Length; i++)
        {
            if (sockets[i].transform.childCount > 0)
            {
                // Assumes the first child of each socket is the plus sign.
                plusSigns[i] = sockets[i].transform.GetChild(0).gameObject;
            }
        }
    }

    public void StartHighlighting()
    {
        Debug.Log("Starting to highlight sockets.");
        foreach (var plusSign in plusSigns)
        {
            if (plusSign != null) // Ensure the plus sign was found correctly.
            {
                plusSign.SetActive(true);
            }
        }
    }

    public void StopHighlighting()
    {
        Debug.Log("Stopping highlighting sockets.");
        foreach (var plusSign in plusSigns)
        {
            if (plusSign != null) // Ensure the plus sign was found correctly.
            {
                plusSign.SetActive(false);
            }
        }
    }

    public void DisablePlusSign(GameObject socket)
    {
        int index = Array.IndexOf(sockets, socket);
        if (index != -1 && plusSigns[index] != null)
        {
            Destroy(plusSigns[index]);
        }
    }

}
