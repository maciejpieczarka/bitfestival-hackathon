using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpinnerButton : MonoBehaviour
{
    public Button targetButton; // Assign the button in the Inspector
    public float spinSpeed = -200f; // Speed of the rotation in degrees per second
    public float angleErrorMargin = 20f;
    private int timesSpined = 0;
    private RectTransform buttonRectTransform;
    private bool isSpinning = true;
    private float originalZRotation; // The initial rotation of the button on the Z-axis
    public TextMeshProUGUI tmpText;
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

        // Store the original rotation of the button
        originalZRotation = buttonRectTransform.localEulerAngles.z;

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

        // Check if the button's rotation is within ±45 degrees of the original rotation
        float currentZRotation = buttonRectTransform.localEulerAngles.z;

        // Normalize the angles for comparison
        float rotationDifference = Mathf.DeltaAngle(originalZRotation, currentZRotation);
        Debug.Log(rotationDifference);
        if (Mathf.Abs(rotationDifference) <= angleErrorMargin)
        {
            timesSpined++;
            if(timesSpined < 3)
            {
                spinSpeed *= -1.3f;
                isSpinning = true;
            }
            else
            {
                tmpText.text = "Vault opened";
            }
        }
        else
        {
            tmpText.text = "You failed!";
        }
    }
}
