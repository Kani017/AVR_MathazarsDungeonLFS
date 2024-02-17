using System;
using System.Collections;
using UnityEngine;

// Utility class to call a coroutine with a delay 
public static class CoroutineUtilities
{
    public static Coroutine DelayedAction(MonoBehaviour owner, float delay, Action action)
    {
        return owner.StartCoroutine(PerformDelayedAction(delay, action));
    }

    private static IEnumerator PerformDelayedAction(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}
