using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleButtons : MonoBehaviour
{
    public Button[] buttons; // Array to hold the buttons
    public Toggle[] toggles; // Array to hold the toggles

    private bool[] buttonStates; // Array to track the state of each button

    private void Start()
    {
        // Validate arrays
        if (buttons.Length != 5 || toggles.Length != 5)
        {
            Debug.LogError("Ensure there are exactly 5 buttons and 5 toggles assigned.");
            return;
        }

        // Initialize button states
        buttonStates = new bool[buttons.Length];

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
                ToggleRange(3, 4);
                break;

            case 4: // Button 4: Reset all toggles
                ResetAllToggles();
                break;
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
