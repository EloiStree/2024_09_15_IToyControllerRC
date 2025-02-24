using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RelayDualStickStateChangedMono : MonoBehaviour
{
    public A_DualStickRcStateMono m_dualStickSource;
    public DualStickRcState m_sourceStatePreviousState;
    public DualStickRcState m_sourceStateCurrentState;


    public UnityEvent<float> m_onJoystickLeftHorizontalChanged;
    public UnityEvent<float> m_onJoystickLeftVerticalChanged;

    public UnityEvent<float> m_onJoystickRightHorizontalChanged;
    public UnityEvent<float> m_onJoystickRightVerticalChanged;
    public UnityEvent<bool> m_onKillSwitchChanged;
    public UnityEvent<Vector2, Vector2> m_onJoysticksChanged;
    public UnityEvent<I_DualStickRcStateGet> m_onAnyValueChanged;

    public void Update()
    {
        m_dualStickSource.GetJoystickLeftHorizontal(out m_sourceStateCurrentState.m_joystickLeftHorizontalValue);
        m_dualStickSource.GetJoystickLeftVertical(out m_sourceStateCurrentState.m_joystickLeftVerticalValue);
        m_dualStickSource.GetJoystickRightHorizontal(out m_sourceStateCurrentState.m_joystickRightHorizontalValue);
        m_dualStickSource.GetJoystickRightVertical(out m_sourceStateCurrentState.m_joystickRightVerticalValue);

        bool anyChanged = false;

        if (m_sourceStatePreviousState.m_joystickLeftHorizontalValue !=
            m_sourceStateCurrentState.m_joystickLeftHorizontalValue)
        {
            m_sourceStatePreviousState.m_joystickLeftHorizontalValue =
                m_sourceStateCurrentState.m_joystickLeftHorizontalValue;

            anyChanged = true;
            m_onJoystickLeftHorizontalChanged.Invoke(
                m_sourceStateCurrentState.m_joystickLeftHorizontalValue);
        }
        if (m_sourceStatePreviousState.m_joystickLeftVerticalValue !=
            m_sourceStateCurrentState.m_joystickLeftVerticalValue)
        {
            m_sourceStatePreviousState.m_joystickLeftVerticalValue =
     m_sourceStateCurrentState.m_joystickLeftVerticalValue;

            anyChanged = true;
            m_onJoystickLeftVerticalChanged.Invoke(
                m_sourceStateCurrentState.m_joystickLeftVerticalValue);
        }
        if (m_sourceStatePreviousState.m_joystickRightHorizontalValue !=
            m_sourceStateCurrentState.m_joystickRightHorizontalValue)
        {
            m_sourceStatePreviousState.m_joystickRightHorizontalValue =
     m_sourceStateCurrentState.m_joystickRightHorizontalValue;
            anyChanged = true;
            m_onJoystickRightHorizontalChanged.Invoke(
                m_sourceStateCurrentState.m_joystickRightHorizontalValue);
        }
        if (m_sourceStatePreviousState.m_joystickRightVerticalValue !=
            m_sourceStateCurrentState.m_joystickRightVerticalValue)
        {
            m_sourceStatePreviousState.m_joystickRightVerticalValue =
                m_sourceStateCurrentState.m_joystickRightVerticalValue;

            anyChanged = true;
            m_onJoystickRightVerticalChanged.Invoke(
                m_sourceStateCurrentState.m_joystickRightVerticalValue);
        }

        if(m_sourceStateCurrentState.m_killSwitchValue != m_sourceStatePreviousState.m_killSwitchValue)
        {m_sourceStatePreviousState.m_killSwitchValue = m_sourceStateCurrentState.m_killSwitchValue;


            anyChanged = true;
            m_onKillSwitchChanged.Invoke(m_sourceStateCurrentState.m_killSwitchValue);
        }

        if (anyChanged)
        {
            m_onAnyValueChanged.Invoke(m_dualStickSource);
            m_onJoysticksChanged.Invoke(
                new Vector2(m_sourceStateCurrentState.m_joystickLeftHorizontalValue,
                m_sourceStateCurrentState.m_joystickLeftVerticalValue),
                new Vector2(m_sourceStateCurrentState.m_joystickRightHorizontalValue,
                m_sourceStateCurrentState.m_joystickRightVerticalValue));
        }
    }
}
