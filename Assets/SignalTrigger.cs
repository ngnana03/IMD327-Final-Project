using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalTrigger : MonoBehaviour
{
    public ParticleSystem signalParticle; // The current signal particle system
    public ParticleSystem nextSignalParticle; // The next particle system in the chain

    [Range(0, 10)] public float angry = 5f; // Slider for "Angry"
    [Range(0, 10)] public float fear = 5f; // Slider for "Fear"
    [Range(0, 10)] public float anxiety = 5f; // Slider for "Anxiety"

    private ParticleSystem.MainModule mainModule;

    void Start()
    {
        if (signalParticle != null)
        {
            mainModule = signalParticle.main;
        }
    }

    // Trigger the signal particle when the neuron is clicked
    void OnMouseDown()
    {
        if (signalParticle != null)
        {
            signalParticle.Play(); // Play the current signal particle
            StartCoroutine(TriggerNextSignal()); // Start the coroutine to trigger the next
        }
    }

    // Coroutine to trigger the next signal particle after a delay
    IEnumerator TriggerNextSignal()
    {
        yield return new WaitForSeconds(1); // Adjust delay as needed
        if (nextSignalParticle != null)
        {
            nextSignalParticle.Play(); // Play the next signal particle
        }
    }

    void Update()
    {
        if (signalParticle != null)
        {
            // Adjust particle speed based on slider values
            float speedMultiplier = angry - (fear + anxiety) / 2; // Customize this formula
            speedMultiplier = Mathf.Clamp(speedMultiplier, 1f, 10f); // Clamp to avoid negative speed

            mainModule.startSpeed = speedMultiplier; // Apply the calculated speed
        }
    }
}
