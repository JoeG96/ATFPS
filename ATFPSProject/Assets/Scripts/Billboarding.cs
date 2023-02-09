using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{

    private Vector3 _cameraDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _cameraDir = Camera.main.transform.forward;
        _cameraDir.y = 0;

        transform.rotation = Quaternion.LookRotation(_cameraDir);
    }
}
