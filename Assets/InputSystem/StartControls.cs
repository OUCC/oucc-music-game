//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.0
//     from Assets/InputSystem/StartControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace OUCC.MusicGame.InputSystem
{
    public partial class @StartControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @StartControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""StartControls"",
    ""maps"": [
        {
            ""name"": ""Speed"",
            ""id"": ""c5decaad-5244-4f1f-8653-df973bdfa500"",
            ""actions"": [
                {
                    ""name"": ""SpeedUp"",
                    ""type"": ""Button"",
                    ""id"": ""80cee863-aafd-449b-866e-7d7133602f43"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpeedDown"",
                    ""type"": ""Button"",
                    ""id"": ""56dafa0b-902d-446a-8153-27514c364c9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""94242d07-3af1-4497-adfc-e43b9002cb2b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpeedUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""123cb961-c83d-4030-944d-bd6eb72eeed0"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpeedDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Speed
            m_Speed = asset.FindActionMap("Speed", throwIfNotFound: true);
            m_Speed_SpeedUp = m_Speed.FindAction("SpeedUp", throwIfNotFound: true);
            m_Speed_SpeedDown = m_Speed.FindAction("SpeedDown", throwIfNotFound: true);
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

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Speed
        private readonly InputActionMap m_Speed;
        private List<ISpeedActions> m_SpeedActionsCallbackInterfaces = new List<ISpeedActions>();
        private readonly InputAction m_Speed_SpeedUp;
        private readonly InputAction m_Speed_SpeedDown;
        public struct SpeedActions
        {
            private @StartControls m_Wrapper;
            public SpeedActions(@StartControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @SpeedUp => m_Wrapper.m_Speed_SpeedUp;
            public InputAction @SpeedDown => m_Wrapper.m_Speed_SpeedDown;
            public InputActionMap Get() { return m_Wrapper.m_Speed; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SpeedActions set) { return set.Get(); }
            public void AddCallbacks(ISpeedActions instance)
            {
                if (instance == null || m_Wrapper.m_SpeedActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_SpeedActionsCallbackInterfaces.Add(instance);
                @SpeedUp.started += instance.OnSpeedUp;
                @SpeedUp.performed += instance.OnSpeedUp;
                @SpeedUp.canceled += instance.OnSpeedUp;
                @SpeedDown.started += instance.OnSpeedDown;
                @SpeedDown.performed += instance.OnSpeedDown;
                @SpeedDown.canceled += instance.OnSpeedDown;
            }

            private void UnregisterCallbacks(ISpeedActions instance)
            {
                @SpeedUp.started -= instance.OnSpeedUp;
                @SpeedUp.performed -= instance.OnSpeedUp;
                @SpeedUp.canceled -= instance.OnSpeedUp;
                @SpeedDown.started -= instance.OnSpeedDown;
                @SpeedDown.performed -= instance.OnSpeedDown;
                @SpeedDown.canceled -= instance.OnSpeedDown;
            }

            public void RemoveCallbacks(ISpeedActions instance)
            {
                if (m_Wrapper.m_SpeedActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ISpeedActions instance)
            {
                foreach (var item in m_Wrapper.m_SpeedActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_SpeedActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public SpeedActions @Speed => new SpeedActions(this);
        public interface ISpeedActions
        {
            void OnSpeedUp(InputAction.CallbackContext context);
            void OnSpeedDown(InputAction.CallbackContext context);
        }
    }
}
