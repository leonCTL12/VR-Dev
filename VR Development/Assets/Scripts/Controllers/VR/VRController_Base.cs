using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRController_Base : MonoBehaviour
{
    [SerializeField]
    private InputActionReference jumpActionReference;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundDistance;
    [SerializeField]
    private LayerMask groundMask;
    [SerializeField]
    public float jumpHeight;
    private bool isGrounded;
    private Vector3 velocity;
    private bool jumping = false;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        jumpActionReference.action.started += OnJump;
    }

    private void Update()
    {
        //if (!isMine) { return; }  //add to prevent it to improve efficiency
        //if (!moveable)
        //{
        //    Debug.Log("return from not movable");
        //    return;
        //}
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //playerAnimator.SetBool("Grounded", isGrounded);

        if (isGrounded && velocity.y < 0) //velocity.y < 0 = still falling
        {
            velocity.y = -2f; //work better, coz maybe player is ground but still dropping.
        }
        Debug.Log("Jump: " + jumping + "; is grounded: " + isGrounded);
        if (jumping && isGrounded)
        {
            Debug.Log("in the mid air");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumping = false;
        }

        //Gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime); //multiply Time.deltaTime once more because d = 1/2*g*t^2
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("In OnJump");
        if (context.started && isGrounded)
        {
            Debug.Log("Successfully set jump to true");
            jumping = true;
        }
        else if (context.canceled)
        {
            jumping = false;
        }
    }


}
