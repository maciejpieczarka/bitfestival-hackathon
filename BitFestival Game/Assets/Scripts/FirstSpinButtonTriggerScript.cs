using UnityEngine;

public class FirstSpinButtonTriggerScript : MonoBehaviour
{
    public GameObject canvas; // The Canvas to show
    public GameObject prefabToInstantiate; // The Prefab to spawn
    public Transform spawnPoint; // Optional spawn location for the prefab
    private bool isPlayerInside = false; // Tracks if the player is inside the trigger
    private GameObject spawnedPrefab; // Reference to the spawned prefab

    private void Start()
    {
        // Ensure the Canvas is hidden initially
        if (canvas != null)
        {
            canvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;

            // Show the canvas
            if (canvas != null)
            {
                canvas.SetActive(true);
            }

            // Instantiate the prefab at the spawn point
            if (prefabToInstantiate != null && spawnedPrefab == null)
            {
                Vector3 position = spawnPoint != null ? spawnPoint.position : Vector3.zero;
                Quaternion rotation = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;

                spawnedPrefab = Instantiate(prefabToInstantiate, position, rotation);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger is the player
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }

    private void Update()
    {
        // Check if the player is inside the trigger and presses E
        if (isPlayerInside && Input.GetKeyDown(KeyCode.E))
        {
            CloseCanvasAndPrefab();
        }
    }

    private void CloseCanvasAndPrefab()
    {
        // Hide the Canvas
        if (canvas != null)
        {
            canvas.SetActive(false);
        }

        // Destroy the spawned prefab
        if (spawnedPrefab != null)
        {
            Destroy(spawnedPrefab);
            spawnedPrefab = null;
        }
    }
}