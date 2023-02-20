using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health;
    [SerializeField] float killScore;
    private bool addedScore = false;
    private bool isDead;

    private Animator spriteAnim;
    private AngleToPlayer angleToPlayer;

    private Vector3 deathPos;

    private LevelManager levelManager;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundLayer;
    public LayerMask playerLayer;

    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    public float sightRange;
    public float attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange;

    void Start()
    {
        health = 100;

        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        spriteAnim = GetComponentInChildren<Animator>();
        angleToPlayer = GetComponent<AngleToPlayer>();

        

        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();


    }

    private void Update()
    {
        deathPos = new Vector3(transform.position.x, transform.position.y / 2, transform.position.z);
        spriteAnim.SetFloat("spriteRot", angleToPlayer.lastIndex);

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (!isDead)
        {
            if (!playerInSightRange && !playerInAttackRange)
            {
                Patrolling();
            }

            if (playerInSightRange && !playerInAttackRange)
            {
                ChasePlayer();
            }

            if (playerInSightRange && playerInAttackRange)
            {
                AttackPlayer();
            }
        }
        
        if (health <= 0)
        {
            isDead = true;
            
        }
        if (isDead)
        {
            if (addedScore == false)
            {
                levelManager.AddToCurrentScore(killScore);
                addedScore = true;
            }
            
            CapsuleCollider collider = GameObject.Find("EnemyCollider").GetComponent<CapsuleCollider>();
            collider.enabled = false;
            transform.position = Vector3.Lerp(transform.position, deathPos, 1f * Time.deltaTime);
            spriteAnim.SetBool("isDead", true);

        }
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Enemy Health = " + health);
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

        if (!alreadyAttacked)
        {



            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
