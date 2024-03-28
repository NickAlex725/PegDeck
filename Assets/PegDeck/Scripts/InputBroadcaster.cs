using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class InputBroadcaster : MonoBehaviour
{
    private PlayerInput _input;

    private InputAction _touch;

    public Action<Vector2> OnTouch = delegate { };

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _touch = _input.actions["Touch"];
    }

    private void OnEnable()
    {
        _touch.performed += TouchPress;
    }

    private void OnDisable()
    {
        _touch.performed -= TouchPress;
    }

    private void TouchPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnTouch?.Invoke(context.ReadValue<Vector2>());
        }

        Debug.Log("TouchPress()");
    }
}
