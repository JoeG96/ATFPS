using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    [SerializeField] bool isHealth;
    [SerializeField] bool isArmor;
    [SerializeField] bool isSlugs;
    [SerializeField] bool isBullets;

    [SerializeField] float amount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isHealth)
            {
                other.GetComponent<PlayerHealth>().RestoreHealth(amount, this.gameObject);
            }

            if (isArmor)
            {
                other.GetComponent<PlayerHealth>().RestoreArmor(amount, this.gameObject);
            }

            if (isSlugs)
            {
                other.GetComponent<GunManager>().RestoreShotgunAmmo(amount, this.gameObject);
            }
            
            if (isBullets)
            {
                other.GetComponent<GunManager>().RestorePistolAmmo(amount, this.gameObject);
            }

            
        }
    }
}
