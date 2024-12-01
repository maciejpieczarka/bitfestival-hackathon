using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public enum Trigger
    {
        FROM_1_TO_2,
        FROM_2_TO_1,
        FROM_2_TO_3,
        FROM_3_TO_2,
        SOME_TRIGGER,
        OPEN_FIRST_DOOR_TRIGGER,
    }

    public Trigger trigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
