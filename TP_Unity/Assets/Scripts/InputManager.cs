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
    }

    #endregion
}
