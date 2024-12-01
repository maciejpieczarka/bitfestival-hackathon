using UnityEngine;

public class RotateAndMoveUpDown : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed at which the object rotates
    public float moveSpeed = 2f;      // Speed at which the object moves up and down
    public float moveHeight = 2f;     // Maximum height to move up and down
    public bool moveUpwards = true;  // Direction of movement (up or down)

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;
    }

    void Update()
    {
        // Rotate the object around its own axis (local rotation)
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);

        // Move the object up and down in a sine wave pattern
        float newYPosition = Mathf.PingPong(Time.time * moveSpeed, moveHeight);
        transform.position = new Vector3(initialPosition.x, initialPosition.y + newYPosition, initialPosition.z);
    }
}
