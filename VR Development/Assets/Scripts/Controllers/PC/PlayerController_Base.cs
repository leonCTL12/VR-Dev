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
    private GameObject player3rdPersonGeometry;
    [SerializeField]
    private GameObject player3rdPersonSkeleton; //It is for boss fight gun display
    [SerializeField]
    private GameObject player1stPersonModel;
    [SerializeField]
    protected Camera fpsCam;
    [SerializeField]
    private GameObject sightUI;
    private ThirdPersonPresenter_Base presenter_base;

    //TODO: hook up with setting
    [SerializeField]
    private bool gamePadMode = false;
    public bool isMine;
    protected InputDevice currentInputDevice;
    protected bool moveable = true;
    protected PhotonView photonView;
    protected AudioSource audioSource;

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

    protected virtual void Awake()
    {
        photonView = GetComponent<PhotonView>();
        audioSource = GetComponent<AudioSource>();
        presenter_base = GetComponent<ThirdPersonPresenter_Base>();
    }
    private void SetGameObjectActiveState()
    {
        Debug.Log("Photon Null: " + photonView == null);
        isMine = photonView.IsMine;
        player3rdPersonGeometry.SetActive(!isMine);
        player3rdPersonSkeleton.SetActive(!isMine);
        
        fpsCam.gameObject.SetActive(isMine);
        player1stPersonModel.SetActive(isMine);
        GetComponent<PlayerInput>().enabled = isMine;
        PCInputDeviceChange(!gamePadMode);

        this.enabled = isMine;
    }

    protected virtual void Start()
    {
        SetGameObjectActiveState();
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

    protected virtual void Update()
    {
        JumpingAndGravityHandler();
        MovementHandler();
        LookHandler();
    }

    private void LookHandler()
    {
        if (!isMine) { return; }  //add to prevent it to improve efficiency
        if (!moveable) 
        { 
            //Debug.Log("return from not movable");
            return; 
        }

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
        if (!isMine) { return; }  //add to prevent it to improve efficiency
        if (!moveable)
        {
            //Debug.Log("return from not movable");
            return;
        }
        Vector3 move = transform.right * walkInput.x + transform.forward * walkInput.y; //create direction to move base on where player is facing
        if (move != Vector3.zero)
        {
            characterController.Move(move * speed * Time.deltaTime);
        }

        //animation
        float currentHorizontalSpeed = new Vector3(characterController.velocity.x, 0.0f, characterController.velocity.z).magnitude;
        presenter_base.Movement(move, currentHorizontalSpeed);
    }

    private void JumpingAndGravityHandler()
    {
        if (!isMine) { return; }  //add to prevent it to improve efficiency
        if (!moveable)
        {
            //Debug.Log("return from not movable");
            return;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        presenter_base.Ground(isGrounded);

        if (isGrounded && velocity.y < 0) //velocity.y < 0 = still falling
        {
            velocity.y = -2f; //work better, coz maybe player is ground but still dropping.
        }
        Debug.Log("Jump: " + jumping + "is grounded: " + isGrounded);
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

    public void Jump(InputAction.CallbackContext context)
    {
        if (!moveable)
        {
            //Debug.Log("return from not movable");
            return;
        }
        if (context.started && isGrounded)
        {
            jumping = true;
        }
        else if (context.canceled)
        {
            jumping = false;
        }
        presenter_base.Jump(jumping);
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!moveable)
        {
            //Debug.Log("return from not movable");
            return;
        }
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
        if (!moveable)
        {
            //Debug.Log("return from not movable");
            return;
        }
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
        if (!moveable)
        {
            //Debug.Log("return from not movable");
            return;
        }
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
