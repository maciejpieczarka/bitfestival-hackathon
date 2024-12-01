using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtons : MonoBehaviour
{
    public Button[] buttons; // Array to hold the buttons
    public Toggle[] toggles; // Array to hold the toggles

    private void Start()
    {
        // Validate arrays
        if (buttons == null || toggles == null || buttons.Length != toggles.Length)
        {
            Debug.LogError("Ensure that buttons and toggles are assigned and have the same length.");
            return;
        }

        // Set toggles' background colors to red at the start
        foreach (Toggle toggle in toggles)
        {
            SetToggleState(toggle, false);
        }

        // Add click listeners to each button
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Local copy for the closure
            buttons[i].onClick.AddListener(() => HandleButtonClick(index));
        }
    }

    private void HandleButtonClick(int index)
    {
        switch (index)
        {
            case 0: // Button 0: Toggle even toggles
                ToggleSpecificToggles(true);
                break;

            case 1: // Button 1: Toggle odd toggles
                ToggleSpecificToggles(false);
                break;

            case 2: // Button 2: Toggle the first two toggles
                ToggleRange(0, 1);
                break;

            case 3: // Button 3: Toggle the last two toggles
                ToggleRange(toggles.Length - 2, toggles.Length - 1);
                break;

            case 4: // Button 4: Reset all toggles
                ResetAllToggles();
                break;
        }

        // Rotate the button
        TurnButton(index);
    }

    private void TurnButton(int index)
    {
        if (index < 0 || index >= buttons.Length)
        {
            Debug.LogWarning("Invalid button index for rotation.");
            return;
        }

        RectTransform buttonRectTransform = buttons[index].GetComponent<RectTransform>();
        if (buttonRectTransform != null)
        {
            // Toggle rotation between 180 and 0 degrees
            if (Mathf.Approximately(buttonRectTransform.rotation.eulerAngles.z, 180f))
            {
                buttonRectTransform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                buttonRectTransform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
        else
        {
            Debug.LogWarning($"Button at index {index} is missing a RectTransform.");
        }
    }


    private void ToggleSpecificToggles(bool even)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if ((i % 2 == 0) == even)
            {
                ToggleToggleState(toggles[i]);
            }
        }
    }

    private void ToggleRange(int startIndex, int endIndex)
    {
        for (int i = startIndex; i <= endIndex; i++)
        {
            ToggleToggleState(toggles[i]);
        }
    }

    private void ResetAllToggles()
    {
        foreach (Toggle toggle in toggles)
        {
            SetToggleState(toggle, false);
        }
    }

    private void ToggleToggleState(Toggle toggle)
    {
        bool isOn = toggle.isOn;
        SetToggleState(toggle, !isOn);
    }

    private void SetToggleState(Toggle toggle, bool state)
    {
        toggle.isOn = state;
        Image toggleBackground = toggle.GetComponentInChildren<Image>();
        if (toggleBackground != null)
        {
            toggleBackground.color = state ? Color.green : Color.red;
        }
    }
}
