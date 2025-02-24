using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputActionMono_DoubleJoysticksRC : MonoBehaviour
{

    public UnityEvent<Vector2, Vector2> m_leftRightJoysticks;
    public UnityEvent<bool> m_onKillSwitchChanged;
    public InputActionReference m_onLeftJoystickReference;
    public InputActionReference m_onRightJoystickReference;
    public InputActionReference m_onKillSwitchChangedReference;

    public Vector2 m_leftJoystickValue = Vector2.zero;
    public Vector2 m_rightJoystickValue = Vector2.zero;
    public bool m_killSwitchValue = false;



    public void OnEnable()
    {

        m_onKillSwitchChangedReference.action.Enable();
        m_onLeftJoystickReference.action.Enable();
        m_onRightJoystickReference.action.Enable();

        m_onLeftJoystickReference.action.performed += OnJoystickLeft;
        m_onLeftJoystickReference.action.canceled += OnJoystickLeft;

        m_onRightJoystickReference.action.performed += OnJoystickRight;
        m_onRightJoystickReference.action.canceled += OnJoystickRight;




        m_onKillSwitchChangedReference.action.performed += OnKillSwitch;
        m_onKillSwitchChangedReference.action.canceled += OnKillSwitch;


    }

    private void OnJoystickRight(InputAction.CallbackContext context)
    {

        Vector2 rightJoystick = context.ReadValue<Vector2>();
        if (rightJoystick != m_rightJoystickValue)
        {
            m_rightJoystickValue = rightJoystick;
            m_leftRightJoysticks.Invoke(m_leftJoystickValue, m_rightJoystickValue);
        }
    }

    private void OnJoystickLeft(InputAction.CallbackContext context)
    {
        Vector2 leftJoystick = context.ReadValue<Vector2>();
        if (leftJoystick != m_leftJoystickValue)
        {
            m_leftJoystickValue = leftJoystick;
            m_leftRightJoysticks.Invoke(m_leftJoystickValue, m_rightJoystickValue);
        }
    }

    public void OnDisable()
    {

        m_onLeftJoystickReference.action.performed -= OnJoystickLeft;
        m_onLeftJoystickReference.action.canceled -= OnJoystickLeft;
        m_onRightJoystickReference.action.performed -= OnJoystickRight;
        m_onRightJoystickReference.action.canceled -= OnJoystickRight;



        m_onKillSwitchChangedReference.action.performed -= OnKillSwitch;
        m_onKillSwitchChangedReference.action.canceled -= OnKillSwitch;
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


}
