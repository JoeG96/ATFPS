using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInput _playerInput;
    public PlayerInput.InGameActions _inGame;
    private PlayerMotor _pMotor;
    private PlayerLook _pLook;


    void Awake()
    {
        _playerInput = new PlayerInput();
        _inGame = _playerInput.InGame;
        _pMotor = GetComponent<PlayerMotor>();
        _pLook = GetComponent<PlayerLook>();

        _inGame.Jump.performed += ctx => _pMotor.HandleJump();
    }


    void FixedUpdate()
    {
        _pMotor.HandleMove(_inGame.Movement.ReadValue<Vector2>());
        _pMotor.HandleHeadBob();
        
    }

    private void LateUpdate()
    {
        _pLook.HandleLook(_inGame.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _inGame.Enable();
    }

    private void OnDisable()
    {
        _inGame.Disable();
    }
}
