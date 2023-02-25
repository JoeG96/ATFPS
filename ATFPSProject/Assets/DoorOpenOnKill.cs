using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenOnKill : MonoBehaviour
{

    [SerializeField] Animator doorAnim;
    [SerializeField] GameObject enemyToKill;
    private Enemy enemyScript;

    void Start()
    {
        enemyScript = enemyToKill.GetComponent<Enemy>();
    }

    void FixedUpdate()
    {
        if (enemyScript.IsItDead())
        {
            doorAnim.SetTrigger("OpenDoor");
        }
    }
}
