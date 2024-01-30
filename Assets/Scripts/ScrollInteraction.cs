using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ScrollInteraction : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public ParticleSystem scrollIdleParticles;
    private ScrollAudioFeedback scrollAudioFeedback;
    public KeyInteraction keyInteraction;
    private bool isDropped = false;
    private bool keyIsInteractable = false;
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        scrollAudioFeedback = GetComponentInChildren<ScrollAudioFeedback>();
        scrollIdleParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabInteractable.isSelected && !keyIsInteractable)
        {
            CoroutineUtilities.DelayedAction(this, 2, keyInteraction.MakeKeyInteractable);
            keyIsInteractable = true;
            scrollIdleParticles.Stop();
        }
    }

    public void OnScrollPickedUp()
    {
        // Set isDropped to false to avoid playing the sound again
        isDropped = false;
        scrollAudioFeedback.PlayPickupSound();
        scrollIdleParticles.Stop();
    }

    public void OnScrollDropped()
    {
        isDropped = true;
        if (!keyIsInteractable)
        {
            scrollIdleParticles.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check if the scroll has been dropped and it's the first collision after being dropped
        if (isDropped)
        {
            // Play the drop sound
            scrollAudioFeedback.PlayDropSound();
        }
    }
}
