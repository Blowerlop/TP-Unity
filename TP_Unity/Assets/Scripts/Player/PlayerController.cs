using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables

    private bool _isGrounded;

    [Header("Horizontal Movements")]
    [SerializeField] private float _speed;

    [Header("References")]
    private CharacterController _characterController;

    #endregion


    #region Updates

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Update()
    {
        IsGrounded();
        Move();
    }

    public void LateUpdate()
    {
        CameraRotation();
    }

    


    #endregion


    #region Methods

    private void Move()
    {
        Vector3 moveDirection = new Vector3(InputManager.instance.move.x, 0.0f, InputManager.instance.move.y); // Raw
        moveDirection = transform.right * moveDirection.x + transform.forward * moveDirection.z;
        _characterController.Move(moveDirection * _speed * Time.fixedDeltaTime);
    }

    private void IsGrounded()
    {
        _isGrounded = _characterController.isGrounded;
    }

    private void CameraRotation()
    {
        Vector3 rotateDirection = new Vector3(0, InputManager.instance.look.x, 0); ;
        transform.Rotate(rotateDirection * _speed * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Collide");
    }
    #endregion
}
