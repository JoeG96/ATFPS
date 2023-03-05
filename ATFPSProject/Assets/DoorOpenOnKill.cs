using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenOnKill : MonoBehaviour
{

    [SerializeField] Animator doorAnim;
    [SerializeField] GameObject enemyToKill;
    private EnemyController enemyScript;

    void Start()
    {
        enemyScript = enemyToKill.GetComponent<EnemyController>();
    }

    void FixedUpdate()
    {
        if (enemyScript.IsItDead())
        {
            doorAnim.SetTrigger("OpenDoor");
        }
    }
}
