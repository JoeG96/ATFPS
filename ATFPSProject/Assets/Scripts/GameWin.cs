using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{

    [SerializeField] LevelManager levelManager;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided");

        if (other.gameObject.name == ("Player"))
        {
           //Debug.Log("Collided with player");
            levelManager.SetLevelWon();
        }
    }
}
