using UnityEngine;
using System.Collections.Generic;

public class NeuronConnection : MonoBehaviour
{
   [SerializeField] private float connectionDistance = 5.0f; // Max distance to connect neurons
    private List<GameObject> neurons; // List of neurons generated by NeuronSpawner

    void Start()
    {
        // Retrieve neurons from the scene
        neurons = new List<GameObject>(GameObject.FindGameObjectsWithTag("Neuron"));

        // Connect neurons
        CreateConnections();
    }

    void CreateConnections()
    {
        for (int i = 0; i < neurons.Count; i++)
        {
            for (int j = i + 1; j < neurons.Count; j++)
            {
                // Check if neurons are within the connection distance
                if (Vector3.Distance(neurons[i].transform.position, neurons[j].transform.position) <= connectionDistance)
                {
                    // Create a new LineRenderer
                    LineRenderer line = new GameObject("NeuronConnection").AddComponent<LineRenderer>();

                    // Set LineRenderer properties
                    line.positionCount = 2; // Line between two points
                    line.SetPosition(0, neurons[i].transform.position); // Start at neuron[i]
                    line.SetPosition(1, neurons[j].transform.position); // End at neuron[j]
                    line.startWidth = 0.05f; // Thickness
                    line.endWidth = 0.05f;
                    line.material = new Material(Shader.Find("Sprites/Default")); // Simple material
                    line.startColor = Color.blue;
                    line.endColor = Color.cyan;

                    // Parent line to the NeuronSpawner for organization
                    line.transform.parent = this.transform;
                }
            }
        }
    }
}