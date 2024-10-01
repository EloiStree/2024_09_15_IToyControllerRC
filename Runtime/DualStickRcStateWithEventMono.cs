using UnityEngine;
using UnityEngine.Events;

public class DualStickRcStateWithEventMono : DualStickRcStateMono, I_CanBeSetWithDualSticks { 

    public UnityEvent<I_DualStickRcStateSetGet> m_onValueChanged;
    public UnityEvent<float> m_onJoystickLeftHorizontal;
    public UnityEvent<float> m_onJoystickLeftVertical;
    public UnityEvent<float> m_onJoystickRightHorizontal;
    public UnityEvent<float> m_onJoystickRightVertical;
    public UnityEvent<bool> m_onKillSwitch;


    public new void SetWith(I_DualStickRcStateGet source)
    {
        source.GetJoystickLeftHorizontal(out float joystickLeftHorizontal);
        source.GetJoystickLeftVertical(out float joystickLeftVertical);
        source.GetJoystickRightHorizontal(out float joystickRightHorizontal);
        source.GetJoystickRightVertical(out float joystickRightVertical);
        source.IsKillSwitchActive(out bool killSwitch);
        SetJoystickLeftHorizontal(joystickLeftHorizontal);
        SetJoystickLeftVertical(joystickLeftVertical);
        SetJoystickRightHorizontal(joystickRightHorizontal);
        SetJoystickRightVertical(joystickRightVertical);
        SetKillSwitchAsActive(killSwitch);

    }

    public new void SetJoystickLeftHorizontal(float percent11)
    {
        base.SetJoystickLeftHorizontal(percent11);
        m_onValueChanged.Invoke(this);
        m_onJoystickLeftHorizontal.Invoke(percent11);
    }

    public new void SetJoystickLeftVertical(float percent11)
    {
        base.SetJoystickLeftVertical(percent11);
        m_onValueChanged.Invoke(this);
        m_onJoystickLeftVertical.Invoke(percent11);
    }

    public new void SetJoystickRightHorizontal(float percent11)
    {
        base.SetJoystickRightHorizontal(percent11);
        m_onValueChanged.Invoke(this);
        m_onJoystickRightHorizontal.Invoke(percent11);
    }

    public new void SetJoystickRightVertical(float percent11)
    {
        base.SetJoystickRightVertical(percent11);
        m_onValueChanged.Invoke(this);
        m_onJoystickRightVertical.Invoke(percent11);
    }

    public new void SetKillSwitchAsActive(bool killSwitch)
    {
        base.SetKillSwitchAsActive(killSwitch);
        m_onValueChanged.Invoke(this);
        m_onKillSwitch.Invoke(killSwitch);
    }

    public new void IsKillSwitchActive(out bool killSwitch)
    {
        base.IsKillSwitchActive(out killSwitch);
    }

    public new void GetJoystickLeftHorizontal(out float percent11)
    {
        base.GetJoystickLeftHorizontal(out percent11);
    }

    public new void GetJoystickLeftVertical(out float percent11)
    {
        base.GetJoystickLeftVertical(out percent11);
    }

    public new void GetJoystickRightHorizontal(out float percent11)
    {
        base.GetJoystickRightHorizontal(out percent11);
    }


    public new void GetJoystickRightVertical(out float percent11)
    {
        base.GetJoystickRightVertical(out percent11);
    }

    public new bool IsKillSwitchActive()
    {
        return base.IsKillSwitchActive();
    }


    [ContextMenu("Refresh Push All")]
    public void PushAllValueToEvents()
    {
        m_onValueChanged.Invoke(this);
        m_onJoystickLeftHorizontal.Invoke(m_dualStickRcState.m_joystickLeftHorizontalValue);
        m_onJoystickLeftVertical.Invoke(m_dualStickRcState.m_joystickLeftVerticalValue);
        m_onJoystickRightHorizontal.Invoke(m_dualStickRcState.m_joystickRightHorizontalValue);
        m_onJoystickRightVertical.Invoke(m_dualStickRcState.m_joystickRightVerticalValue);
        m_onKillSwitch.Invoke(m_dualStickRcState.m_killSwitchValue);


    }

    [ContextMenu("Refresh Push Interface")]
    public void PushInterfaceAsEvents()
    {
        m_onValueChanged.Invoke(this);
    }
}