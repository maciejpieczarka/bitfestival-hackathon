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
            switch (playerController.possibleAction)
            {
                case PlayerController2.PossibleAction.OPEN_FIRST_DOOR:
                    if (!firstDoorOpened)
                        spamButtonMinigame.SetActive(true);
                    break;
            }
        }
    }

    public void OpenFristDoor()
    {
        firstDoorOpened = true;
        GameObject.Find("door1 trigger1").transform.position = new Vector3(0.0f, 5.91f, -16.75f);
    }
}
