//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.0
//     from Assets/InputSystem/MainControls.inputactions
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
    public partial class @MainControls: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @MainControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainControls"",
    ""maps"": [
        {
            ""name"": ""Lane"",
            ""id"": ""192b1e1a-4e2b-4ef7-b828-1f4986539795"",
            ""actions"": [
                {
                    ""name"": ""Left1"",
                    ""type"": ""Value"",
                    ""id"": ""e8659987-38be-412c-a2a8-591dcf3fc3a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Left2"",
                    ""type"": ""Button"",
                    ""id"": ""0a3f4c2b-2918-4185-a5df-abcaa4780659"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MidLeft"",
                    ""type"": ""Button"",
                    ""id"": ""553f0412-7d9c-47ef-b400-126a9d9826a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MidRight"",
                    ""type"": ""Button"",
                    ""id"": ""478aaa6e-4004-45ce-a4c7-ad8151c237f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right2"",
                    ""type"": ""Button"",
                    ""id"": ""ba19d5e2-bb15-4248-93a0-ccd66e643721"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right1"",
                    ""type"": ""Button"",
                    ""id"": ""b16a7547-8beb-4b1b-b12f-f69832513355"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""373c9706-ab9c-49fe-9fd1-63ca0a106251"",
                    ""path"": ""<Keyboard>/#(S)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47cb3fc9-4cf8-4ba2-8f0c-86670af6b3f2"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8afdd00-1600-4a91-9056-6702703a46ad"",
                    ""path"": ""<Keyboard>/#(F)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MidLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""835206b8-2e50-4ba0-be96-1f826b1f7a0b"",
                    ""path"": ""<Keyboard>/#(J)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MidRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95940472-1607-4046-a2d1-f01d0a368f58"",
                    ""path"": ""<Keyboard>/#(K)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8aeecaf1-dc8d-4847-842b-facc59ae87cf"",
                    ""path"": ""<Keyboard>/#(L)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Lane
            m_Lane = asset.FindActionMap("Lane", throwIfNotFound: true);
            m_Lane_Left1 = m_Lane.FindAction("Left1", throwIfNotFound: true);
            m_Lane_Left2 = m_Lane.FindAction("Left2", throwIfNotFound: true);
            m_Lane_MidLeft = m_Lane.FindAction("MidLeft", throwIfNotFound: true);
            m_Lane_MidRight = m_Lane.FindAction("MidRight", throwIfNotFound: true);
            m_Lane_Right2 = m_Lane.FindAction("Right2", throwIfNotFound: true);
            m_Lane_Right1 = m_Lane.FindAction("Right1", throwIfNotFound: true);
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

        // Lane
        private readonly InputActionMap m_Lane;
        private List<ILaneActions> m_LaneActionsCallbackInterfaces = new List<ILaneActions>();
        private readonly InputAction m_Lane_Left1;
        private readonly InputAction m_Lane_Left2;
        private readonly InputAction m_Lane_MidLeft;
        private readonly InputAction m_Lane_MidRight;
        private readonly InputAction m_Lane_Right2;
        private readonly InputAction m_Lane_Right1;
        public struct LaneActions
        {
            private @MainControls m_Wrapper;
            public LaneActions(@MainControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Left1 => m_Wrapper.m_Lane_Left1;
            public InputAction @Left2 => m_Wrapper.m_Lane_Left2;
            public InputAction @MidLeft => m_Wrapper.m_Lane_MidLeft;
            public InputAction @MidRight => m_Wrapper.m_Lane_MidRight;
            public InputAction @Right2 => m_Wrapper.m_Lane_Right2;
            public InputAction @Right1 => m_Wrapper.m_Lane_Right1;
            public InputActionMap Get() { return m_Wrapper.m_Lane; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(LaneActions set) { return set.Get(); }
            public void AddCallbacks(ILaneActions instance)
            {
                if (instance == null || m_Wrapper.m_LaneActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_LaneActionsCallbackInterfaces.Add(instance);
                @Left1.started += instance.OnLeft1;
                @Left1.performed += instance.OnLeft1;
                @Left1.canceled += instance.OnLeft1;
                @Left2.started += instance.OnLeft2;
                @Left2.performed += instance.OnLeft2;
                @Left2.canceled += instance.OnLeft2;
                @MidLeft.started += instance.OnMidLeft;
                @MidLeft.performed += instance.OnMidLeft;
                @MidLeft.canceled += instance.OnMidLeft;
                @MidRight.started += instance.OnMidRight;
                @MidRight.performed += instance.OnMidRight;
                @MidRight.canceled += instance.OnMidRight;
                @Right2.started += instance.OnRight2;
                @Right2.performed += instance.OnRight2;
                @Right2.canceled += instance.OnRight2;
                @Right1.started += instance.OnRight1;
                @Right1.performed += instance.OnRight1;
                @Right1.canceled += instance.OnRight1;
            }

            private void UnregisterCallbacks(ILaneActions instance)
            {
                @Left1.started -= instance.OnLeft1;
                @Left1.performed -= instance.OnLeft1;
                @Left1.canceled -= instance.OnLeft1;
                @Left2.started -= instance.OnLeft2;
                @Left2.performed -= instance.OnLeft2;
                @Left2.canceled -= instance.OnLeft2;
                @MidLeft.started -= instance.OnMidLeft;
                @MidLeft.performed -= instance.OnMidLeft;
                @MidLeft.canceled -= instance.OnMidLeft;
                @MidRight.started -= instance.OnMidRight;
                @MidRight.performed -= instance.OnMidRight;
                @MidRight.canceled -= instance.OnMidRight;
                @Right2.started -= instance.OnRight2;
                @Right2.performed -= instance.OnRight2;
                @Right2.canceled -= instance.OnRight2;
                @Right1.started -= instance.OnRight1;
                @Right1.performed -= instance.OnRight1;
                @Right1.canceled -= instance.OnRight1;
            }

            public void RemoveCallbacks(ILaneActions instance)
            {
                if (m_Wrapper.m_LaneActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ILaneActions instance)
            {
                foreach (var item in m_Wrapper.m_LaneActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_LaneActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public LaneActions @Lane => new LaneActions(this);
        public interface ILaneActions
        {
            void OnLeft1(InputAction.CallbackContext context);
            void OnLeft2(InputAction.CallbackContext context);
            void OnMidLeft(InputAction.CallbackContext context);
            void OnMidRight(InputAction.CallbackContext context);
            void OnRight2(InputAction.CallbackContext context);
            void OnRight1(InputAction.CallbackContext context);
        }
    }
}