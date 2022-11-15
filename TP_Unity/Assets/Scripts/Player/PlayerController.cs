using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    #region Variables

    private bool _isGrounded;

    [Header("Movements")]
    [SerializeField] [Min(2.0f)] private float _walkingSpeed = 2.0f;
    [SerializeField] [Min(5.0f)] private float _runningSpeed = 5.0f;
    [SerializeField] private float _jumpHeight = 2.0f;
    [SerializeField] private float _gravityForce = -9.81f;
    [SerializeField] private bool _gravityEnabled = true;
    [SerializeField] private float _maximumVerticalVelocity = -40.0f;
    [SerializeField] private float _groundedVerticalVelocity = -2.0f;
    private float _verticalVelocity;

    [Header("Camera")] 
    [SerializeField] private Transform _cameraRootTransform;
    [SerializeField] private float _sensitivity = 0.2f;
    [SerializeField] private float _threshold = 0.001f;

    
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
        GroundedCheck();
        Move();
        JumpAndGravity();

    }

    public void LateUpdate()
    {
        CameraRotation();
    }

    


    #endregion


    #region Methods

    private void Move()
    {
        float targetVelocity;
        if (InputManager.instance.move == Vector2.zero)
        {
            targetVelocity = 0.0f;
        }
        else
        {
            targetVelocity = InputManager.instance.isRunning ? _runningSpeed : _walkingSpeed;
        }

        float currentVelocity = new Vector3(_characterController.velocity.x, 0.0f, _characterController.velocity.z).magnitude;
        float velocityToApply;
        
        if (currentVelocity < targetVelocity - 0.1f || currentVelocity > targetVelocity + 0.1f)
        {
            velocityToApply = Mathf.Lerp(currentVelocity, targetVelocity, Time.deltaTime * 10.0f);
        }
        else
        {
            velocityToApply = targetVelocity;
        }

        


        
        Vector2 moveHorizontalVelocity = InputManager.instance.move * velocityToApply;
        Vector3 moveVerticalVelocity = Vector3.up * _verticalVelocity;

        
        _characterController.Move
            (
            ((moveHorizontalVelocity.x * transform.right + moveHorizontalVelocity.y * transform.forward) + moveVerticalVelocity) 
            * Time.deltaTime
            );


    }

    private void JumpAndGravity()
    {
        if (_gravityEnabled == false) return;

        if (_isGrounded)
        {
            if (_verticalVelocity < 0.0f)
            {
                _verticalVelocity = _groundedVerticalVelocity;
            }

            if (InputManager.instance.isJumping)
            {
                _verticalVelocity = Mathf.Sqrt(-2.0f * _gravityForce * _jumpHeight);
            }
        }
        else
        {
            if (_verticalVelocity > _maximumVerticalVelocity)
            {
                _verticalVelocity += _gravityForce * Time.deltaTime;
            }
        }
        
        
    }

    private void GroundedCheck()
    {
        _isGrounded = _characterController.isGrounded;
    }

    private void CameraRotation()
    {
        if (InputManager.instance.look.sqrMagnitude >= _threshold)
        {
            float rotateHorizontalVelocity = InputManager.instance.look.x * _sensitivity;
            float rotateVerticalVelocity = InputManager.instance.look.y * _sensitivity;
            
            
            //_cameraRootTransform.Rotate(rotateVerticalVelocity * Vector3.right);
            var aaaa = rotateVerticalVelocity + _cameraRootTransform.localRotation.eulerAngles.x;
            //Debug.Log(aaaa);
            //aaaa = ClampAngle(aaaa, -70.0f, 70.0f);
            _cameraRootTransform.localRotation = Quaternion.Euler(aaaa * Vector3.right);
            //aaaa -= _cameraRootTransform.localRotation.eulerAngles.x;
            //_cameraRootTransform.Rotate(aaaa * Vector3.right);
            
            transform.Rotate(rotateHorizontalVelocity * Vector3.up);
        }
        
    }
    
    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log("Collide");
    }

    private void HeadBobing()
    {

    }

    
    #endregion
}
