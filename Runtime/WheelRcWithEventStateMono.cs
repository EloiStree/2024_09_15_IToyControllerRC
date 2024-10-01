using UnityEngine;
using UnityEngine.Events;

public class WheelRcWithEventStateMono : WheelRcStateMono {

    public UnityEvent<I_WheelRcStateSetGet> m_onValueChanged;
    public UnityEvent<bool> m_onKillSwitchActive;
    public UnityEvent<float> m_onTriggerBackForward;
    public UnityEvent<float> m_onWheelLeftRight;

    public void SetWith(I_WheelRcStateGet source)
    {
        source.GetWheelLeftRight(out float wheelLeftRight);
        source.GetTriggerBackForward(out float triggerBackForward);
        source.IsKillSwitchActive(out bool killSwitch);
        SetWheelLeftRight(wheelLeftRight);
        SetTriggerBackForward(triggerBackForward);
        SetKillSwitchAsActive(killSwitch);
    }

    public override void SetWheelLeftRight(float percent11)
    {
        base.SetWheelLeftRight(percent11);
        m_onWheelLeftRight.Invoke(percent11);
        m_onValueChanged.Invoke(this);
    }

    public override void SetTriggerBackForward(float percent11)
    {
        base.SetTriggerBackForward(percent11);
        m_onTriggerBackForward.Invoke(percent11);
        m_onValueChanged.Invoke(this);
    }

    public override void SetKillSwitchAsActive(bool killSwitch)
    {
        base.SetKillSwitchAsActive(killSwitch);
        m_onKillSwitchActive.Invoke(killSwitch);
        m_onValueChanged.Invoke(this);
    }

    public override void GetWheelLeftRight(out float percent11)
    {
        base.GetWheelLeftRight(out percent11);
    }

    public override void GetTriggerBackForward(out float percent11)
    {
        base.GetTriggerBackForward(out percent11);
    }

    public override void IsKillSwitchActive(out bool killSwitch)
    {
        base.IsKillSwitchActive(out killSwitch);
    }

    public override bool IsKillSwitchActive()
    {
        return base.IsKillSwitchActive();
    }

    [ContextMenu("Refresh Push All")]
    public void PushAllValueToEvents()
    {
        m_onValueChanged.Invoke(this);
        m_onKillSwitchActive.Invoke(m_wheelRcState.m_killSwitchValue);
        m_onTriggerBackForward.Invoke(m_wheelRcState.m_triggerBackForwardValue);
        m_onWheelLeftRight.Invoke(m_wheelRcState.m_wheelLeftRightValue);
    }

    [ContextMenu("Refresh Push Interface")]
    public void PushInterfaceAsEvents()
    {
        m_onValueChanged.Invoke(this);
    }
}