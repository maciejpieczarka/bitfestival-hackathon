using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMinigames : MonoBehaviour
{
    public Canvas canvas; // Reference to the Canvas
    public GameObject spamButtonMinigameFirstDoor; // Name of the child GameObject to activate
    public GameObject spamButtonMinigameSecondDoor; // Name of the child GameObject to activate

    private PlayerController2 playerController;

    private bool firstDoorOpened = false;
    private bool secondDoorOpened = false;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController2>();
    }

    void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (playerController.possibleAction)
            {
                case PlayerController2.PossibleAction.OPEN_FIRST_DOOR:
                    if (!firstDoorOpened)
                        spamButtonMinigameFirstDoor.SetActive(true);
                    break;
                case PlayerController2.PossibleAction.OPEN_SECOND_DOOR:
                    if (!secondDoorOpened)
                        spamButtonMinigameSecondDoor.SetActive(true);
                    break;
            }
        }
    }

    public void OpenFristDoor()
    {
        firstDoorOpened = true;
    }

    public void OpenSecondDoor()
    {
        secondDoorOpened = true;
    }
}
