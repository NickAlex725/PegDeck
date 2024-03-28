using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class InputBroadcaster : MonoBehaviour
{
    private PlayerInput _input;

    private InputAction _touch;

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
        //get tap position
        Vector3 pos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        pos.z = 0;
        //raycast and check if a card was tapped
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if(hit.collider != null)
        {
            CardParent card = hit.collider.GetComponent<CardParent>();
            if (card != null)
            {
                //card was hit
                card.CardAction();
            }
        }
    }
}
