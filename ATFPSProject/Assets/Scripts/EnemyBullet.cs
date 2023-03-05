using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;

    [SerializeField] int damageAmount;
    [SerializeField] float bulletSpeed;
    [SerializeField] Rigidbody _rb;

    public Vector3 direction;

    void Start()
    {
        player = GameObject.Find("Player");

        direction = player.transform.position - transform.position;
/*        Debug.Log("Player transform: " + player.transform.position);
        Debug.Log("Direction: " + direction);*/
        direction.Normalize();
        direction = direction * bulletSpeed;
    }

    void Update()
    {
        _rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Collided with player");
            collision.collider.GetComponentInParent<PlayerHealth>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Environment"))
        {
            Destroy(this.gameObject);
        }
    }
}
