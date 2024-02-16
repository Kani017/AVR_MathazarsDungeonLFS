using UnityEngine;

public class TeleportationTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the player has a tag "Player"
        {
            MySceneManager.Instance.LoadNextScene();
        }
    }
}
