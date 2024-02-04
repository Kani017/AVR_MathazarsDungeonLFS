using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LecternInteraction : MonoBehaviour
{

    private bool helpScrollSpawned = false;
    public GameObject helpScroll;
    public Button spawnHelpScrollButton;
    public Button despawnHelpScrollButton;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    // Start is called before the first frame update

    private void Start()
    {
        // Store the original position and rotation
        originalPosition = helpScroll.transform.position;
        originalRotation = helpScroll.transform.rotation;
    }
    public void SpawnScroll()
    {
        helpScroll.SetActive(true);
        helpScrollSpawned = true;
        spawnHelpScrollButton.gameObject.SetActive(false);
        despawnHelpScrollButton.gameObject.SetActive(true);
        helpScroll.transform.SetPositionAndRotation(originalPosition, originalRotation);
    }

    public void DespawnScroll()
    {
        helpScroll.SetActive(false);
        helpScrollSpawned = false;
        spawnHelpScrollButton.gameObject.SetActive(true);
        despawnHelpScrollButton.gameObject.SetActive(false);
    }
}
