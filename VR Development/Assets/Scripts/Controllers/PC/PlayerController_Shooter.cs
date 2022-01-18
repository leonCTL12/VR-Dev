using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_Shooter : PlayerController_Base
{
    [SerializeField]
    private Gun_Base gun;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            gun.Fire();
        } else if (context.canceled)
        {
            gun.CancelFire();
        }
    }
}
