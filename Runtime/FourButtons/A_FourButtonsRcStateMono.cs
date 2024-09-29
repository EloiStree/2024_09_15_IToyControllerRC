
using UnityEngine;

public abstract class A_FourButtonsRcStateMono : MonoBehaviour, I_FourButtonsRcStateSetGet
{
    public abstract void GetLeftDownButtonAsDown(out bool leftDownButton);
    public abstract void GetLeftUpButtonAsDown(out bool leftUpButton);
    public abstract void GetRightDownButtonAsDown(out bool rightDownButton);
    public abstract void GetRightUpButtonAsDown(out bool rightUpButton);
    public abstract void IsKillSwitchActive(out bool killSwitch);
    public abstract bool IsKillSwitchActive();
    public abstract void SetLeftDownButtonAsDown(bool leftDownButton);
    public abstract void SetLeftUpButtonAsDown(bool leftUpButton);
    public abstract void SetRightDownButtonAsDown(bool rightDownButton);
    public abstract void SetRightUpButtonAsDown(bool rightUpButton);
    public abstract void SetKillSwitchAsActive(bool killSwitch);
}