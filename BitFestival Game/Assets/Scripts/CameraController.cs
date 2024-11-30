using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float Y_POSITION = 20.0f;

    private Room room1 = new Room(-2, -28, 2, -25);

    private Room currentRoom;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentRoom = room1;

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var playerPosition = player.transform.position;
        float xPos = Math.Min(Math.Max(playerPosition.x, currentRoom.lowerXBound), currentRoom.upperXBound);
        float zPos = Math.Min(Math.Max(playerPosition.z, currentRoom.lowerZBound), currentRoom.upperZBound);
        transform.position = new Vector3(xPos, Y_POSITION, zPos);
    }
}
public struct Room
{
    public Room(
        float lowerXBound,
        float lowerZBound,
        float upperXBound,
        float upperZBound)
    {
        this.lowerXBound = lowerXBound;
        this.lowerZBound = lowerZBound;
        this.upperXBound = upperXBound;
        this.upperZBound = upperZBound;
    }

    public float lowerXBound;
    public float lowerZBound;
    public float upperXBound;
    public float upperZBound;
}