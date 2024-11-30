using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinnerButton : MonoBehaviour
{
    public Button targetButton; // Assign the button in the Inspector
    public float spinSpeed = 100f; // Speed of the rotation in degrees per second

    private RectTransform buttonRectTransform;
    private bool isSpinning = true;

    private void Start()
    {
        // Ensure the button is assigned
        if (targetButton == null)
        {
            Debug.LogError("No button assigned to the ParentButtonSpinner script.");
            return;
        }

        // Get the RectTransform of the target button
        buttonRectTransform = targetButton.GetComponent<RectTransform>();

        if (buttonRectTransform == null)
        {
            Debug.LogError("Target Button does not have a RectTransform component.");
            return;
        }

        // Add a listener to the button's onClick event
        targetButton.onClick.AddListener(StopSpinning);
    }

    private void Update()
    {
        // Rotate the button if spinning is enabled
        if (isSpinning && buttonRectTransform != null)
        {
            buttonRectTransform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
        }
    }

    private void StopSpinning()
    {
        // Stop the spinning
        isSpinning = false;
        Debug.Log("Button spinning stopped.");
    }
}
