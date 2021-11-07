using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController: MonoBehaviour
{
    //General
    [SerializeField]
    private CharacterController characterController;
    private InputDevice currentInputDevice;

    //Walk
    [SerializeField]
    private float speed;
    private Vector2 walkInput;

    //Jump and Gravity
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

    //Look
    [SerializeField]
    private float defaultSensitivity;
    [SerializeField]
    private float mouseSensitivity;
    [SerializeField]
    private float gamepadSensitivity;
    [SerializeField]
    private Transform cameraTransform;
    private float xRotation = 0f;
    private float rotationInputX = 0f;
    private float rotationInputY = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        JumpingAndGravityHandler();

        MovementHandler();

        LookHandler();
    }

    private void LookHandler()
    {
        float sensitivity = defaultSensitivity;
        if(currentInputDevice is Mouse)
        {
            sensitivity = mouseSensitivity;
        }
        else if (currentInputDevice is Gamepad)
        {
            sensitivity = gamepadSensitivity;
        }
        float tunedInputX = rotationInputX * sensitivity * Time.deltaTime;
        float tunedInputY = rotationInputY * sensitivity * Time.deltaTime;

        xRotation -= tunedInputY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * tunedInputX);
    }

    private void MovementHandler()
    {
        Vector3 move = transform.right * walkInput.x + transform.forward * walkInput.y; //create direction to move base on where player is facing
        characterController.Move(move * speed * Time.deltaTime);
    }

    private void JumpingAndGravityHandler ()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) //velocity.y < 0 = still falling
        {
            velocity.y = -2f; //work better, coz maybe player is ground but still dropping.
        }

        if (jumping && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumping = false;
        }

        //Gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime); //multiply Time.deltaTime once more because d = 1/2*g*t^2
    }

    public void Shoot(InputAction.CallbackContext context)
    {
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

    public void LookRotationX(InputAction.CallbackContext context)
    {
        currentInputDevice = context.control.device;
        if (context.performed)
        {
            rotationInputX = context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            rotationInputX = 0f;
        }
    }

    public void LookRotationY(InputAction.CallbackContext context)
    {
        currentInputDevice = context.control.device;
        if (context.performed)
        {
            rotationInputY = context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            rotationInputY = 0f;
        }
    }
}
