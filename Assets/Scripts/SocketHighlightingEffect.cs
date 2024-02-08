using UnityEngine;

public class SocketHighlightingEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject[] sockets; // Manually assign sockets in the Unity Editor.

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
}