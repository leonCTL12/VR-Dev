// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputMaster_GamePadOnly.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster_GamePadOnly : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster_GamePadOnly()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster_GamePadOnly"",
    ""maps"": [
        {
            ""name"": ""Player_TPGun"",
            ""id"": ""f0473296-25ae-4f6c-8f2f-e9d393c650dd"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""deef3bbb-8692-421a-bc5f-fa1fd90f87a1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Teleport"",
                    ""type"": ""Button"",
                    ""id"": ""9805eeca-65cc-4109-a7a6-329bcfbf9d95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""942898d8-571d-4bcd-b2c0-8236b370d84a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation X"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2dda1765-230a-4d4b-b9f0-ecd382d80985"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation Y"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1158eaae-b5a8-4e0e-a25c-27f37aea9541"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""9aa0ae81-1aa0-4bc9-8b41-5a1a3e43a7bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""03d94e12-8a03-41a7-9944-9a2dc677ee67"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65fbb532-4f4c-4b5a-8dca-25cb722e77e0"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69b9a2a6-2d0b-47d8-9712-fcbce7d4a58c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fad9df36-21a6-4e00-b7fa-c004a85ce634"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Rotation X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e375bee0-45b3-45e5-ad52-2e23fede6c17"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Rotation Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c59f18e3-4714-4674-b32a-521ddfefead7"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24bea1ff-88e8-43df-b4ff-5c26d0ff9085"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Teleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player_Base"",
            ""id"": ""e1133063-adf6-4039-861b-de61a3da3e3b"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""e6a25307-564b-47f0-bd85-966973299e73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation Y"",
                    ""type"": ""PassThrough"",
                    ""id"": ""74ca4239-1faa-455d-ba6b-fd8bbdda8047"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation X"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5eb873e8-a663-4a5b-9434-0e2b7a22f316"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""247a9bcf-817d-42cd-8e23-2c6d9eb2d710"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a91fc698-0951-4f0d-8b07-341efe017c73"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""b0fb48f9-aea3-484c-9e37-440247c37898"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e50c02d2-8b07-48db-a6d8-de667f724832"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03d71ae7-7ae6-4f58-ad95-88f803faec6c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a201942-d419-4670-9384-7f9a086bac70"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Rotation X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4bfd109d-b07d-4296-a4bb-7f2ee3e5b735"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Rotation Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0083ec9e-5c92-458b-aee8-b36ba791def7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player_TPGun
        m_Player_TPGun = asset.FindActionMap("Player_TPGun", throwIfNotFound: true);
        m_Player_TPGun_Movement = m_Player_TPGun.FindAction("Movement", throwIfNotFound: true);
        m_Player_TPGun_Teleport = m_Player_TPGun.FindAction("Teleport", throwIfNotFound: true);
        m_Player_TPGun_Jump = m_Player_TPGun.FindAction("Jump", throwIfNotFound: true);
        m_Player_TPGun_RotationX = m_Player_TPGun.FindAction("Rotation X", throwIfNotFound: true);
        m_Player_TPGun_RotationY = m_Player_TPGun.FindAction("Rotation Y", throwIfNotFound: true);
        m_Player_TPGun_Shoot = m_Player_TPGun.FindAction("Shoot", throwIfNotFound: true);
        // Player_Base
        m_Player_Base = asset.FindActionMap("Player_Base", throwIfNotFound: true);
        m_Player_Base_Interact = m_Player_Base.FindAction("Interact", throwIfNotFound: true);
        m_Player_Base_RotationY = m_Player_Base.FindAction("Rotation Y", throwIfNotFound: true);
        m_Player_Base_RotationX = m_Player_Base.FindAction("Rotation X", throwIfNotFound: true);
        m_Player_Base_Jump = m_Player_Base.FindAction("Jump", throwIfNotFound: true);
        m_Player_Base_Movement = m_Player_Base.FindAction("Movement", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player_TPGun
    private readonly InputActionMap m_Player_TPGun;
    private IPlayer_TPGunActions m_Player_TPGunActionsCallbackInterface;
    private readonly InputAction m_Player_TPGun_Movement;
    private readonly InputAction m_Player_TPGun_Teleport;
    private readonly InputAction m_Player_TPGun_Jump;
    private readonly InputAction m_Player_TPGun_RotationX;
    private readonly InputAction m_Player_TPGun_RotationY;
    private readonly InputAction m_Player_TPGun_Shoot;
    public struct Player_TPGunActions
    {
        private @InputMaster_GamePadOnly m_Wrapper;
        public Player_TPGunActions(@InputMaster_GamePadOnly wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_TPGun_Movement;
        public InputAction @Teleport => m_Wrapper.m_Player_TPGun_Teleport;
        public InputAction @Jump => m_Wrapper.m_Player_TPGun_Jump;
        public InputAction @RotationX => m_Wrapper.m_Player_TPGun_RotationX;
        public InputAction @RotationY => m_Wrapper.m_Player_TPGun_RotationY;
        public InputAction @Shoot => m_Wrapper.m_Player_TPGun_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Player_TPGun; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_TPGunActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_TPGunActions instance)
        {
            if (m_Wrapper.m_Player_TPGunActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnMovement;
                @Teleport.started -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnTeleport;
                @Teleport.performed -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnTeleport;
                @Teleport.canceled -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnTeleport;
                @Jump.started -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnJump;
                @RotationX.started -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnRotationX;
                @RotationX.performed -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnRotationX;
                @RotationX.canceled -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnRotationX;
                @RotationY.started -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnRotationY;
                @RotationY.performed -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnRotationY;
                @RotationY.canceled -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnRotationY;
                @Shoot.started -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_Player_TPGunActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_Player_TPGunActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Teleport.started += instance.OnTeleport;
                @Teleport.performed += instance.OnTeleport;
                @Teleport.canceled += instance.OnTeleport;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @RotationX.started += instance.OnRotationX;
                @RotationX.performed += instance.OnRotationX;
                @RotationX.canceled += instance.OnRotationX;
                @RotationY.started += instance.OnRotationY;
                @RotationY.performed += instance.OnRotationY;
                @RotationY.canceled += instance.OnRotationY;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public Player_TPGunActions @Player_TPGun => new Player_TPGunActions(this);

    // Player_Base
    private readonly InputActionMap m_Player_Base;
    private IPlayer_BaseActions m_Player_BaseActionsCallbackInterface;
    private readonly InputAction m_Player_Base_Interact;
    private readonly InputAction m_Player_Base_RotationY;
    private readonly InputAction m_Player_Base_RotationX;
    private readonly InputAction m_Player_Base_Jump;
    private readonly InputAction m_Player_Base_Movement;
    public struct Player_BaseActions
    {
        private @InputMaster_GamePadOnly m_Wrapper;
        public Player_BaseActions(@InputMaster_GamePadOnly wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Player_Base_Interact;
        public InputAction @RotationY => m_Wrapper.m_Player_Base_RotationY;
        public InputAction @RotationX => m_Wrapper.m_Player_Base_RotationX;
        public InputAction @Jump => m_Wrapper.m_Player_Base_Jump;
        public InputAction @Movement => m_Wrapper.m_Player_Base_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Player_Base; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_BaseActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_BaseActions instance)
        {
            if (m_Wrapper.m_Player_BaseActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnInteract;
                @RotationY.started -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnRotationY;
                @RotationY.performed -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnRotationY;
                @RotationY.canceled -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnRotationY;
                @RotationX.started -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnRotationX;
                @RotationX.performed -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnRotationX;
                @RotationX.canceled -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnRotationX;
                @Jump.started -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player_BaseActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_Player_BaseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @RotationY.started += instance.OnRotationY;
                @RotationY.performed += instance.OnRotationY;
                @RotationY.canceled += instance.OnRotationY;
                @RotationX.started += instance.OnRotationX;
                @RotationX.performed += instance.OnRotationX;
                @RotationX.canceled += instance.OnRotationX;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public Player_BaseActions @Player_Base => new Player_BaseActions(this);
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    public interface IPlayer_TPGunActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnTeleport(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRotationX(InputAction.CallbackContext context);
        void OnRotationY(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IPlayer_BaseActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnRotationY(InputAction.CallbackContext context);
        void OnRotationX(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
}
