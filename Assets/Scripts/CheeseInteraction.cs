using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseInteraction : MonoBehaviour
{
    private CheeseAudioFeedback cheeseAudioFeedback;
    private bool isDropped = false;

    private void Start()
    {
        cheeseAudioFeedback = GetComponentInChildren<CheeseAudioFeedback>();
    }
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (isDropped)
        {
            cheeseAudioFeedback.PlayDropSound();
        }
    }

    public void OnCheeseDropped()
    {
        isDropped = true;
    }

    public void OnCheesePickedUp()
    {
        isDropped = false;
        cheeseAudioFeedback.PlayPickupSound();
    }
}
