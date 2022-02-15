using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

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

    #region WalkInput
    private ThirdPersonPresenter_Base presenter_base;
    private Vector2 walkInput;
    [SerializeField]
    private InputActionReference walkActionReference;
    #endregion

    #region Multiplayer
    private PhotonView photonView;
    private bool isMine;
    [SerializeField]
    private GameObject player3rdPersonGeometry;
    [SerializeField]
    private GameObject player3rdPersonSkeleton; //It is for boss fight gun display
    [SerializeField]
    private Camera VRCamera;
    [SerializeField]
    private GameObject player1stPersonModel;
    #endregion

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        presenter_base = GetComponent<ThirdPersonPresenter_Base>();
        photonView = GetComponent<PhotonView>();
        jumpActionReference.action.started += OnJump;
        jumpActionReference.action.canceled += OnJump;
        walkActionReference.action.performed += Move;
        walkActionReference.action.canceled += Move;
    }

    private void SetGameObjectActiveState()
    {
        Debug.Log("Photon Null: " + photonView == null);
        isMine = photonView.IsMine;
        player3rdPersonGeometry.SetActive(!isMine);
        //TODO: come back at boss level
        //player3rdPersonSkeleton.SetActive(!isMine);

        VRCamera.gameObject.SetActive(isMine);
        player1stPersonModel.SetActive(isMine);

        this.enabled = isMine;
    }

    private void Start()
    {
        SetGameObjectActiveState();
    }

    private void Update()
    {
        MovementAniamtionHandler();
        JumpingAndGravityHandler();
    }

    private void JumpingAndGravityHandler()
    {
        //if (!isMine) { return; }  //add to prevent it to improve efficiency
        //if (!moveable)
        //{
        //    Debug.Log("return from not movable");
        //    return;
        //}
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        presenter_base.Ground(isGrounded);

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

    private void MovementAniamtionHandler()
    {
        Vector3 move = transform.right * walkInput.x + transform.forward * walkInput.y; //create direction to move base on where player is facing

        //animation
        float currentHorizontalSpeed = new Vector3(move.x, 0.0f, move.z).magnitude;
        presenter_base.Movement(move, currentHorizontalSpeed);
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
        presenter_base.Jump(jumping);
    }

    public void Move(InputAction.CallbackContext context)
    {
        //TODO: investigate how to deal with movable
        //if (!moveable)
        //{
        //    //Debug.Log("return from not movable");
        //    return;
        //}
        if (context.performed)
        {
            walkInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            walkInput = Vector2.zero;
        }
    }

}
