using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputActionMono_BasicButtonRC : MonoBehaviour {

    public UnityEvent<bool> m_onButtonChanged;
    public UnityEvent m_onButtonDownChanged;
    public UnityEvent m_onButtonUpChanged;
    public InputActionReference m_buttonReference;

    public bool m_valueIsOn;


    public void OnEnable()
    {
        if (m_buttonReference == null)
            return;
        m_buttonReference.action.Enable();
        m_buttonReference.action.performed += OnButton;
        m_buttonReference.action.canceled += OnButton;
    }
    public void OnDisable()
    {
        if (m_buttonReference == null)
            return;
        m_buttonReference.action.performed -= OnButton;
        m_buttonReference.action.canceled -= OnButton;
    }

    private void OnButton(InputAction.CallbackContext context)
    {
        bool value = context.ReadValue<float>() > 0.5f;
        if (value != m_valueIsOn)
        {
            m_valueIsOn = value;
            m_onButtonChanged.Invoke(value);
            if (value)
            {
                m_onButtonDownChanged.Invoke();
            }
            else
            {
                m_onButtonUpChanged.Invoke();
            }
        }
    }
}
