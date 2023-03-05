using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private GameObject player;

    [SerializeField] int damageAmount;
    public float explosionRange;
    [SerializeField] float rocketSpeed;
    [SerializeField] Rigidbody _rb;

    public Vector3 direction;

    public GameObject expolosionObject;
    public AudioClip explosionClip;
    public AudioSource audioSource;

    private Animator spriteAnim;
    private AngleToPlayer angleToPlayer;

    void Start()
    {
        player = GameObject.Find("Player");

        direction = Camera.main.transform.forward;
        direction.Normalize();
        direction = direction * rocketSpeed;

        spriteAnim = GetComponentInChildren<Animator>();
        angleToPlayer = GetComponent<AngleToPlayer>();

        audioSource.clip = explosionClip;
    }

    void Update()
    {
        spriteAnim.SetFloat("spriteRot", angleToPlayer.lastIndex);
        _rb.velocity = direction * rocketSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {

        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange);

        foreach (Collider enemy in enemies)
        {
            Debug.Log("Enemies in enemies");
            if (enemy.GetComponentInParent<EnemyController>() != null)
            {
                Debug.Log("Enemy Component Inside Collider");
                enemy.GetComponentInParent<EnemyController>().TakeDamage(damageAmount);
            }

        }
        
        GameObject go = Instantiate(expolosionObject, transform.position, Quaternion.identity);
        Destroy(go, 1);
        audioSource.PlayOneShot(explosionClip);
        Destroy(this.gameObject);

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Environment"))
        {
            Destroy(this.gameObject);
        }
    }
}
