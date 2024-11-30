using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float MAX_WALKING_SPEED = 5.0f;
    private const float MAX_RUNNING_SPEED = 25.0f;
    private const float ROTATION_SPEED = 120.0f;
    private const float BACKWARDS_TO_FORWARD_RATIO = 0.8f;

    private float m_Speed = 0.0f;
    private bool movingForwards = false;
    private bool movingBackwards = false;

    private Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    private float slideDuration = 1.0f;
    private float remainingSlideTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("moving forwards: " + Time.time);
            movingForwards = true;
            movingBackwards = false;
        }  
        else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("moving backwards: " + Time.time);
            movingForwards = false;
            movingBackwards = true;
        }
        else
        {
            Debug.Log("not moving: " + Time.time);
            movingForwards = false;
            movingBackwards = false;
        }

        if (movingForwards || movingBackwards)
        {
/*            Debug.Log("walking: " + Time.time);
*/            m_Animator.SetBool("walking", true);
            remainingSlideTime -= Time.deltaTime;
            if (remainingSlideTime < 0.0f)
                remainingSlideTime = 0.0f;
        }
        else
        {
            m_Animator.SetBool("walking", false);
            remainingSlideTime += Time.deltaTime * 2;
            if (remainingSlideTime > slideDuration)
                remainingSlideTime = slideDuration;
        }

        m_Animator.SetBool("movingBackwards", movingBackwards);

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -ROTATION_SPEED * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, ROTATION_SPEED * Time.deltaTime, 0);

        float speedFactor = (slideDuration - remainingSlideTime) / slideDuration;
        if (movingBackwards)
            speedFactor *= BACKWARDS_TO_FORWARD_RATIO;

        m_Speed = speedFactor * MAX_WALKING_SPEED;
        m_Animator.SetFloat("movingSpeed", speedFactor);

        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * m_Speed);

    }
}
