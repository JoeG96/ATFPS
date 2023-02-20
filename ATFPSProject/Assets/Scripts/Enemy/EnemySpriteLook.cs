using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteLook : MonoBehaviour
{

    private Transform target;
    public bool canLookVertical;

    void Start()
    {
        target = FindObjectOfType<PlayerMotor>().transform;
    }

    void Update()
    {
       
        if (canLookVertical)
        {
            transform.LookAt(target);
        }
        else
        {
            Vector3 modifiedTarget = target.position;
            modifiedTarget.y = transform.position.y;
            transform.LookAt(modifiedTarget);
        }
        
    }
}
