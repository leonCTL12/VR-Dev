using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCPlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private float speed;

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

    private Vector3 velocity;
    private bool isGrounded;
    private Vector2 walkInput;
    private bool jumping = false;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) //velocity.y < 0 = still falling
        {
            velocity.y = -2f; //work better, coz maybe player is ground but still dropping.
        }

        Vector3 move = transform.right * walkInput.x + transform.forward * walkInput.y; //create direction to move base on where player is facing

        controller.Move(move * speed * Time.deltaTime);

        if (jumping && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); //multiply Time.deltaTime once more because d = 1/2*g*t^2
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.started)
            Debug.Log("Action was started");
        else if (context.performed)
        {
            Debug.Log("Action was performed");
        }
        else if (context.canceled)
            Debug.Log("Action was cancelled");
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Debug.Log("Jump started");
            jumping = true;
        }
        else if (context.canceled)
        {
            Debug.Log("Jump ended");
            jumping = false;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Move");

            walkInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            walkInput = Vector2.zero;
        }
    }
}
