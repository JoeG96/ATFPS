using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{

    private Vector3 _cameraDir;

    void Start()
    {
        
    }

    void Update()
    {
        _cameraDir = Camera.main.transform.forward;
        _cameraDir.y = 0;

        transform.rotation = Quaternion.LookRotation(_cameraDir);
    }
}
