using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    [SerializeField] bool isHealth;
    [SerializeField] bool isArmor;
    [SerializeField] bool isAmmo;

    [SerializeField] float amount;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

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

            if (isAmmo)
            {
                other.GetComponent<PlayerCombat>().RestoreAmmo(amount, this.gameObject);
            }

            
        }
    }
}
