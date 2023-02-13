using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public EnemyManager enemyManager;
    [SerializeField] float health;

    void Start()
    {
        health = 100;
    }

    private void Update()
    {
        if (health <= 0)
        {
            //enemyManager.RemoveEnemy(this);
            Destroy(this.gameObject);
        }
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Enemy Health = " + health);
    }
}
