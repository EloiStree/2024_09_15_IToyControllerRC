using UnityEngine;
using UnityEngine.Events;

public class FourButtonsRcStateWithEventMono: FourButtonsRcStateMono
{
    public UnityEvent<I_FourButtonsRcStateSetGet> m_onValueChanged;
    public UnityEvent<bool> m_onLeftUpButton;
    public UnityEvent<bool> m_onRightUpButton;
    public UnityEvent<bool> m_onLeftDownButton;
    public UnityEvent<bool> m_onRightDownButton;
    public UnityEvent<bool> m_onKillSwitch;


    public void SetWith(I_FourButtonsRcStateGet source) { 
    
        source.GetLeftDownButtonAsDown(out var leftDownButton);
        source.GetLeftUpButtonAsDown(out var leftUpButton);
        source.GetRightDownButtonAsDown(out var rightDownButton);
        source.GetRightUpButtonAsDown(out var rightUpButton);
        source.IsKillSwitchActive(out var killSwitch);

        SetLeftDownButtonAsDown(leftDownButton);
        SetLeftUpButtonAsDown(leftUpButton);
        SetRightDownButtonAsDown(rightDownButton);
        SetRightUpButtonAsDown(rightUpButton);
        SetKillSwitchAsActive(killSwitch);
    
    }
    
    public override void SetKillSwitchAsActive(bool killSwitch)
    {
        base.SetKillSwitchAsActive(killSwitch);
        m_onValueChanged.Invoke(this);
        m_onKillSwitch.Invoke(killSwitch);
    }

    public override void SetLeftDownButtonAsDown(bool leftDownButton)
    {
        base.SetLeftDownButtonAsDown(leftDownButton);
        m_onValueChanged.Invoke(this);
        m_onLeftDownButton.Invoke(leftDownButton);
    }

    public override void SetLeftUpButtonAsDown(bool leftUpButton)
    {
        base.SetLeftUpButtonAsDown(leftUpButton);
        m_onValueChanged.Invoke(this);
        m_onLeftUpButton.Invoke(leftUpButton);
    }

    public override void SetRightDownButtonAsDown(bool rightDownButton)
    {
        base.SetRightDownButtonAsDown(rightDownButton);
        m_onValueChanged.Invoke(this);
        m_onRightDownButton.Invoke(rightDownButton);
    }

    public override void SetRightUpButtonAsDown(bool rightUpButton)
    {
        base.SetRightUpButtonAsDown(rightUpButton);
        m_onValueChanged.Invoke(this);
        m_onRightUpButton.Invoke(rightUpButton);
    }

    public override void IsKillSwitchActive(out bool killSwitch)
    {
        base.IsKillSwitchActive(out killSwitch);
        m_onKillSwitch.Invoke(killSwitch);
    }

    public override void GetLeftDownButtonAsDown(out bool leftDownButton)
    {
        base.GetLeftDownButtonAsDown(out leftDownButton);
        m_onLeftDownButton.Invoke(leftDownButton);
    }

    public override void GetLeftUpButtonAsDown(out bool leftUpButton)
    {
        base.GetLeftUpButtonAsDown(out leftUpButton);
        m_onLeftUpButton.Invoke(leftUpButton);
    }

    public override void GetRightDownButtonAsDown(out bool rightDownButton)
    {
        base.GetRightDownButtonAsDown(out rightDownButton);
        m_onRightDownButton.Invoke(rightDownButton);
    }

    public override void GetRightUpButtonAsDown(out bool rightUpButton)
    {
        base.GetRightUpButtonAsDown(out rightUpButton);
        m_onRightUpButton.Invoke(rightUpButton);
    }

    public override bool IsKillSwitchActive()
    {
        var result = base.IsKillSwitchActive();
        m_onKillSwitch.Invoke(result);
        return result;
    }

    [ContextMenu("Refresh Push All")]
    public void PushAllValueToEvents()
    {
        m_onValueChanged.Invoke(this);
        m_onKillSwitch.Invoke(m_fourButtonsState.m_killSwitchValue);
        m_onLeftDownButton.Invoke(m_fourButtonsState.m_leftDownState);
        m_onLeftUpButton.Invoke(m_fourButtonsState.m_leftUpState);
        m_onRightDownButton.Invoke(m_fourButtonsState.m_rightDownState);
        m_onRightUpButton.Invoke(m_fourButtonsState.m_rightUpState);
    }

    [ContextMenu("Refresh Push Interface")]
    public void PushInterfaceAsEvents()
    {
        m_onValueChanged.Invoke(this);
    }


}