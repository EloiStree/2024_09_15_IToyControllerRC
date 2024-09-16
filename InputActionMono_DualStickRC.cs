using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputActionMono_DualStickRC : MonoBehaviour
{

    public UnityEvent<float> m_onJoystickLeftHorizontal;
    public UnityEvent<float> m_onJoystickLeftVertical;
    public UnityEvent<float> m_onJoystickRightHorizontal;
    public UnityEvent<float> m_onJoystickRightVertical;
    public UnityEvent<bool> m_onKillSwitchChanged;
    public InputActionReference m_josytickLeftHorizontalReference;
    public InputActionReference m_josytickLeftVerticalReference;
    public InputActionReference m_josytickRightHorizontalReference;
    public InputActionReference m_josytickRightVerticalReference;
    public InputActionReference m_killSwitchReference;
    public float m_joystickLeftHorizontalValue = 0;
    public float m_joystickLeftVerticalValue = 0;
    public float m_joystickRightHorizontalValue = 0;
    public float m_joystickRightVerticalValue = 0;
    public bool m_killSwitchValue = false;



    public void OnEnable()
    {
        m_josytickLeftHorizontalReference.action.Enable();
        m_josytickLeftVerticalReference.action.Enable();
        m_josytickRightHorizontalReference.action.Enable();
        m_josytickRightVerticalReference.action.Enable();
        m_killSwitchReference.action.Enable();

        m_josytickLeftHorizontalReference.action.performed += OnJoystickLeftHorizontal;
        m_josytickLeftVerticalReference.action.performed += OnJoystickLeftVertical;
        m_josytickRightHorizontalReference.action.performed += OnJoystickRightHorizontal;
        m_josytickRightVerticalReference.action.performed += OnJoystickRightVertical;
        m_josytickLeftHorizontalReference.action.canceled += OnJoystickLeftHorizontal;
        m_josytickLeftVerticalReference.action.canceled += OnJoystickLeftVertical;
        m_josytickRightHorizontalReference.action.canceled += OnJoystickRightHorizontal;
        m_josytickRightVerticalReference.action.canceled += OnJoystickRightVertical;
        m_killSwitchReference.action.performed += OnKillSwitch;
        m_killSwitchReference.action.canceled += OnKillSwitch;

    }


    public void OnDisable() {

        m_josytickLeftHorizontalReference.action.performed -= OnJoystickLeftHorizontal;
        m_josytickLeftVerticalReference.action.performed -= OnJoystickLeftVertical;
        m_josytickRightHorizontalReference.action.performed -= OnJoystickRightHorizontal;
        m_josytickRightVerticalReference.action.performed -= OnJoystickRightVertical;
        m_josytickLeftHorizontalReference.action.canceled -= OnJoystickLeftHorizontal;
        m_josytickLeftVerticalReference.action.canceled -= OnJoystickLeftVertical;
        m_josytickRightHorizontalReference.action.canceled -= OnJoystickRightHorizontal;
        m_josytickRightVerticalReference.action.canceled -= OnJoystickRightVertical;
        m_killSwitchReference.action.performed -= OnKillSwitch;
        m_killSwitchReference.action.canceled -= OnKillSwitch;

    }

    private void OnKillSwitch(InputAction.CallbackContext context)
    {
        bool killSwitch = context.ReadValue<float>() > 0.5f;
        if (killSwitch != m_killSwitchValue) { 
            m_killSwitchValue = killSwitch;
            m_onKillSwitchChanged.Invoke(killSwitch);
        }
    }
    private void OnJoystickRightVertical(InputAction.CallbackContext context)
    {

        m_joystickRightVerticalValue= context.ReadValue<float>();
        m_onJoystickRightVertical.Invoke(context.ReadValue<float>());
    }

    private void OnJoystickRightHorizontal(InputAction.CallbackContext context)
    {
        m_joystickRightHorizontalValue = context.ReadValue<float>();
        m_onJoystickRightHorizontal.Invoke(context.ReadValue<float>());
    }

    private void OnJoystickLeftVertical(InputAction.CallbackContext context)
    {
        m_joystickLeftVerticalValue = context.ReadValue<float>();
        m_onJoystickLeftVertical.Invoke(context.ReadValue<float>());
    }

    private void OnJoystickLeftHorizontal(InputAction.CallbackContext context)
    {
        m_joystickLeftHorizontalValue = context.ReadValue<float>();
        m_onJoystickLeftHorizontal.Invoke(context.ReadValue<float>());
    }

  
}