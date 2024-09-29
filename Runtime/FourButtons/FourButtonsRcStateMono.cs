public class FourButtonsRcStateMono : A_FourButtonsRcStateMono
{
    public FourButtonsRcState m_fourButtonsState;

    public override void GetLeftDownButtonAsDown(out bool leftDownButton)
    {
        leftDownButton = m_fourButtonsState.m_leftDownState;
    }

    public override void GetLeftUpButtonAsDown(out bool leftUpButton)
    {
        leftUpButton = m_fourButtonsState.m_leftUpState;
    }

    public override void GetRightDownButtonAsDown(out bool rightDownButton)
    {
        rightDownButton = m_fourButtonsState.m_rightDownState;
    }

    public override void GetRightUpButtonAsDown(out bool rightUpButton)
    {
        rightUpButton = m_fourButtonsState.m_rightUpState;
    }

    public override void IsKillSwitchActive(out bool killSwitch)
    {
        killSwitch = m_fourButtonsState.m_killSwitchValue;
    }

    public override bool IsKillSwitchActive()
    {
        return m_fourButtonsState.m_killSwitchValue;
    }

    public override void SetKillSwitchAsActive(bool killSwitch)
    {
        m_fourButtonsState.m_killSwitchValue = killSwitch;
    }

    public override void SetLeftDownButtonAsDown(bool leftDownButton)
    {
        m_fourButtonsState.m_leftDownState = leftDownButton;
    }

    public override void SetLeftUpButtonAsDown(bool leftUpButton)
    {
        m_fourButtonsState.m_leftUpState = leftUpButton;
    }

    public override void SetRightDownButtonAsDown(bool rightDownButton)
    {
        m_fourButtonsState.m_rightDownState = rightDownButton;
    }

    public override void SetRightUpButtonAsDown(bool rightUpButton)
    {
        m_fourButtonsState.m_rightUpState = rightUpButton;
    }
}
