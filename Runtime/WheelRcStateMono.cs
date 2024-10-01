using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRcStateMono : A_WheelRcStateMono
{
    public WheelRcState m_wheelRcState;
    public override void SetWheelLeftRight(float percent11)
    {
        m_wheelRcState.m_wheelLeftRightValue = percent11;
    }
    public override void SetTriggerBackForward(float percent11)
    {
        m_wheelRcState.m_triggerBackForwardValue = percent11;
    }

    public override void SetKillSwitchAsActive(bool killSwitch)
    {
        m_wheelRcState.m_killSwitchValue = killSwitch;
    }

    public override void GetWheelLeftRight(out float percent11)
    {
        percent11 = m_wheelRcState.m_wheelLeftRightValue;
    }

    public override void GetTriggerBackForward(out float percent11)
    {
        percent11 = m_wheelRcState.m_triggerBackForwardValue;
    }

    public override void IsKillSwitchActive(out bool killSwitch)
    {
        killSwitch = m_wheelRcState.m_killSwitchValue;
    }

    public override bool IsKillSwitchActive()
    {
        return m_wheelRcState.m_killSwitchValue;
    }
}

[System.Serializable]
public struct WheelRcState
{
    [Range(-1, 1)]
    public float m_wheelLeftRightValue;
    [Range(-1, 1)]
    public float m_triggerBackForwardValue;
    public bool m_killSwitchValue;
}


public interface I_WheelRcStateSet
{
    void SetWheelLeftRight(float percent11);
    void SetTriggerBackForward(float percent11);
    void SetKillSwitchAsActive(bool killSwitch);
}

public interface I_WheelRcStateGet
{
    void GetWheelLeftRight(out float percent11);
    void GetTriggerBackForward(out float percent11);
    void IsKillSwitchActive(out bool killSwitch);
    bool IsKillSwitchActive();
}

public interface I_WheelRcStateSetGet : I_WheelRcStateSet, I_WheelRcStateGet
{
}

public abstract class A_WheelRcStateMono :MonoBehaviour, I_WheelRcStateSetGet
{
    public abstract void SetWheelLeftRight(float percent11);
    public abstract void SetTriggerBackForward(float percent11);
    public abstract void SetKillSwitchAsActive(bool killSwitch);
    public abstract void GetWheelLeftRight(out float percent11);
    public abstract void GetTriggerBackForward(out float percent11);
    public abstract void IsKillSwitchActive(out bool killSwitch);
    public abstract bool IsKillSwitchActive();
}
