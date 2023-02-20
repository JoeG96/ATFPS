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

    private GunManager _pGunManager;
    private LevelManager _levelManager;


    void Awake()
    {
        _playerInput = new PlayerInput();
        _inGame = _playerInput.InGame;
        _pMotor = GetComponent<PlayerMotor>();
        _pLook = GetComponent<PlayerLook>();
        _pGunManager = GetComponent<GunManager>();
        _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();


        _inGame.Jump.performed += ctx => _pMotor.HandleJump();
        _inGame.Shoot.performed += ctx => _pGunManager.ShootWeapon();
        _inGame.WeaponSelect1.performed += ctx => _pGunManager.SetWeaponToPistol();
        _inGame.WeaponSelect2.performed += ctx => _pGunManager.SetWeaponToShotgun();
        _inGame.Escape.performed += ctx => _levelManager.PauseGame();

        Cursor.lockState = CursorLockMode.Locked;
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

    private void OnLeftClick()
    {
        //_inGame.Shoot.performed += ctx => _gunScript.MyInput();
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
