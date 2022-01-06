using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_Puzzle : PlayerController_Base
{
    private GameObject currentTriggerCollisionGO;

    public void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("In Interact");
        if (context.performed)
        {
            //Find the exact hit position using a raycast
            if (currentInputDevice is Mouse)
            {
                Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;


                if (Physics.Raycast(ray, out hit))
                {
                    InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
                    if (interactableObject != null)
                    {
                        interactableObject.VoidInteract();
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
                if (currentTriggerCollisionGO == null)
                {
                    return;
                }

                RangeChecker checker = currentTriggerCollisionGO.GetComponent<RangeChecker>();
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
    }
    public void Interact_R(InputAction.CallbackContext context)
    {
        Debug.Log("In Player Interact R");
    }

    public void Interact_L(InputAction.CallbackContext context)
    {
        Debug.Log("In Player Interact L");
    }

}
