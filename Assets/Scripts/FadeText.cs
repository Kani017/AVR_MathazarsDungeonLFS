using System.Collections;
using TMPro;
using UnityEngine;

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

    private IEnumerator FadeWarningText(bool fadeOut)
    {
        float startAlpha = _textMeshPro.color.a;
        float endAlpha = fadeOut ? 1.0f : 0.0f;
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            Color newColor = new Color(_textMeshPro.color.r, _textMeshPro.color.g, _textMeshPro.color.b, newAlpha);
            _textMeshPro.color = newColor;
            yield return null;
        }
        _textMeshPro.color = new Color(_textMeshPro.color.r, _textMeshPro.color.g, _textMeshPro.color.b, endAlpha);
    }
}
