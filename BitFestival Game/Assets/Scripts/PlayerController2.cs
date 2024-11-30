using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private const float MAX_WALKING_SPEED = 5.0f;
    private const float RUNNING_TO_WALKING_RATIO = 2.0f;
    private const float ROTATION_SMOOTHNESS = 10.0f; // Controls how smooth the rotation is

    private float m_Speed = 0.0f;
    private bool running = false;

    private Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
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
}
