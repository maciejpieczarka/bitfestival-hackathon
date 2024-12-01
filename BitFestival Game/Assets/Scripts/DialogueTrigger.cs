using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject canvas; // The Canvas to display
    public GameObject firstPrefab; // The first prefab to spawn
    public GameObject secondPrefab; // The second prefab to spawn

    private bool isPlayerInside = false; // Tracks if the player is inside the trigger
    private GameObject activePrefab; // Reference to the currently active prefab

    private void Start()
    {
        // Ensure the Canvas is hidden at the start
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

            // Show the Canvas
            if (canvas != null)
            {
                canvas.SetActive(true);
            }

            // Spawn the first prefab
            if (firstPrefab != null)
            {
                Vector3 position =  Vector3.zero;
                Quaternion rotation =  Quaternion.identity;

                firstPrefab.SetActive(true);
                activePrefab = Instantiate(firstPrefab, position, rotation);
            }
        }
    }

    private void Update()
    {
        // Check if the player is inside and presses any key
        if (isPlayerInside && activePrefab != null)
        {
            Debug.Log("Prefab close");
            SwitchToSecondPrefab();
        }
    }

    private void SwitchToSecondPrefab()
    {
        
        // Spawn the second prefab
        if (secondPrefab != null)
        {
            Vector3 position =  Vector3.zero;
            Quaternion rotation =  Quaternion.identity;

            secondPrefab.SetActive(true);
            activePrefab = Instantiate(secondPrefab, position, rotation);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the trigger
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;

            // Hide the Canvas and destroy any active prefab
            if (canvas != null)
            {
                canvas.SetActive(false);
            }

            if (activePrefab != null)
            {
                Destroy(activePrefab);
                activePrefab = null;
            }
        }
    }
}
