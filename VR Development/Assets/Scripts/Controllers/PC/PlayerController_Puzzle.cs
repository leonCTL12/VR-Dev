using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerController_Puzzle : PlayerController_Base
{
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject rightHand;
  

    private GameObject currentTriggerCollisionGO;
    private bool leftHandReleased;
    private bool rightHandReleased;

    private InteractableObject currentInteractableObject;

    private Player_Puzzle player_puzzle;

    protected override void Awake()
    {
        base.Awake();
        player_puzzle = GetComponent<Player_Puzzle>();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (currentTriggerCollisionGO == null || !player_puzzle.interactable) { return; } //it does not collide with anything
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
    }
    public void Interact_R(InputAction.CallbackContext context)
    {
        if (currentTriggerCollisionGO == null || !player_puzzle.interactable) { return;} //it does not collide with anything
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
                        rightHandReleased = false;
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
                    rightHand.SetActive(false);
                    currentInteractableObject = checker.interactable;
                    currentInteractableObject.Interact_R();
                    rightHandReleased = false;
                }
            }
        } else if (context.canceled)
        {
            Debug.Log("cancel input");
            if (currentTriggerCollisionGO != null && currentInteractableObject != null && player_puzzle.interactable)
            {
                currentInteractableObject.Cancel_R();
                rightHand.SetActive(true);
                rightHandReleased = true;
            }
        }
        moveable = rightHandReleased && leftHandReleased;
    }

    //To be removed: coz now when player grip something, they cant move
    private void CancelAction(InteractableObject interactableObj)
    {
        interactableObj.Cancel_R();
        interactableObj.Cancel_L();

        leftHand.SetActive(true);
        rightHand.SetActive(true);
        leftHandReleased = true;
        rightHandReleased = true;
        player_puzzle.interactable = true;
        moveable = true;
    }

    public void Interact_L(InputAction.CallbackContext context) //I have to separate L and R interact into two functions even if they are similar, because input system cannot take parameters to distinguish left and right 
    {
        if (currentTriggerCollisionGO == null || !player_puzzle.interactable) { return; } //it does not collide with anything
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
                        Debug.Log("Mouse Perform");
                        leftHand.SetActive(false);
                        currentInteractableObject.Interact_L();
                        leftHandReleased = false;
                    }
                    else
                    {
                        //Debug.Log("No interactables. What it hit is: " + hit.collider.gameObject.name);
                    }
                }
            }

            if (currentInputDevice is Gamepad)
            {
                if (checker != null)
                {
                    leftHand.SetActive(false);
                    currentInteractableObject = checker.interactable;
                    currentInteractableObject.Interact_L();
                    leftHandReleased = false;
                }
            }
        }
        else if (context.canceled)
        {
            if (currentTriggerCollisionGO != null && currentInteractableObject != null && player_puzzle.interactable)
            {
                currentInteractableObject.Cancel_L();
                leftHand.SetActive(true);
                leftHandReleased = true;
                moveable = leftHandReleased && rightHandReleased;
            }
        }
        moveable = rightHandReleased && leftHandReleased;
    }

   


    

}
