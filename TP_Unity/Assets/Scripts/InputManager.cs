using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Variables
    public static InputManager instance; // Singleton

    public Vector2 move;
    public Vector2 look;
    public bool isRunning;
    public bool isJumping;
    public bool isUsing;

    #endregion

    
    #region Updates
    public void Awake()
    {
        instance = this;
    }
    #endregion


    #region Methods

    public void OnMove(InputValue inputValue)
    {
        move = inputValue.Get<Vector2>();
    }
    
    public void OnLook(InputValue inputValue)
    {
        look = inputValue.Get<Vector2>();
        look.y *= -1;
    }

    public void OnRun(InputValue inputValue)
    {
        isRunning = inputValue.isPressed;
    }

    public void OnJump(InputValue inputValue)
    {
        isJumping = inputValue.isPressed;
    }

    public void OnUsing()
    {
        isUsing = true;
    }

    #endregion
}
