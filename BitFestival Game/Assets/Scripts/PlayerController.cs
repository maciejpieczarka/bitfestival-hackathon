using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const float MAX_SPEED = 50.0f;

    private const float EPSILON = 0.001f;

    private float curSpeed = 0.0f;

    private bool movingForward = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float slideDuration = 1.0f;
    private float remainingSlideTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            remainingSlideTime -= Time.deltaTime;
            if (remainingSlideTime < 0.0f)
                remainingSlideTime = 0.0f;
        }
        else
        {
            remainingSlideTime += Time.deltaTime * 2;
            if (remainingSlideTime > slideDuration)
                remainingSlideTime = slideDuration;
        }

        curSpeed = (slideDuration - remainingSlideTime) / slideDuration * MAX_SPEED;

        transform.Translate(transform.forward * forwardInput * Time.deltaTime * curSpeed);
        transform.Translate(transform.right * horizontalInput * Time.deltaTime * curSpeed);
        Debug.Log("curSpeed: " + curSpeed);
    }
}
