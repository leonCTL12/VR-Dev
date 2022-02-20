using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;

public class VRController_Shooter : VRController_Base
{
    [SerializeField]
    private Gun_Base wand;
    [SerializeField]
    private Gun_Base weakSpotGun;
    private WeaponType weaponType;
    [SerializeField]
    private ThirdPersonPresenter_Shooter presenter;
    [SerializeField]
    private GameObject canvas;

    #region VR Specific
    [SerializeField]
    private GameObject handWithGun, handWithWand;
    [SerializeField]
    private InputActionReference rightTrigger;
    [SerializeField]
    private GameObject locomotionSystem;
    [SerializeField]
    private GameObject leftController, rightController;
    #endregion

    #region Testing Param
    [SerializeField]
    private bool weaponTesting;
    [SerializeField]
    private WeaponType testingForceUseWeapon;
    #endregion


    private enum WeaponType
    {
        wand, gun
    }
    private Gun_Base weapon;

    protected override void Start()
    {
        base.Start();

        canvas.SetActive(isMine);

        if (PhotonNetwork.IsMasterClient)
        {
            weaponType = isMine ? WeaponType.gun : WeaponType.wand;
        }
        else
        {
            weaponType = isMine ? WeaponType.wand : WeaponType.gun;
        }

        //Testing Purpose, remove later
        if(weaponTesting)
        {
            weaponType = testingForceUseWeapon;
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

        handWithGun.gameObject.SetActive(weapon == weakSpotGun);
        handWithWand.gameObject.SetActive(weapon == wand);
        presenter.ShowCorrectWeapon(weapon == weakSpotGun);

        rightTrigger.action.performed += Shoot;
        rightTrigger.action.canceled += Shoot;
    }


    public void Shoot(InputAction.CallbackContext context)
    {
        if(!movable) { return; }
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

    public void ToggleMotion(bool active)
    {
        locomotionSystem.SetActive(active);
        leftController.SetActive(active);
        rightController.SetActive(active);
        movable = active;
    }
}
