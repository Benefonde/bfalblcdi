// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/CursorMenu.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CursorMenu : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CursorMenu()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CursorMenu"",
    ""maps"": [
        {
            ""name"": ""MenuControls"",
            ""id"": ""f5243d85-de29-447e-b2b5-739316272b76"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""7e5dfe9a-362b-4278-933e-3a96943294da"",
                    ""expectedControlType"": """",
                    ""processors"": ""ScaleVector2(x=1.5,y=1.5)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpeedUpMove"",
                    ""type"": ""Value"",
                    ""id"": ""81121889-1294-46b1-af6c-0e04d3325a43"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Value"",
                    ""id"": ""92b48c96-2da2-46fa-81d0-e6f55ea00f95"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Value"",
                    ""id"": ""6c7060ba-4dcd-4898-9c2e-60a1cf1be9b9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e915806e-d480-4154-9fba-a0b4771e5e29"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone,ScaleVector2(x=4,y=4)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8713d68-56a5-42d1-8276-8b16981bd230"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7add7cf-ee08-4652-a0f4-bf7f0bf15a2f"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpeedUpMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""254be893-9a7b-4d9b-9fed-576eb9913ea0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f285b4e5-5e9c-4579-885d-dec6672aba91"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MenuControls
        m_MenuControls = asset.FindActionMap("MenuControls", throwIfNotFound: true);
        m_MenuControls_Move = m_MenuControls.FindAction("Move", throwIfNotFound: true);
        m_MenuControls_SpeedUpMove = m_MenuControls.FindAction("SpeedUpMove", throwIfNotFound: true);
        m_MenuControls_Confirm = m_MenuControls.FindAction("Confirm", throwIfNotFound: true);
        m_MenuControls_Cancel = m_MenuControls.FindAction("Cancel", throwIfNotFound: true);
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

    // MenuControls
    private readonly InputActionMap m_MenuControls;
    private IMenuControlsActions m_MenuControlsActionsCallbackInterface;
    private readonly InputAction m_MenuControls_Move;
    private readonly InputAction m_MenuControls_SpeedUpMove;
    private readonly InputAction m_MenuControls_Confirm;
    private readonly InputAction m_MenuControls_Cancel;
    public struct MenuControlsActions
    {
        private @CursorMenu m_Wrapper;
        public MenuControlsActions(@CursorMenu wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MenuControls_Move;
        public InputAction @SpeedUpMove => m_Wrapper.m_MenuControls_SpeedUpMove;
        public InputAction @Confirm => m_Wrapper.m_MenuControls_Confirm;
        public InputAction @Cancel => m_Wrapper.m_MenuControls_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_MenuControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMenuControlsActions instance)
        {
            if (m_Wrapper.m_MenuControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnMove;
                @SpeedUpMove.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnSpeedUpMove;
                @SpeedUpMove.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnSpeedUpMove;
                @SpeedUpMove.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnSpeedUpMove;
                @Confirm.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnConfirm;
                @Cancel.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_MenuControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @SpeedUpMove.started += instance.OnSpeedUpMove;
                @SpeedUpMove.performed += instance.OnSpeedUpMove;
                @SpeedUpMove.canceled += instance.OnSpeedUpMove;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public MenuControlsActions @MenuControls => new MenuControlsActions(this);
    public interface IMenuControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSpeedUpMove(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
}
