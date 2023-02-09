using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    private CharacterController _cc;
    private Vector3 _playerVelocity;
    private bool _isGrounded;

    [SerializeField] float speed = 5f;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] float jumpHeight = 3;

    [SerializeField] float headBobSpeed;
    [SerializeField] float headBobAmount;
    private float _defaultYPos = 0;
    private float _timer;

    private Camera cam;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
        cam = GetComponent<PlayerLook>().cam;
        _defaultYPos = cam.transform.localPosition.y;
    }


    void Update()
    {
        _isGrounded = _cc.isGrounded;
    }

    public void HandleMove(Vector2 input)
    {

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        _cc.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        
        if (_isGrounded && _playerVelocity.y <0)
        {
            _playerVelocity.y = -2f;
        }
        _playerVelocity.y += gravity * Time.deltaTime;
        _cc.Move(_playerVelocity * Time.deltaTime);

        if (Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) > 0.1f)
        {
            _timer += Time.deltaTime * (headBobSpeed);
            cam.transform.localPosition = new Vector3
                (cam.transform.localPosition.x, _defaultYPos + Mathf.Sin(_timer) * (headBobAmount), cam.transform.localPosition.z);
        }

    }

    public void HandleJump()
    {
        if (_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void HandleHeadBob()
    {
        if (!_isGrounded)
        {
            return;
        }


    }
}
