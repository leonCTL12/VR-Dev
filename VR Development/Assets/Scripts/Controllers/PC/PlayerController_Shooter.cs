using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerController_Shooter : PlayerController_Base
{
    [SerializeField]
    private Gun_Base wand;
    [SerializeField]
    private Gun_Base weakSpotGun;
    private WeaponType weaponType;
    [SerializeField]
    private ThirdPersonPresenter_Shooter presenter;

    private enum WeaponType
    {
        wand, gun
    }
    private Gun_Base weapon;
    protected override void Start()
    {
        base.Start();
        if (PhotonNetwork.IsMasterClient)
        {
            weaponType = isMine ? WeaponType.gun: WeaponType.wand;
        } 
        else
        {
            weaponType = isMine ? WeaponType.wand : WeaponType.gun;
        }

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
        presenter.ShowCorrectWeapon(weapon == weakSpotGun);
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

    public void ShowWandBeam(Vector3? targetPoint)
    {
        presenter.ShowBeam(targetPoint);
    }
}
