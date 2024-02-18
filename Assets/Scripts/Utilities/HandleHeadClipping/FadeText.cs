using System.Collections;
using TMPro;
using UnityEngine;

// Utility class to fade the text that warns the player about peeking into walls with their heads in and out
public class FadeText : MonoBehaviour
{
    [SerializeField]
    private float fadeDuration = 1.0f;
    private TextMeshProUGUI _textMeshPro;
    private bool _isFadingOut = false;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Initiates the fade in or out process
    public void Fade(bool fadeOut)
    {
        if (fadeOut && _isFadingOut)
            return;
        if (!fadeOut && !_isFadingOut)
            return;

        _isFadingOut = fadeOut;
        StopAllCoroutines();
        StartCoroutine(FadeWarningText(fadeOut));
    }

    // Coroutine to smoothly transition the text's alpha value
    private IEnumerator FadeWarningText(bool fadeOut)
    {
        float startAlpha = _textMeshPro.color.a;
        float endAlpha = fadeOut ? 1.0f : 0.0f;
        float elapsedTime = 0;

        // Gradually updates the text's alpha over the duration
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            Color newColor = new(_textMeshPro.color.r, _textMeshPro.color.g, _textMeshPro.color.b, newAlpha);
            _textMeshPro.color = newColor;
            yield return null;
        }
        // Ensures the alpha reaches the target value at the end of the fade
        _textMeshPro.color = new Color(_textMeshPro.color.r, _textMeshPro.color.g, _textMeshPro.color.b, endAlpha);
    }
}
