using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorOnTrigger : Interactable
{

    [SerializeField] GameObject door;
    private bool doorOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!doorOpen)
        {
            doorOpen = false;
            door.GetComponent<Animator>().SetBool("isOpen", doorOpen);
        }
        
        
    }

}
