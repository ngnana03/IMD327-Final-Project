using UnityEngine;

public class AttachSpheresToLines : MonoBehaviour
{
    public GameObject spherePrefab; // Prefab for the spheres

    void Start()
    {
        // Find all line objects in the scene
        LineRenderer[] lines = FindObjectsOfType<LineRenderer>();

        foreach (LineRenderer line in lines)
        {
            // Get start and end positions of each line
            Vector3 startPoint = line.GetPosition(0);
            Vector3 endPoint = line.GetPosition(1);

            // Instantiate spheres at the endpoints
            Instantiate(spherePrefab, startPoint, Quaternion.identity);
            Instantiate(spherePrefab, endPoint, Quaternion.identity);
        }
    }
}