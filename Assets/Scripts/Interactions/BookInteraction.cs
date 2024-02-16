using UnityEngine;

// Manages interactions with books, including pickup, drop, respawn behavior and visual feedback such as a highlighting effect for the corresponding socket interactors .
public class BookInteraction : MonoBehaviour
{
    public ParticleSystem bookIdleParticles;
    private BookAudioFeedback bookAudioFeedback;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    public float floorThreshold = -10f;
    public bool isDropped = false;
    public SocketHighlightingEffect socketHighlightingEffect;

    private void Start()
    {
        bookIdleParticles.Play();
        bookAudioFeedback = GetComponentInChildren<BookAudioFeedback>();
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void Update()
    {
        if (transform.position.y < floorThreshold) RespawnBook();
    }

    public void OnBookPickedUp()
    {
        isDropped = false;
        bookIdleParticles.Stop();
        socketHighlightingEffect.StartHighlighting();
        bookAudioFeedback.PlayPickupSound();
    }

    public void OnBookDropped()
    {
        isDropped = true;
        socketHighlightingEffect.StopHighlighting();
        bookIdleParticles.Play();
    }

    private void RespawnBook()
    {
        transform.SetPositionAndRotation(originalPosition, originalRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDropped) bookAudioFeedback.PlayDropSound();
    }
}
