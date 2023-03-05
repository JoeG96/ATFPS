using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour
{
    public float barrelHealth = 10;
    public float barrelDamage = 100;
    public float explosionRange;
    public bool barrelAlive;
    public GameObject expolosionObject;
    public LayerMask enemyLayer;
    public GameObject spriteObject;

    public AudioClip explosionClip;
    public AudioSource audioSource;

    void Start()
    {
        barrelAlive = true;
        spriteObject.SetActive(true);
        audioSource.clip = explosionClip;
    }


    void Update()
    {
        if (barrelHealth <= 0)
        {
            barrelAlive = false;
        }

        if (!barrelAlive)
        {
            DestroyBarrel();
        }
    }

    public void DestroyBarrel()
    {

        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange);

        foreach(Collider enemy in enemies)
        {
            Debug.Log("Enemies in enemies");
            if (enemy.GetComponentInParent<EnemyController>() != null)
            {
                Debug.Log("Enemy Component Inside Collider");
                enemy.GetComponentInParent<EnemyController>().TakeDamage(barrelDamage);
            }
            
        }
        

        GameObject go = Instantiate(expolosionObject, transform.position, Quaternion.identity);
        Destroy(go, 1);
        
        spriteObject.SetActive(false);
        audioSource.Play();
        barrelAlive = true;
        Destroy(this.gameObject);
    }

    public void TakeDamage(float amount)
    {
        barrelHealth -= amount;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
