// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
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
                    ""name"": ""up"",
                    ""id"": ""89056697-eed9-4a9d-84d6-caa912f1aeef"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3b1159be-a57d-4711-ac0e-4a5170b12f0e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""676ee9a4-df85-46ff-8852-0ec071affb1e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5a180fa5-563c-42ee-95c8-92ec4c36969a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                    ""id"": ""5a9ed48b-0936-47e8-8b39-f784ebf9c90c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Jump"",
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
                    ""id"": ""612a1c8c-46a9-4d0b-9408-57d9427255d8"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Rotation X"",
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
                    ""id"": ""5b47e198-d640-4511-9c37-195e020825d5"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Rotation Y"",
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
                    ""id"": ""4de946c5-a958-4980-a1bf-817101174b07"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Shoot"",
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
                    ""id"": ""3038c53e-b766-4b92-be10-6b6df9d114fe"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Teleport"",
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
            ""name"": ""Player_Interact"",
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
                    ""name"": ""up"",
                    ""id"": ""8899c6e1-6fad-48bf-8ceb-85382570b58d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cbf1b5c8-4c9c-417c-b3cf-76c698bbcf32"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3880f41e-878e-4150-9c29-4cb9e9f64029"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""47af3e98-950b-48fa-953a-aa0e05cfa49d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                    ""id"": ""2b6b1a9b-937e-4a71-9f05-7ab9c9e5ef59"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Jump"",
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
                    ""id"": ""ff43b461-b9c1-490a-8442-71f3595125b8"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Rotation X"",
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
                    ""id"": ""6933a001-7a18-4ce2-b72f-fa2b4ee5160e"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Rotation Y"",
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
                    ""id"": ""43cca848-a163-4422-a681-306e06a24e8a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Interact"",
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
        },
        {
            ""name"": ""Player_SeperateHandInteract"",
            ""id"": ""9d8b3892-7bb0-4bad-8697-3fa6c4c7a2cf"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a8183042-c192-471f-b94d-b37a963d78f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation X"",
                    ""type"": ""PassThrough"",
                    ""id"": ""10dd3fee-7011-414b-ba83-46289fb42e9b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation Y"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3e0d6c7d-7e9a-4754-8fe2-ab7dff43fe26"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact_L"",
                    ""type"": ""Button"",
                    ""id"": ""34bc6658-9f26-4167-b4c1-1ca831923584"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact_R"",
                    ""type"": ""Button"",
                    ""id"": ""084c157b-8b72-48de-914c-d19f5e7e4fd7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""85d91582-eaf3-47af-a947-5012f37bebb6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0a304e4a-2049-4112-bb36-2d6210efff3c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9ee809ef-544f-4779-8211-5375a0fd6658"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fc593358-a194-4c3a-8f54-430e40c35281"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""09120294-b5c3-423a-9586-04fb3623eb14"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b30dec67-7681-4b7d-b738-fae0cfc42e53"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""18c51f1c-9bb9-4fee-a0fe-24ca21018672"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49713e45-d173-4cf4-939d-a6b199fe3d16"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Interact_L"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fab9b3a-8674-422b-96f9-e3a427083dc0"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Rotation Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07d498d2-b7f7-401e-952b-3700766f91dd"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Rotation X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f927f4d6-067e-4f03-888a-a91a3a4085ad"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34bb840a-169e-4813-b060-cc701e662a43"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Interact_R"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and mouse"",
            ""bindingGroup"": ""Keyboard and mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
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
        // Player_Interact
        m_Player_Interact = asset.FindActionMap("Player_Interact", throwIfNotFound: true);
        m_Player_Interact_Interact = m_Player_Interact.FindAction("Interact", throwIfNotFound: true);
        m_Player_Interact_RotationY = m_Player_Interact.FindAction("Rotation Y", throwIfNotFound: true);
        m_Player_Interact_RotationX = m_Player_Interact.FindAction("Rotation X", throwIfNotFound: true);
        m_Player_Interact_Jump = m_Player_Interact.FindAction("Jump", throwIfNotFound: true);
        m_Player_Interact_Movement = m_Player_Interact.FindAction("Movement", throwIfNotFound: true);
        // Player_SeperateHandInteract
        m_Player_SeperateHandInteract = asset.FindActionMap("Player_SeperateHandInteract", throwIfNotFound: true);
        m_Player_SeperateHandInteract_Jump = m_Player_SeperateHandInteract.FindAction("Jump", throwIfNotFound: true);
        m_Player_SeperateHandInteract_RotationX = m_Player_SeperateHandInteract.FindAction("Rotation X", throwIfNotFound: true);
        m_Player_SeperateHandInteract_RotationY = m_Player_SeperateHandInteract.FindAction("Rotation Y", throwIfNotFound: true);
        m_Player_SeperateHandInteract_Interact_L = m_Player_SeperateHandInteract.FindAction("Interact_L", throwIfNotFound: true);
        m_Player_SeperateHandInteract_Interact_R = m_Player_SeperateHandInteract.FindAction("Interact_R", throwIfNotFound: true);
        m_Player_SeperateHandInteract_Movement = m_Player_SeperateHandInteract.FindAction("Movement", throwIfNotFound: true);
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
        private @InputMaster m_Wrapper;
        public Player_TPGunActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
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

    // Player_Interact
    private readonly InputActionMap m_Player_Interact;
    private IPlayer_InteractActions m_Player_InteractActionsCallbackInterface;
    private readonly InputAction m_Player_Interact_Interact;
    private readonly InputAction m_Player_Interact_RotationY;
    private readonly InputAction m_Player_Interact_RotationX;
    private readonly InputAction m_Player_Interact_Jump;
    private readonly InputAction m_Player_Interact_Movement;
    public struct Player_InteractActions
    {
        private @InputMaster m_Wrapper;
        public Player_InteractActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Player_Interact_Interact;
        public InputAction @RotationY => m_Wrapper.m_Player_Interact_RotationY;
        public InputAction @RotationX => m_Wrapper.m_Player_Interact_RotationX;
        public InputAction @Jump => m_Wrapper.m_Player_Interact_Jump;
        public InputAction @Movement => m_Wrapper.m_Player_Interact_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Player_Interact; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_InteractActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_InteractActions instance)
        {
            if (m_Wrapper.m_Player_InteractActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnInteract;
                @RotationY.started -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnRotationY;
                @RotationY.performed -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnRotationY;
                @RotationY.canceled -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnRotationY;
                @RotationX.started -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnRotationX;
                @RotationX.performed -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnRotationX;
                @RotationX.canceled -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnRotationX;
                @Jump.started -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player_InteractActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_Player_InteractActionsCallbackInterface = instance;
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
    public Player_InteractActions @Player_Interact => new Player_InteractActions(this);

    // Player_SeperateHandInteract
    private readonly InputActionMap m_Player_SeperateHandInteract;
    private IPlayer_SeperateHandInteractActions m_Player_SeperateHandInteractActionsCallbackInterface;
    private readonly InputAction m_Player_SeperateHandInteract_Jump;
    private readonly InputAction m_Player_SeperateHandInteract_RotationX;
    private readonly InputAction m_Player_SeperateHandInteract_RotationY;
    private readonly InputAction m_Player_SeperateHandInteract_Interact_L;
    private readonly InputAction m_Player_SeperateHandInteract_Interact_R;
    private readonly InputAction m_Player_SeperateHandInteract_Movement;
    public struct Player_SeperateHandInteractActions
    {
        private @InputMaster m_Wrapper;
        public Player_SeperateHandInteractActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Player_SeperateHandInteract_Jump;
        public InputAction @RotationX => m_Wrapper.m_Player_SeperateHandInteract_RotationX;
        public InputAction @RotationY => m_Wrapper.m_Player_SeperateHandInteract_RotationY;
        public InputAction @Interact_L => m_Wrapper.m_Player_SeperateHandInteract_Interact_L;
        public InputAction @Interact_R => m_Wrapper.m_Player_SeperateHandInteract_Interact_R;
        public InputAction @Movement => m_Wrapper.m_Player_SeperateHandInteract_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Player_SeperateHandInteract; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_SeperateHandInteractActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_SeperateHandInteractActions instance)
        {
            if (m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnJump;
                @RotationX.started -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnRotationX;
                @RotationX.performed -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnRotationX;
                @RotationX.canceled -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnRotationX;
                @RotationY.started -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnRotationY;
                @RotationY.performed -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnRotationY;
                @RotationY.canceled -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnRotationY;
                @Interact_L.started -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnInteract_L;
                @Interact_L.performed -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnInteract_L;
                @Interact_L.canceled -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnInteract_L;
                @Interact_R.started -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnInteract_R;
                @Interact_R.performed -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnInteract_R;
                @Interact_R.canceled -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnInteract_R;
                @Movement.started -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_Player_SeperateHandInteractActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @RotationX.started += instance.OnRotationX;
                @RotationX.performed += instance.OnRotationX;
                @RotationX.canceled += instance.OnRotationX;
                @RotationY.started += instance.OnRotationY;
                @RotationY.performed += instance.OnRotationY;
                @RotationY.canceled += instance.OnRotationY;
                @Interact_L.started += instance.OnInteract_L;
                @Interact_L.performed += instance.OnInteract_L;
                @Interact_L.canceled += instance.OnInteract_L;
                @Interact_R.started += instance.OnInteract_R;
                @Interact_R.performed += instance.OnInteract_R;
                @Interact_R.canceled += instance.OnInteract_R;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public Player_SeperateHandInteractActions @Player_SeperateHandInteract => new Player_SeperateHandInteractActions(this);
    private int m_KeyboardandmouseSchemeIndex = -1;
    public InputControlScheme KeyboardandmouseScheme
    {
        get
        {
            if (m_KeyboardandmouseSchemeIndex == -1) m_KeyboardandmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and mouse");
            return asset.controlSchemes[m_KeyboardandmouseSchemeIndex];
        }
    }
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
    public interface IPlayer_InteractActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnRotationY(InputAction.CallbackContext context);
        void OnRotationX(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IPlayer_SeperateHandInteractActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnRotationX(InputAction.CallbackContext context);
        void OnRotationY(InputAction.CallbackContext context);
        void OnInteract_L(InputAction.CallbackContext context);
        void OnInteract_R(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
}
