using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablingMinigames : MonoBehaviour
{
    public Canvas canvas; // Reference to the Canvas
    public GameObject spamButtonMinigame; // Name of the child GameObject to activate
    void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            spamButtonMinigame.SetActive(!spamButtonMinigame.activeSelf);
        }
    }
}
