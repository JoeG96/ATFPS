using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    //[SerializeField] Rigidbody rb;

    [SerializeField] float health;
    [SerializeField] float killScore;
    //[SerializeField] float playerRange;
    //[SerializeField] float moveSpeed;
    private bool addedScore = false;
    public bool isDead;

    
    private Animator spriteAnim;
    private AngleToPlayer angleToPlayer;

    private Vector3 deathPos;
    private LevelManager levelManager;

    public Transform player;
    public LayerMask groundLayer;
    public LayerMask playerLayer;

    public NavMeshAgent agent;
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;
    public float sightRange;
    public float attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange;

    public bool shouldShoot;
    public float fireRate = .5f;
    private float shotCounter;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;

    public AudioClip attackSound;
    public AudioClip sightSound;
    public AudioClip injurySound;
    public AudioClip deathSound;

    private AudioSource audioSource;

    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        spriteAnim = GetComponentInChildren<Animator>();
        angleToPlayer = GetComponent<AngleToPlayer>();

        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();

        player = GameObject.Find("Player").transform;
    }


    void FixedUpdate()
    {
        
        deathPos = new Vector3(transform.position.x, transform.position.y / 2, transform.position.z);

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
        
        if (!isDead)
        {
            
            if (!playerInSightRange && !playerInAttackRange)
            {
                spriteAnim.SetFloat("spriteRot", angleToPlayer.lastIndex);
                Patrolling();
            }

            if (playerInSightRange && !playerInAttackRange)
            {
                spriteAnim.SetFloat("spriteRot", angleToPlayer.lastIndex);
                ChasePlayer();
            }

            if (playerInSightRange && playerInAttackRange)
            {
                AttackPlayer();
            }
        }

        
        if (health <= 0 && !isDead)
        {
            audioSource.PlayOneShot(deathSound);
            isDead = true;

        }
        if (isDead)
        {
            if (addedScore == false)
            {
                levelManager.AddToCurrentScore(killScore);
                addedScore = true;
            }
            agent.SetDestination(transform.position);
            CapsuleCollider collider = transform.Find("EnemySprite").GetComponent<CapsuleCollider>();
            collider.enabled = false;
            transform.position = Vector3.Lerp(transform.position, deathPos, 1f * Time.deltaTime);
            spriteAnim.SetBool("isDead", true);

        }
    }

    public void TakeDamage(float damage)
    {
        deathPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        health -= damage;

        if (health >= 0 + damage)
        {
            audioSource.PlayOneShot(injurySound);
        }

    }

    private void Patrolling()
    {
        
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {

        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (shouldShoot)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                if (spriteAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && ! spriteAnim.IsInTransition(0))
                {
                    spriteAnim.SetTrigger("Attack");
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate;
                    audioSource.PlayOneShot(attackSound);
                    if (GetComponent<SpawnImps>() != null)
                    {
                        GetComponent<SpawnImps>().SpawnEnemy();
                        GetComponent<SpawnImps>().SpawnEnemy();
                    }
                }
                agent.SetDestination(player.position);
            }
        }
    }

    public bool IsItDead()
    {
        return isDead;
    }
}
