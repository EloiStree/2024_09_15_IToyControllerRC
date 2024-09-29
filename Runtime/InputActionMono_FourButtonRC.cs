using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputActionMono_FourButtonRC : MonoBehaviour
{

    public UnityEvent<bool> m_onLeftDownButton;
    public UnityEvent<bool> m_onLeftUpButton;
    public UnityEvent<bool> m_onRightDownButton;
    public UnityEvent<bool> m_onRightUpButton;

    public UnityEvent<float> m_onLeftAxis;
    public UnityEvent<float> m_onRightAxis;
    public UnityEvent<bool> m_onKillSwitchChanged;


    public InputActionReference m_onLeftDownButtonReference;
    public InputActionReference m_onLeftUpButtonReference;
    public InputActionReference m_onRightDownButtonReference;
    public InputActionReference m_onRightUpButtonReference;
    public InputActionReference m_onKillSwitchChangedReference;


    public float m_leftAxisValue = 0;
    public float m_rightAxisValue = 0;
    public bool m_isLeftDownValue = false;
    public bool m_isLeftUpValue = false;
    public bool m_isRightDownValue = false;
    public bool m_isRightUpValue = false;
    public bool m_killSwitchValue = false;



    public void OnEnable()
    {

        m_onLeftDownButtonReference.action.Enable();
        m_onLeftUpButtonReference.action.Enable();
        m_onRightDownButtonReference.action.Enable();
        m_onRightUpButtonReference.action.Enable();
        m_onKillSwitchChangedReference.action.Enable();

        m_onLeftDownButtonReference.action.performed += OnLeftDownButton;
        m_onLeftUpButtonReference.action.performed += OnLeftUpButton;
        m_onRightDownButtonReference.action.performed += OnRightDownButton;
        m_onRightUpButtonReference.action.performed += OnRightUpButton;

        m_onLeftDownButtonReference.action.canceled += OnLeftDownButton;
        m_onLeftUpButtonReference.action.canceled += OnLeftUpButton;
        m_onRightDownButtonReference.action.canceled += OnRightDownButton;
        m_onRightUpButtonReference.action.canceled += OnRightUpButton;




        m_onKillSwitchChangedReference.action.performed += OnKillSwitch;
        m_onKillSwitchChangedReference.action.canceled += OnKillSwitch;


    }

    public void OnDisable()
    {
        m_onLeftDownButtonReference.action.performed -= OnLeftDownButton;
        m_onLeftUpButtonReference.action.performed -= OnLeftUpButton;
        m_onRightDownButtonReference.action.performed -= OnRightDownButton;
        m_onRightUpButtonReference.action.performed -= OnRightUpButton;

        m_onLeftDownButtonReference.action.canceled -= OnLeftDownButton;
        m_onLeftUpButtonReference.action.canceled -= OnLeftUpButton;
        m_onRightDownButtonReference.action.canceled -= OnRightDownButton;
        m_onRightUpButtonReference.action.canceled -= OnRightUpButton;



        m_onKillSwitchChangedReference.action.performed -= OnKillSwitch;
        m_onKillSwitchChangedReference.action.canceled -= OnKillSwitch;
    }



    private void OnRightUpButton(InputAction.CallbackContext context)
    {
        bool isRightUp = context.ReadValue<float>() > 0.5f;
        if (isRightUp != m_isRightUpValue)
        {
            m_isRightUpValue = isRightUp;
            m_onRightUpButton.Invoke(isRightUp);
            RefreshAxis();
        }
    }


    private void OnRightDownButton(InputAction.CallbackContext context)
    {
        bool isRightDown = context.ReadValue<float>() > 0.5f;
        if (isRightDown != m_isRightDownValue)
        {
            m_isRightDownValue = isRightDown;
            m_onRightDownButton.Invoke(isRightDown);
            RefreshAxis();
        }
    }

    private void OnLeftUpButton(InputAction.CallbackContext context)
    {
        bool isLeftUp = context.ReadValue<float>() > 0.5f;
        if (isLeftUp != m_isLeftUpValue)
        {
            m_isLeftUpValue = isLeftUp;
            m_onLeftUpButton.Invoke(isLeftUp);
            RefreshAxis();
        }

    }

    private void OnLeftDownButton(InputAction.CallbackContext context)
    {
        bool isLeftDown = context.ReadValue<float>() > 0.5f;
        if (isLeftDown != m_isLeftDownValue)
        {
            m_isLeftDownValue = isLeftDown;
            m_onLeftDownButton.Invoke(isLeftDown);
            RefreshAxis();
        }
    }
    private void RefreshAxis()
    {
        float leftAxis = 0;
        float rightAxis = 0;
        if (m_isLeftDownValue)
            leftAxis += 1;
        if (m_isLeftUpValue)
            leftAxis -= 1;
        if (m_isRightDownValue)
            rightAxis += 1;
        if (m_isRightUpValue)
            rightAxis -= 1;

        if (leftAxis != m_leftAxisValue)
        {
            m_leftAxisValue = leftAxis;
            m_onLeftAxis.Invoke(leftAxis);
        }
        if (rightAxis != m_rightAxisValue)
        {
            m_rightAxisValue = rightAxis;
            m_onRightAxis.Invoke(rightAxis);
        }
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
