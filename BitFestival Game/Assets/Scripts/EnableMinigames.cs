using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMinigames : MonoBehaviour
{
    public Canvas canvas; // Reference to the Canvas
    public GameObject spamButtonMinigame; // Name of the child GameObject to activate

    private PlayerController2 playerController;

    private bool firstDoorOpened = false;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController2>();
    }

    void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("ummm deep! " + Time.time);
            switch (playerController.possibleAction)
            {
                case PlayerController2.PossibleAction.OPEN_FIRST_DOOR:
                    Debug.Log("Ahh, deeeper! " + Time.time);
                    if (!firstDoorOpened)
                        spamButtonMinigame.SetActive(true);
                    break;
            }
        }
    }

    public void OpenFristDoor()
    {
        firstDoorOpened = true;
    }
}
