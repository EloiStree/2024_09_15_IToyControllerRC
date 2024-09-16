using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputActionMono_WheelRC : MonoBehaviour
{

    public UnityEvent<float> m_onRotateLeftRight;
    public UnityEvent<float> m_onMoveBackForward;
    public UnityEvent<bool> m_onKillSwitchChanged;
    public InputActionReference m_leftRightReference;
    public InputActionReference m_backForwardReference;
    public InputActionReference m_killSwitchReference;

    public float m_rotateLeftRightValue = 0;
    public float m_moveBackForwardValue = 0;
    public bool m_killSwitchValue = false;



    public void OnEnable()
    {
        m_leftRightReference.action.Enable();
        m_backForwardReference.action.Enable();
        m_killSwitchReference.action.Enable();
        m_leftRightReference.action.performed += OnLeftRight;
        m_backForwardReference.action.performed += OnBackForward;
        m_leftRightReference.action.canceled += OnLeftRight;
        m_backForwardReference.action.canceled += OnBackForward;
        m_killSwitchReference.action.performed += OnKillSwitch;
        m_killSwitchReference.action.canceled += OnKillSwitch;


    }

    

    public void OnDisable()
    {
        m_leftRightReference.action.performed -= OnLeftRight;
        m_backForwardReference.action.performed -= OnBackForward;
        m_leftRightReference.action.canceled -= OnLeftRight;
        m_backForwardReference.action.canceled -= OnBackForward;
        m_killSwitchReference.action.performed -= OnKillSwitch;
        m_killSwitchReference.action.canceled -= OnKillSwitch;
    }
    private void OnKillSwitch(InputAction.CallbackContext context)
    {
        bool killSwitch = context.ReadValue<float>() > 0.5f;
        if (killSwitch != m_killSwitchValue)
        {
            m_killSwitchValue = killSwitch;
            m_onKillSwitchChanged.Invoke(killSwitch);
        }
    }
    private void OnBackForward(InputAction.CallbackContext context)
    {
        m_moveBackForwardValue = context.ReadValue<float>();
        m_onMoveBackForward.Invoke(context.ReadValue<float>());
    }

    private void OnLeftRight(InputAction.CallbackContext context)
    {
        m_rotateLeftRightValue = context.ReadValue<float>();
        m_onRotateLeftRight.Invoke(context.ReadValue<float>());
    }
}
