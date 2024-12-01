using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnableMinigames : MonoBehaviour
{
    public Canvas canvas; // Reference to the Canvas
    public GameObject spamButtonMinigameFirstDoor; // Name of the child GameObject to activate
    public GameObject spamButtonMinigameSecondDoor; // Name of the child GameObject to activate
    public GameObject vaultMiniGame; // Name of the child GameObject to activate
    public GameObject switchMiniGame; // Name of the child GameObject to activate

    private PlayerController2 playerController;

    private bool firstDoorOpened = false;
    private bool secondDoorOpened = false;
    private bool switchesDone = false;
    private bool vaultDone = false;

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
                case PlayerController2.PossibleAction.DO_SWITCHES:
                    if (!switchesDone)
                        switchMiniGame.SetActive(true);
                    break;
                case PlayerController2.PossibleAction.DO_VAULT:
                    if (!switchesDone)
                        vaultMiniGame.SetActive(true);
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            vaultMiniGame.SetActive(!vaultMiniGame.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            switchMiniGame.SetActive(!switchMiniGame.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("EndMenu");
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

    public void doSwitches()
    {
        switchesDone = true;
    }

    public void doVault()
    {
        vaultDone = true;
    }
}
