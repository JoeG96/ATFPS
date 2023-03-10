using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    public bool isRedKey, isBlueKey, isGreenKey;


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (isRedKey)
            {
                other.GetComponent<PlayerInventory>().PickupKey(0);
            }
            
            if (isBlueKey)
            {
                other.GetComponent<PlayerInventory>().PickupKey(2);
            }

            if (isGreenKey)
            {
                other.GetComponent<PlayerInventory>().PickupKey(1);
            }
            
            other.GetComponent<PlayerInventory>().CheckKeys();
            Destroy(this.gameObject);
        }

    }
}
