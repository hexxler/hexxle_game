// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Unity/Input/InputManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""MenuInteraction"",
            ""id"": ""4cfff686-8c73-4d85-9679-cef9965e49bb"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""f4b73eeb-22c7-4c5c-b17d-ca468977b83e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8d07c4bd-4ef8-4fc4-86f2-06758fc07da3"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""TilePlacement"",
            ""id"": ""f353c50b-9338-456f-8f81-3dab28bed78b"",
            ""actions"": [
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""c023fc43-5d3d-4238-abc1-1f548f16b5e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TileRotation"",
                    ""type"": ""Button"",
                    ""id"": ""739c1198-77a4-44b4-994d-218c07dbf71e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""936ef65c-3f0f-4df3-9270-ef9913b5c2e8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""fd6991ff-bfcf-4939-b025-8661d325ef26"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TileRotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""02929407-8c47-489b-bfd8-c7351b1d8ce4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""TileRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""37077ecf-ed43-43e0-b42c-4604e270a8cd"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""TileRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""CameraMovement"",
            ""id"": ""911f02e1-9526-4281-aacf-bf2264f22694"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6fdbd460-ba95-4202-beb1-d80886c3a3bc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""f8c8f6ca-6e5c-4078-8365-1dc3de381583"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""79eb0345-0434-456d-ac89-50c7dd7aabb1"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard WASD"",
                    ""id"": ""1edd01ae-a473-49d7-aab5-d2e040796081"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1ae6ee74-214c-4c36-a04e-a4bb9d6104c6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""032e25e4-e8df-47a8-a99c-bdb161266c9b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6a4751e9-3cd4-4b22-b59b-1e2bd1264730"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b90c6e10-41ff-428e-b7fb-7e434c311f29"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard Arrows"",
                    ""id"": ""37b7613e-9c81-45da-a907-0dce4d075da5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c5837279-8e42-46ed-ba9b-5e8085c0a522"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7966c6e8-f203-4fbe-a762-76d592a3f077"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a95ba138-3927-4416-ace7-80236a39f6d4"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f5bf0ae4-da61-429d-9f5d-c67944bdb4f1"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
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
            ""name"": ""Touch Only"",
            ""bindingGroup"": ""Touch Only"",
            ""devices"": []
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        }
    ]
}");
        // MenuInteraction
        m_MenuInteraction = asset.FindActionMap("MenuInteraction", throwIfNotFound: true);
        m_MenuInteraction_Pause = m_MenuInteraction.FindAction("Pause", throwIfNotFound: true);
        // TilePlacement
        m_TilePlacement = asset.FindActionMap("TilePlacement", throwIfNotFound: true);
        m_TilePlacement_MouseClick = m_TilePlacement.FindAction("MouseClick", throwIfNotFound: true);
        m_TilePlacement_TileRotation = m_TilePlacement.FindAction("TileRotation", throwIfNotFound: true);
        // CameraMovement
        m_CameraMovement = asset.FindActionMap("CameraMovement", throwIfNotFound: true);
        m_CameraMovement_Move = m_CameraMovement.FindAction("Move", throwIfNotFound: true);
        m_CameraMovement_Zoom = m_CameraMovement.FindAction("Zoom", throwIfNotFound: true);
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

    // MenuInteraction
    private readonly InputActionMap m_MenuInteraction;
    private IMenuInteractionActions m_MenuInteractionActionsCallbackInterface;
    private readonly InputAction m_MenuInteraction_Pause;
    public struct MenuInteractionActions
    {
        private @InputManager m_Wrapper;
        public MenuInteractionActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_MenuInteraction_Pause;
        public InputActionMap Get() { return m_Wrapper.m_MenuInteraction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuInteractionActions set) { return set.Get(); }
        public void SetCallbacks(IMenuInteractionActions instance)
        {
            if (m_Wrapper.m_MenuInteractionActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_MenuInteractionActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MenuInteractionActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MenuInteractionActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_MenuInteractionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public MenuInteractionActions @MenuInteraction => new MenuInteractionActions(this);

    // TilePlacement
    private readonly InputActionMap m_TilePlacement;
    private ITilePlacementActions m_TilePlacementActionsCallbackInterface;
    private readonly InputAction m_TilePlacement_MouseClick;
    private readonly InputAction m_TilePlacement_TileRotation;
    public struct TilePlacementActions
    {
        private @InputManager m_Wrapper;
        public TilePlacementActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseClick => m_Wrapper.m_TilePlacement_MouseClick;
        public InputAction @TileRotation => m_Wrapper.m_TilePlacement_TileRotation;
        public InputActionMap Get() { return m_Wrapper.m_TilePlacement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TilePlacementActions set) { return set.Get(); }
        public void SetCallbacks(ITilePlacementActions instance)
        {
            if (m_Wrapper.m_TilePlacementActionsCallbackInterface != null)
            {
                @MouseClick.started -= m_Wrapper.m_TilePlacementActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_TilePlacementActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_TilePlacementActionsCallbackInterface.OnMouseClick;
                @TileRotation.started -= m_Wrapper.m_TilePlacementActionsCallbackInterface.OnTileRotation;
                @TileRotation.performed -= m_Wrapper.m_TilePlacementActionsCallbackInterface.OnTileRotation;
                @TileRotation.canceled -= m_Wrapper.m_TilePlacementActionsCallbackInterface.OnTileRotation;
            }
            m_Wrapper.m_TilePlacementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
                @TileRotation.started += instance.OnTileRotation;
                @TileRotation.performed += instance.OnTileRotation;
                @TileRotation.canceled += instance.OnTileRotation;
            }
        }
    }
    public TilePlacementActions @TilePlacement => new TilePlacementActions(this);

    // CameraMovement
    private readonly InputActionMap m_CameraMovement;
    private ICameraMovementActions m_CameraMovementActionsCallbackInterface;
    private readonly InputAction m_CameraMovement_Move;
    private readonly InputAction m_CameraMovement_Zoom;
    public struct CameraMovementActions
    {
        private @InputManager m_Wrapper;
        public CameraMovementActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CameraMovement_Move;
        public InputAction @Zoom => m_Wrapper.m_CameraMovement_Zoom;
        public InputActionMap Get() { return m_Wrapper.m_CameraMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraMovementActions set) { return set.Get(); }
        public void SetCallbacks(ICameraMovementActions instance)
        {
            if (m_Wrapper.m_CameraMovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnMove;
                @Zoom.started -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnZoom;
            }
            m_Wrapper.m_CameraMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
            }
        }
    }
    public CameraMovementActions @CameraMovement => new CameraMovementActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_TouchOnlySchemeIndex = -1;
    public InputControlScheme TouchOnlyScheme
    {
        get
        {
            if (m_TouchOnlySchemeIndex == -1) m_TouchOnlySchemeIndex = asset.FindControlSchemeIndex("Touch Only");
            return asset.controlSchemes[m_TouchOnlySchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IMenuInteractionActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
    public interface ITilePlacementActions
    {
        void OnMouseClick(InputAction.CallbackContext context);
        void OnTileRotation(InputAction.CallbackContext context);
    }
    public interface ICameraMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
    }
}
