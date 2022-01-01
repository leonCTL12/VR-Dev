using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;


public class PlayerController_Base: MonoBehaviour
{
    //General
    [SerializeField]
    protected CharacterController characterController;
    [SerializeField]
    private Animator playerAnimator;
    private InputDevice currentInputDevice;
    [SerializeField]
    private bool showPlayerModel;
    [SerializeField]
    private GameObject playerModel;
    [SerializeField]
    private Camera fpsCam;
    [SerializeField]
    private GameObject sightUI;
    //TODO: hook up with setting
    [SerializeField]
    private bool gamePadMode = false;
    private GameObject currentTriggerCollisionGO;
    private bool isMine;

    //Walk
    [SerializeField]
    private float speed;
    private Vector2 walkInput;

    //Walk Animator
    [SerializeField]
    private float animator_moveSpeed;
    [SerializeField]
    private float animator_speedChangeRate;
    private float animator_speed;
    private float _animationBlend;


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

    private void PlayerControlSetting()
    {
        isMine = GetComponent<PhotonView>().IsMine;
        playerModel.SetActive(!isMine);
        fpsCam.gameObject.SetActive(isMine);
    }

    private void Start()
    {
        PlayerControlSetting();

        PCInputDeviceChange(!gamePadMode);
        InputSystem.onDeviceChange += (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    if (device is Gamepad)
                    {
                        gamePadMode = true;
                        PCInputDeviceChange(!gamePadMode);
                    }
                    break;
                case InputDeviceChange.Removed:
                    if (device is Gamepad)
                    {
                        Debug.Log("A Gamepad is removed");
                        gamePadMode = false;
                        PCInputDeviceChange(!gamePadMode);
                    }
                    break;
            }

        };
    }

    private void PCInputDeviceChange(bool keyboardUI)
    {
        sightUI.SetActive(keyboardUI);
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
        if (move != Vector3.zero)
        {
            characterController.Move(move * speed * Time.deltaTime);
        }

        //animation
        float targetSpeed = animator_moveSpeed;

        if (move == Vector3.zero)
        {
            targetSpeed = 0f;
        }

        // a reference to the players current horizontal velocity
        float currentHorizontalSpeed = new Vector3(characterController.velocity.x, 0.0f, characterController.velocity.z).magnitude;
        float speedOffset = 0.1f;
        float inputMagnitude = 1f;

        if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            // creates curved result rather than a linear one giving a more organic speed change
            // note T in Lerp is clamped, so we don't need to clamp our speed
            animator_speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * animator_speedChangeRate);

            // round speed to 3 decimal places
            animator_speed = Mathf.Round(animator_speed * 1000f) / 1000f;
        }
        else
        {
            animator_speed = targetSpeed;
        }
        _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * animator_speedChangeRate);
        playerAnimator.SetFloat("Speed", _animationBlend);
        playerAnimator.SetFloat("MotionSpeed", inputMagnitude);
    }

    private void JumpingAndGravityHandler ()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        playerAnimator.SetBool("Grounded", isGrounded);

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

    public void Jump(InputAction.CallbackContext context)
    {
        playerAnimator.SetBool("Jump", jumping);
        if (context.started)
        {
            jumping = true;
        }
        else if (context.canceled)
        {
            jumping = false;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
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

    public void Interact(InputAction.CallbackContext context)
    {
        
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
                }
            }
             
            if (currentInputDevice is Gamepad)
            {
                Debug.Log("GamePad interact");
                if (currentTriggerCollisionGO == null) {
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

    public void DeathHandler(Transform spawnPoint)
    {
        characterController.enabled = false;
        transform.position = spawnPoint.position;
        characterController.enabled = true;
    }
}
