using UnityEngine;
using UnityEngine.UI;

public class ParticleControl : MonoBehaviour
{
    public Slider angerSlider; // Reference to the anger slider
    public Slider fearSlider;  // Reference to the fear slider

    private ParticleSystem[] particleSystems;  // Array to hold all particle systems in the scene

    void Start()
    {
        // Find all particle systems in the scene
        particleSystems = FindObjectsOfType<ParticleSystem>();

        // Add listeners for slider value changes
        angerSlider.onValueChanged.AddListener(OnAngerChanged);
        fearSlider.onValueChanged.AddListener(OnFearChanged);
    }

    // Adjust the particle speed when the anger slider is changed
    void OnAngerChanged(float value)
    {
        foreach (var ps in particleSystems)
        {
            var mainModule = ps.main;
            // For Anger, make particles move super fast when anger slider is high
            mainModule.startSpeed = Mathf.Lerp(100f, 1000f, value); // Adjust the speed from 5 to 20 as anger increases
        }
    }

    // Adjust the particle speed and emission when the fear slider is changed
    void OnFearChanged(float value)
    {
        foreach (var ps in particleSystems)
        {
            var mainModule = ps.main;
            // For super slow fear, set the startSpeed to a very low value
            mainModule.startSpeed = Mathf.Lerp(0.1f, 0.001f, value); // Extremely slow speed for fear

            var emissionModule = ps.emission;
            // For super slow movement, reduce the emission rate too
            emissionModule.rateOverTime = Mathf.Lerp(10f, 1f, value); // Lower emission rate for higher fear values
        }
    }
}
