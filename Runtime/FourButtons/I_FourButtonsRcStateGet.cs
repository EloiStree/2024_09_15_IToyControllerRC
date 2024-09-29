public interface I_FourButtonsRcStateGet
{
    
    public void GetLeftUpButtonAsDown(out bool leftUpButton);
    public void GetLeftDownButtonAsDown(out bool leftDownButton);
    public void GetRightUpButtonAsDown(out bool rightUpButton);
    public void GetRightDownButtonAsDown(out bool rightDownButton);
    void IsKillSwitchActive(out bool killSwitch);
    bool IsKillSwitchActive();

}
