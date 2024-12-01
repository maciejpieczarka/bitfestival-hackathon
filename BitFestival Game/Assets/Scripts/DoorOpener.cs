using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public float doorOpeningTime = 1.5f;
    public float doorOpenTime = 1.0f;
    public bool openLeft = true;

    public bool triggerOpen = true;
    private bool triggerWaiting = false;
    private bool triggerClose = false;

    private float doorChangingStateProgress = 0.0f;
    private float initialXPosition;
    private float deltaX;

    // Start is called before the first frame update
    void Start()
    {
        initialXPosition = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (triggerOpen)
        {
            doorChangingStateProgress += Time.deltaTime;
            

            if (doorChangingStateProgress > doorOpeningTime)
            {
                triggerOpen = false;
                triggerWaiting = true;
                doorChangingStateProgress = 0;
            }
        }
        if (triggerWaiting)
        {
            doorChangingStateProgress += Time.deltaTime;

            if (doorChangingStateProgress > doorOpenTime)
            {
                triggerWaiting = false;
                triggerClose = true;
                doorChangingStateProgress = 0;
            }
        }
        if (triggerClose)
        {
            doorChangingStateProgress += Time.deltaTime;

            if (doorChangingStateProgress > doorOpeningTime)
            {
                triggerClose = false;
                triggerOpen = true;
                doorChangingStateProgress = 0;
            }
        }
    }
}
