using System.Collections;
using UnityEngine;

public class ManageBackgroundMusic : MonoBehaviour
{
    public static ManageBackgroundMusic Instance { get; private set; }
    private AudioSource audioSource;
    public AudioClip musicClip; // Assign this in the inspector

    public float fadeTime = 2.0f; // Duration of the fade
    private readonly bool isFading = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource.clip = musicClip;
        StartCoroutine(PlayMusicWithFadeIn(fadeTime));
    }

    IEnumerator PlayMusicWithFadeIn(float fadeTime)
    {
        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 0.5)
        {
            audioSource.volume += Time.deltaTime / fadeTime;
            yield return null;
        }

        // After the music has fully faded in, wait until it's almost finished to start the fade out
        yield return new WaitForSeconds(audioSource.clip.length - fadeTime);

        StartCoroutine(FadeOutMusic(fadeTime));
    }

    IEnumerator FadeOutMusic(float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;

        // After fading out, immediately start the next loop with a fade-in
        StartCoroutine(PlayMusicWithFadeIn(fadeTime));
    }

    // Optionally, add methods to control the music (stop, change track, etc.)
    public void StopMusic()
    {
        if (isFading)
        {
            StopAllCoroutines(); // Stops the fading if it's happening
        }
        audioSource.Stop();
    }
}
