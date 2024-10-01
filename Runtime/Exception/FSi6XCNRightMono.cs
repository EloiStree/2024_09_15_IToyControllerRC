using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class FSi6XCNRightMono : MonoBehaviour
{

    public UnityEvent<float> m_onJoystickLeftHorizontal;
    public UnityEvent<float> m_onJoystickLeftVertical;
    public UnityEvent<float> m_onJoystickRightHorizontal;
    public UnityEvent<float> m_onJoystickRightVertical;

    public InputActionReference m_joystickLeftHorizontalReference;
    public InputActionReference m_joystickLeftVerticalReference;
    public InputActionReference m_joystickRightHorizontalReference;
    public InputActionReference m_joystickRightVerticalReference;

    public float m_joystickLeftHorizontalValue = 0;
    public float m_joystickLeftVerticalValue = 0;
    public float m_joystickRightHorizontalValue = 0;
    public float m_joystickRightVerticalValue = 0;
    public float m_joystickLeftHorizontalPercent = 0;
    public float m_joystickLeftVerticalPercent = 0;
    public float m_joystickRightHorizontalPercent = 0;
    public float m_joystickRightVerticalPercent = 0;

    public void OnEnable()
    {
        m_joystickLeftHorizontalReference.action.Enable();
        m_joystickLeftVerticalReference.action.Enable();
        m_joystickRightHorizontalReference.action.Enable();
        m_joystickRightVerticalReference.action.Enable();

        m_joystickLeftHorizontalReference.action.performed += OnJoystickLeftHorizontal;
        m_joystickLeftVerticalReference.action.performed += OnJoystickLeftVertical;
        m_joystickRightHorizontalReference.action.performed += OnJoystickRightHorizontal;
        m_joystickRightVerticalReference.action.performed += OnJoystickRightVertical;
        m_joystickLeftHorizontalReference.action.canceled += OnJoystickLeftHorizontal;
        m_joystickLeftVerticalReference.action.canceled += OnJoystickLeftVertical;
        m_joystickRightHorizontalReference.action.canceled += OnJoystickRightHorizontal;
        m_joystickRightVerticalReference.action.canceled += OnJoystickRightVertical;

    }

    private void OnJoystickRightVertical(InputAction.CallbackContext context)
    {
        float readValue = context.ReadValue<float>();
        float percent = 0;

        //Correct Axis;
        //Y -0.22 -0.98 0.98 0.22

        if (readValue < -0)
        {
            percent = Math.Abs(readValue);
            percent -= 0.2f;
            percent /= 0.8f;
            percent = 1 - percent;
            percent *= -1f;

        }
        
        else if (readValue > 0)
        {
            percent = Math.Abs(readValue);
            percent -= 0.2f;
            percent /= 0.8f;
            percent = 1 - percent;

        }

        else { }

        percent= Math.Clamp(percent, -1f, 1f);

        m_joystickRightVerticalValue = readValue;
        if (percent != m_joystickRightVerticalPercent)
        {
            m_joystickRightVerticalPercent = percent;
            m_onJoystickRightVertical.Invoke(percent);
        }
    }

    public float m_adjustementHorizontal = 0.69f;
    public float m_adjustementVertical = 0.69f;

    private void OnJoystickRightHorizontal(InputAction.CallbackContext context)
    {
        float readValue = context.ReadValue<float>();
        float percent = 0;
        // Correct axis
        //x 0.28  0.69 -0.69 -0.28


        if (readValue < -0)
        {
            percent = Math.Abs(readValue);
            percent -= 0.2f;
            percent /= 0.8f;
            percent = 1 - percent;

        }

        else if (readValue > 0)
        {
            percent = Math.Abs(readValue);
            percent -= 0.2f;
            percent /= 0.8f;
            percent = 1 - percent;
            percent *= -1f;

        }

        else { }

        percent = Math.Clamp(percent, -1f, 1f);
        m_joystickRightHorizontalValue = readValue;
        if (percent != m_joystickRightHorizontalPercent)
        {
            m_joystickRightHorizontalPercent = percent;
            m_onJoystickRightHorizontal.Invoke(percent);
        }
    }

    private void OnJoystickLeftVertical(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        float percent = value;
        m_joystickLeftVerticalValue = value / 0.69f;
        percent = Math.Clamp(percent, -1f, 1f);
        if (percent != m_joystickLeftVerticalPercent)
        {
            m_joystickLeftVerticalPercent = percent;
            m_onJoystickLeftVertical.Invoke(percent);
        }
    }

    private void OnJoystickLeftHorizontal(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        float percent = value;
        m_joystickLeftHorizontalValue = value / 0.69f;
        percent = Math.Clamp(percent, -1f, 1f);
        if (percent != m_joystickLeftHorizontalPercent)
        {
            m_joystickLeftHorizontalPercent = percent;
            m_onJoystickLeftHorizontal.Invoke(percent);
        }
    }

    public void OnDisable()
    {
            
            m_joystickLeftHorizontalReference.action.performed -= OnJoystickLeftHorizontal;
            m_joystickLeftVerticalReference.action.performed -= OnJoystickLeftVertical;
            m_joystickRightHorizontalReference.action.performed -= OnJoystickRightHorizontal;
            m_joystickRightVerticalReference.action.performed -= OnJoystickRightVertical;
            m_joystickLeftHorizontalReference.action.canceled -= OnJoystickLeftHorizontal;
            m_joystickLeftVerticalReference.action.canceled -= OnJoystickLeftVertical;
            m_joystickRightHorizontalReference.action.canceled -= OnJoystickRightHorizontal;
            m_joystickRightVerticalReference.action.canceled -= OnJoystickRightVertical;

    }
}
