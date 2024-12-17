using UnityEngine;

public class NeuronSpawner : MonoBehaviour
{
    public GameObject neuronPrefab; // Prefab for the neuron (sphere)
    public int numberOfNeurons = 10; // Number of neurons to generate
    public float spawnRadius = 10f; // Radius within which to spawn neurons
    public Material lineMaterial; // Material for the LineRenderer

    private GameObject[] neurons;

    void Start()
    {
        neurons = new GameObject[numberOfNeurons];

        // Spawn neurons at random positions within the radius
        for (int i = 0; i < numberOfNeurons; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-spawnRadius, spawnRadius),
                Random.Range(-spawnRadius, spawnRadius),
                Random.Range(-spawnRadius, spawnRadius)
            );

            // Instantiate the neuron and add it to the array
            neurons[i] = Instantiate(neuronPrefab, position, Quaternion.identity);

            // Add a LineRenderer component to the neuron
            LineRenderer lineRenderer = neurons[i].AddComponent<LineRenderer>();
            lineRenderer.material = lineMaterial;
            lineRenderer.startWidth = 0.05f;
            lineRenderer.endWidth = 0.05f;

            // Connect the neuron to a random other neuron
            if (i > 0) // Ensure at least one other neuron exists
            {
                int randomIndex = Random.Range(0, i); // Random neuron from the existing ones
                GameObject targetNeuron = neurons[randomIndex];

                // Set LineRenderer positions
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, neurons[i].transform.position);
                lineRenderer.SetPosition(1, targetNeuron.transform.position);
            }
        }
    }
}