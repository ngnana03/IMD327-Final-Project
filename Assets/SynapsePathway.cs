using System.Collections.Generic;
using UnityEngine;

public class SynapsePathway : MonoBehaviour
{
    public string neuronNamePrefix = "pCube"; // Prefix for neuron spheres in the hierarchy
    public string pathwayName = "main_Neuron"; // Name of the pathway GameObject
    public GameObject synapseParticlePrefab; // Prefab for the synapse particle
    public float speed = 2f; // Movement speed
    public float spawnInterval = 1f; // Time between particle spawns

    private List<Transform> neuronPoints = new List<Transform>();

    private void Start()
    {
        // Find all neuron spheres dynamically
        foreach (Transform child in transform)
        {
            if (child.name.StartsWith(neuronNamePrefix))
            {
                neuronPoints.Add(child);
            }
        }

        // Sort neurons by name to ensure correct order
        neuronPoints.Sort((a, b) => string.Compare(a.name, b.name));

        // Start spawning synapse particles
        InvokeRepeating(nameof(SpawnSynapseParticle), 0f, spawnInterval);
    }

    void SpawnSynapseParticle()
    {
        if (neuronPoints.Count < 2) return; // Ensure we have at least two points

        GameObject particle = Instantiate(synapseParticlePrefab, neuronPoints[0].position, Quaternion.identity);
        StartCoroutine(MoveParticle(particle));
    }

    System.Collections.IEnumerator MoveParticle(GameObject particle)
    {
        for (int i = 0; i < neuronPoints.Count - 1; i++)
        {
            Vector3 start = neuronPoints[i].position;
            Vector3 end = neuronPoints[i + 1].position;

            float journey = 0f;
            while (journey <= 1f)
            {
                journey += Time.deltaTime * speed;
                particle.transform.position = Vector3.Lerp(start, end, journey);
                yield return null;
            }
        }

        Destroy(particle); // Destroy particle after completing the path
    }
}