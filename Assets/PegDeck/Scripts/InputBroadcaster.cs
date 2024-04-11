using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class InputBroadcaster : MonoBehaviour
{
    private PlayerInput _input;
    private Camera _mainCamera;

    private InputAction _touch;
    private InputAction _touchPress;

    public Vector2 touchPosition;

    public Action<Vector2> OnTouchPosition = delegate { };
    public Action<bool> OnTouchPress = delegate { };

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _mainCamera = Camera.main;
        _touch = _input.actions["Touch"];
        _touchPress = _input.actions["TouchPress"];
    }

    private void OnEnable()
    {
        _touch.performed += Touch;
        _touchPress.started += TouchPress;
        _touchPress.canceled += TouchPress;
    }

    private void OnDisable()
    {
        _touch.performed -= Touch;
        _touchPress.started -= TouchPress;
        _touchPress.canceled -= TouchPress;
    }

    private void Touch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            touchPosition = context.ReadValue<Vector2>();
            OnTouchPosition?.Invoke(context.ReadValue<Vector2>());
        }

        //Debug.Log("Touch()");
    }
    private void TouchPress(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnTouchPress?.Invoke(true);
        }
        if (context.canceled)
        {
            OnTouchPress?.Invoke(false);
        }

        //Debug.Log("TouchPress()");
    }
}
