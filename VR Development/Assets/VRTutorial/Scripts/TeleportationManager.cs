using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset actionAsset;
    [SerializeField]
    private XRRayInteractor rayInteractor;
    [SerializeField]
    private TeleportationProvider provider;

    private InputAction _thumbstick;
    private bool _isActive;

    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false; //disable the ray before the player push the stick

        var activate = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;

        var cancel = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += OnTeleportationCancel;

        _thumbstick = actionAsset.FindActionMap("XRI LeftHand").FindAction("Move");
        _thumbstick.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isActive)
            return;

        if (_thumbstick.triggered) //the stick is still pushing forward, that means the player do not want to teleport yet.
            return;

        if(!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit)) //the ray is hitting something non existed
        {
            rayInteractor.enabled = false;
            _isActive = false;
            return;
        }

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point,
            //destinationRotation = ,
            //matchOrientation = ,
            //requestTime = ,
        };

        provider.QueueTeleportRequest(request);
        rayInteractor.enabled = false;
        _isActive = false;
    }

    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;
        _isActive = true;
    }

    private void OnTeleportationCancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;
        _isActive = false;
    }
}
