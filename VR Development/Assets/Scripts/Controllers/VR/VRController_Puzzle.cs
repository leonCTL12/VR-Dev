using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRController_Puzzle : VRController_Base
{
    [SerializeField]
    private InputActionReference triggerLeft, triggerRight;
    [SerializeField]
    private InputActionReference gripLeft, gripRight;

    public GameObject leftHandContactObject = null;
    public GameObject rightHandContactObject = null;

    private bool leftTriggerPressed, rightTriggerPressed;
    private bool leftGripPressed, rightGripPressed;

    protected override void Awake()
    {
        base.Awake();

        triggerLeft.action.performed += LeftTriggerOnPress;
        triggerLeft.action.canceled += LeftTriggerOnRelease;

        triggerRight.action.performed += RightTriggerOnPress;
        triggerRight.action.canceled += RightTriggerOnRelease;

        gripLeft.action.performed += LeftGripOnPress;
        gripLeft.action.canceled += LeftGripOnRelease;

        gripRight.action.performed += RightGripOnPress;
        gripRight.action.canceled += RightGripOnRelease;
    }

    private void LeftTriggerOnPress(InputAction.CallbackContext context)
    {
        leftTriggerPressed = true;
        FireEventCheck(false);
    }
    
    private void RightTriggerOnPress(InputAction.CallbackContext context)
    {
        rightTriggerPressed = true;
        FireEventCheck(true);
    }
    
    private void LeftGripOnPress(InputAction.CallbackContext context)
    {
        leftGripPressed = true;
        FireEventCheck(false);
    }

    private void RightGripOnPress(InputAction.CallbackContext context)
    {
        rightGripPressed = true;
        FireEventCheck(true);
    }

    private void FireEventCheck (bool rightHand)
    {
        GameObject contactObject = rightHand ? rightHandContactObject : leftHandContactObject;
        if (contactObject == null) return;

        bool andGate = rightHand ? (rightTriggerPressed && rightGripPressed) : (leftTriggerPressed && leftGripPressed);
        if (andGate) //left hand can interact with right gap
        {
            GapVRSpecific gap = contactObject.GetComponent<GapVRSpecific>();
            if (gap != null)
            {
                gap.Interact();
            }
        }
    }

    private void CancelEvent(bool rightHand)
    {
        GameObject contactObject = rightHand ? rightHandContactObject : leftHandContactObject;
        if (contactObject == null) return;
        
        GapVRSpecific gap = contactObject.GetComponent<GapVRSpecific>();
        if (gap != null)
        {
            gap.Cancel();
        }
    }

    private void LeftTriggerOnRelease(InputAction.CallbackContext context)
    {
        leftTriggerPressed = false;
        CancelEvent(false);
    }

    private void RightTriggerOnRelease(InputAction.CallbackContext context)
    {
        rightTriggerPressed = false;
        CancelEvent(true);
    }

    private void LeftGripOnRelease(InputAction.CallbackContext context)
    {
        leftGripPressed = false;
        CancelEvent(false);
    }

    private void RightGripOnRelease(InputAction.CallbackContext context)
    {
        rightGripPressed = false;
        CancelEvent(true);
    }
}
