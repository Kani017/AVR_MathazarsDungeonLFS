using System.Collections;
using UnityEngine;

public class DebugSM : MonoBehaviour
{
    public float delayBetweenScenes = 15f; // Time in seconds between scene transitions

    private void Start()
    {
        StartCoroutine(SceneTestCoroutine());
    }

    IEnumerator SceneTestCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayBetweenScenes);
            SceneManager.Instance.LoadNextScene();
        }
    }
}
