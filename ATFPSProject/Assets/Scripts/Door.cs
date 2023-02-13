using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] Animator doorAnim;
    //[SerializeField] GameObject areToSpawn;

    public bool requiresKey;
    public bool reqRed, reqBlue, reqGreen;


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {

            if (requiresKey)
            {
                if (reqRed && other.GetComponent<PlayerInventory>().hasRedKey)
                {
                    doorAnim.SetTrigger("OpenDoor");
                }

                if (reqBlue && other.GetComponent<PlayerInventory>().hasBlueKey)
                {
                    doorAnim.SetTrigger("OpenDoor");
                }

                if (reqGreen && other.GetComponent<PlayerInventory>().hasGreenKey)
                {
                    doorAnim.SetTrigger("OpenDoor");

                }
            }
            else
            {
                doorAnim.SetTrigger("OpenDoor");
            }

            
            
            //areToSpawn.SetActive(true); // used to keep enemies disabled until door opens, would require gameobject with enemies as children placed in room and parent object disabled
        }

    }

}
