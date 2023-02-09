using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    private Camera cam;
    [SerializeField] float _distance = 3f;
    [SerializeField] LayerMask _layerMask;

    private PlayerUI _pUI;
    private InputManager _inputManager;

    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        _pUI = GetComponent<PlayerUI>();
        _inputManager = GetComponent<InputManager>();
    }

    void Update()
    {

        _pUI.UpdateText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, _distance, _layerMask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {

                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

                _pUI.UpdateText(interactable.promptMessage);
                if (_inputManager._inGame.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }

    }
}
