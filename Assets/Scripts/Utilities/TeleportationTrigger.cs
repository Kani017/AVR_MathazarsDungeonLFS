using UnityEngine;

public class TeleportationTrigger : MonoBehaviour
{
    // Handles the collision event between the player and the TeleportationCollider gameobject
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MySceneManager.Instance.LoadNextScene();
        }
    }
}
