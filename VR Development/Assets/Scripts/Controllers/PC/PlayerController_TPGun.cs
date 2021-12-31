using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_TPGun : PlayerController_Base
{
    [SerializeField]
    private TeleportGun gun;

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Shoot");
            gun.Fire();
        }
    }

    public void Teleport()
    {
        if (gun.currentTeleportToken == null) { return; }

        characterController.enabled = false;
        transform.position = gun.currentTeleportToken.transform.position;
        characterController.enabled = true;

        Destroy(gun.currentTeleportToken);

    }
}
