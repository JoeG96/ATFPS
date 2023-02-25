using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBullet : MonoBehaviour
{

    public Rigidbody rb;
    public LayerMask playerLayer;

    public int bulletDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerHealth>().TakeDamage(bulletDamage);
            Destroy(this.gameObject);
        }

        if (collision.collider.gameObject.layer != LayerMask.NameToLayer("Enemy"))
        {
            Destroy(this.gameObject);
        }
        

    }


}
