using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private const float MAX_WALKING_SPEED = 10.0f;
    private const float RUNNING_TO_WALKING_RATIO = 2.0f;
    private const float ROTATION_SMOOTHNESS = 10.0f; // Controls how smooth the rotation is

    private float m_Speed = 0.0f;
    private bool running = false;

    private float lastTrigger = 0.0f;
    private float triggerRecover = 0.3f;

    private Animator m_Animator;

    private CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();

        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // Handle input for movement
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.forward; // Move up
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.back; // Move down
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left; // Move left
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right; // Move right
        }

        // Check if running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
        }
        else
        {
            running = false;
        }

        // Normalize movement direction to prevent faster diagonal movement
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        // Set speed based on movement and running state
        m_Speed = MAX_WALKING_SPEED;
        if (running)
        {
            m_Speed *= RUNNING_TO_WALKING_RATIO;
        }

        // Update animation states
        m_Animator.SetBool("walking", moveDirection != Vector3.zero);
        m_Animator.SetBool("running", running);
        m_Animator.SetFloat("movingSpeed", moveDirection.magnitude);

        // Move the character
        transform.Translate(moveDirection * m_Speed * Time.deltaTime, Space.World);

        // Smoothly adjust character's rotation to face the movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * ROTATION_SMOOTHNESS);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (lastTrigger + triggerRecover > Time.time)
            return;
        
        lastTrigger = Time.time;
        if (other.CompareTag("trigger"))
        {
            if (other.GetComponent<DoorTrigger>() == null)
                return;

            DoorTrigger.Trigger trigger = other.GetComponent<DoorTrigger>().trigger;
            cameraController.SwitchRoomView(trigger);
            switch (trigger)
            {
                case DoorTrigger.Trigger.FROM_1_TO_2:
                    transform.position = new Vector3(0, 0, -14);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case DoorTrigger.Trigger.FROM_2_TO_1:
                    transform.position = new Vector3(0, 0, -19);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                case DoorTrigger.Trigger.FROM_2_TO_3:
                    transform.position = new Vector3(0, 0, 25);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case DoorTrigger.Trigger.FROM_3_TO_2:
                    transform.position = new Vector3(0, 0, 19);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
            }
        }
    }
}
