using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class GrabbingBehaviour : MonoBehaviour
{
    #region Variables

    [Header("Grabbling relative")]
    [Tooltip("The point where you grabbed object will position")]
    [SerializeField] private Transform _grabPoint;
    [SerializeField] private float _grabbingDistance = 2.0f;
    [SerializeField] private LayerMask _grabbableMask;
    private Rigidbody _grabbedTarget;
    
    [Header("Drop Force")]
    [Tooltip("Force that you put on the grabbed object when you drop it")]
    [SerializeField] private float _dropForce = 5.0f;

    // Grabbed Target velocity relative
    private float _minimumVelocity = 0.0f;
    private float _velocityOffset = 0.1f;

    [Header("Links")]
    [SerializeField] private Transform _camera;
    [SerializeField] private GameObject _grabUI;
    #endregion


    #region Updates
    private void Start()
    {
        _grabUI.SetActive(false);
    }

    private void Update()
    {
        if (_grabbedTarget == null)
        {
            if (Physics.Raycast(_camera.position, _camera.forward, out RaycastHit hit, _grabbingDistance, _grabbableMask))
            {
                EnableGrabUI(true);
                if (InputManager.instance.isUsing)
                {
                    Grab(hit);
                }
            }
            else
            {
                EnableGrabUI(false);
            }
        }
        else
        {
            if (InputManager.instance.isUsing)
            {
                Drop();
            }
        }
        InputManager.instance.isUsing = false;       
    }

    private void FixedUpdate()
    {
        if (_grabbedTarget != null)
        {
            MoveGrabbedTarget();
        }  
    }
    #endregion


    #region Methods
    private void Grab(RaycastHit hit)
    {
        _grabbedTarget = hit.transform.GetComponent<Rigidbody>();

        _grabbedTarget.useGravity = false;
        _grabbedTarget.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _grabbedTarget.interpolation = RigidbodyInterpolation.Extrapolate;
    }

    private void Drop()
    {
        _grabbedTarget.useGravity = true;
        _grabbedTarget.collisionDetectionMode = CollisionDetectionMode.Discrete;
        _grabbedTarget.interpolation = RigidbodyInterpolation.None;
        _grabbedTarget.AddForce(_camera.forward * _dropForce, ForceMode.Impulse);

        _grabbedTarget = null;
    }

    private void MoveGrabbedTarget()
    {
        Vector3 targetPosition = Vector3.Lerp(_grabbedTarget.position, _grabPoint.position, Time.fixedDeltaTime * 10);
        
        Vector3 targetVelocity = _grabbedTarget.velocity;
        Vector3 targetAngularVelocity = _grabbedTarget.angularVelocity;
        LerpResetVelocity(ref targetVelocity);
        LerpResetVelocity(ref targetAngularVelocity);
        
        _grabbedTarget.velocity = targetVelocity;
        _grabbedTarget.angularVelocity = targetAngularVelocity;

        _grabbedTarget.MovePosition(targetPosition);
    }

    private void LerpResetVelocity(ref Vector3 velocity)
    {
        if (velocity.magnitude < _minimumVelocity - 0.1f || velocity.magnitude > _minimumVelocity + _velocityOffset)
        {
            velocity = Vector3.Lerp(_grabbedTarget.velocity, Vector3.zero, Time.deltaTime * 10.0f);
        }
        else
        {
            velocity = Vector3.zero;
        }
    }

    private void EnableGrabUI(bool state)
    {
        _grabUI.SetActive(state);
    }


    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("test");
    }

    #endregion
}
