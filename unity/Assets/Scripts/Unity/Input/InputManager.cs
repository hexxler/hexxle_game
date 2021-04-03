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
        }
    ]
}");
        // MenuInteraction
        m_MenuInteraction = asset.FindActionMap("MenuInteraction", throwIfNotFound: true);
        m_MenuInteraction_Pause = m_MenuInteraction.FindAction("Pause", throwIfNotFound: true);
        // TilePlacement
        m_TilePlacement = asset.FindActionMap("TilePlacement", throwIfNotFound: true);
        m_TilePlacement_MouseClick = m_TilePlacement.FindAction("MouseClick", throwIfNotFound: true);
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
    public struct TilePlacementActions
    {
        private @InputManager m_Wrapper;
        public TilePlacementActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseClick => m_Wrapper.m_TilePlacement_MouseClick;
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
            }
            m_Wrapper.m_TilePlacementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
            }
        }
    }
    public TilePlacementActions @TilePlacement => new TilePlacementActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IMenuInteractionActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
    public interface ITilePlacementActions
    {
        void OnMouseClick(InputAction.CallbackContext context);
    }
}
