using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputActionMono_JoystickToFloat2D : MonoBehaviour { 

    public UnityEvent<float> m_onJoystickX;
    public UnityEvent<float> m_onJoystickY;
    public InputActionReference m_joystickReference;

    public float m_joystickXValue = 0;
    public float m_joystickYValue = 0;
    public void OnEnable()
    {

        if (m_joystickReference == null)
            return;
        m_joystickReference.action.Enable();
        m_joystickReference.action.performed += OnJoystick;
        m_joystickReference.action.canceled += OnJoystick;
    }

    public void OnDisable()
    {

        if (m_joystickReference == null)
            return;
        m_joystickReference.action.performed -= OnJoystick;
        m_joystickReference.action.canceled -= OnJoystick;
    }

    private void OnJoystick(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        if (value.x != m_joystickXValue)
        {
            m_joystickXValue = value.x;
            m_onJoystickX.Invoke(value.x);
        }
        if (value.y != m_joystickYValue)
        {
            m_joystickYValue = value.y;
            m_onJoystickY.Invoke(value.y);
        }
    }
    
}
