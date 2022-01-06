using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_Puzzle : PlayerController_Base
{
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject rightHand;

    private GameObject currentTriggerCollisionGO;

    private InteractableObject currentInteractableObject;
    public void Interact(InputAction.CallbackContext context)
    {
        if (currentTriggerCollisionGO == null) { return; } //it does not collide with anything
        RangeChecker checker = currentTriggerCollisionGO.GetComponent<RangeChecker>();

        if (context.performed)
        {
            //Find the exact hit position using a raycast
            if (currentInputDevice is Mouse)
            {
                Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    currentInteractableObject = hit.collider.GetComponent<InteractableObject>();
                    if (currentInteractableObject != null && checker != null)
                    {
                        currentInteractableObject.VoidInteract();
                    }
                    else
                    {
                        Debug.Log("No interactables. What it hit is: " + hit.collider.gameObject.name);
                    }
                }
            }
            if (currentInputDevice is Gamepad)
            {
                Debug.Log("GamePad interact");

                if (checker != null)
                {
                    checker.interactable.VoidInteract();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        currentTriggerCollisionGO = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        currentTriggerCollisionGO = null;
        CancelAction();
    }
    public void Interact_R(InputAction.CallbackContext context)
    {
        if (currentTriggerCollisionGO == null) { return;} //it does not collide with anything
        RangeChecker checker = currentTriggerCollisionGO.GetComponent<RangeChecker>();

        if (context.performed)
        {
            //Find the exact hit position using a raycast
            if (currentInputDevice is Mouse)
            {
                Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    currentInteractableObject = hit.collider.GetComponent<InteractableObject>();
                    if (currentInteractableObject != null && checker != null)
                    {
                        rightHand.SetActive(false);
                        currentInteractableObject.Interact_R();
                    }
                    else
                    {
                        Debug.Log("No interactables. What it hit is: " + hit.collider.gameObject.name);
                    }
                }
            }

            if (currentInputDevice is Gamepad)
            {
                Debug.Log("GamePad interact");

                if (checker != null)
                {
                    checker.interactable.Interact_R();
                }
            }
        } else if (context.canceled)
        {
            if (currentTriggerCollisionGO != null && currentInteractableObject != null)
            {
                currentInteractableObject.Cancel_R();
                rightHand.SetActive(true);
            }
        }
    }

    private void CancelAction()
    {
        currentInteractableObject.Cancel_R();
        currentInteractableObject.Cancel_L();
        currentInteractableObject = null;

        leftHand.SetActive(true);
        rightHand.SetActive(true);
    }

    public void Interact_L(InputAction.CallbackContext context) //I have to separate L and R interact into two functions even if they are similar, because input system cannot take parameters to distinguish left and right 
    {
        if (currentTriggerCollisionGO == null) { return; } //it does not collide with anything
        RangeChecker checker = currentTriggerCollisionGO.GetComponent<RangeChecker>();

        if (context.performed)
        {
            //Find the exact hit position using a raycast
            if (currentInputDevice is Mouse)
            {
                Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    currentInteractableObject = hit.collider.GetComponent<InteractableObject>();
                    if (currentInteractableObject != null && checker != null)
                    {
                        leftHand.SetActive(false);
                        currentInteractableObject.Interact_L();
                    }
                    else
                    {
                        Debug.Log("No interactables. What it hit is: " + hit.collider.gameObject.name);
                    }
                }
            }

            if (currentInputDevice is Gamepad)
            {
                Debug.Log("GamePad interact");

                if (checker != null)
                {
                    checker.interactable.Interact_L();
                }
            }
        }
        else if (context.canceled)
        {
            if (currentTriggerCollisionGO != null && currentInteractableObject != null)
            {
                currentInteractableObject.Cancel_L();
                leftHand.SetActive(true);
            }
        }
    }

}
