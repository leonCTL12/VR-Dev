using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_Shooter : PlayerController_Base
{
    [SerializeField]
    private Gun_Base wand;
    [SerializeField]
    private Gun_Base weakSpotGun;
    [SerializeField]
    private WeaponType weaponType;

    private enum WeaponType
    {
        wand, gun
    }
    private Gun_Base weapon;


    private void Awake()
    {
        switch (weaponType)
        {
            case WeaponType.wand:
                weapon = wand;
                break;
            case WeaponType.gun:
                weapon = weakSpotGun;
                break;
            default:
                weapon = wand;
                break;
        }

        weakSpotGun.gameObject.SetActive(weapon == weakSpotGun);
        wand.gameObject.SetActive(weapon == wand);
    }


    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            weapon.Fire();
        } 
        else if (context.canceled)
        {
            weapon.CancelFire();
        }
    }
}
