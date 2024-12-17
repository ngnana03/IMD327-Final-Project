using UnityEngine;

public class SignalAnimation : MonoBehaviour
{
    public float speed = 1f; // Speed of the signal animation
    private LineRenderer lineRenderer;
    private float timer = 0f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Animate the signal along the line
        if (lineRenderer != null)
        {
            timer += Time.deltaTime * speed;

            // Use timer to move from start to end of the line
            Vector3 startPosition = lineRenderer.GetPosition(0);
            Vector3 endPosition = lineRenderer.GetPosition(1);
            Vector3 currentPos = Vector3.Lerp(startPosition, endPosition, timer);

            // Create a "moving signal" effect
            // This could be done by controlling a particle system that follows the signal

            // Move the signal object (or particle) here, based on currentPos
            // For example:
            // transform.position = currentPos;

            // Optionally reset the timer when it reaches the end
            if (timer >= 1f)
            {
                timer = 0f; // Reset timer after one full pass
            }
        }
    }
}