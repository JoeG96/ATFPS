using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    public bool isRedKey, isBlueKey, isGreenKey;
    public AudioSource audioSource;
    public AudioClip keyCardPickupSound;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(keyCardPickupSound, 0.5f);
            if (isRedKey)
            {
                other.GetComponent<PlayerInventory>().hasRedKey = true;
            }
            
            if (isBlueKey)
            {
                other.GetComponent<PlayerInventory>().hasBlueKey = true;
            }

            if (isGreenKey)
            {
                other.GetComponent<PlayerInventory>().hasGreenKey = true;
            }
            
            other.GetComponent<PlayerInventory>().CheckKeys();
            Destroy(this.gameObject);
        }

    }
}
