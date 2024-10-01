using UnityEngine;

public class WheelRcDualAdapterMono : MonoBehaviour, I_CanBeSetWithDualSticks
{

    public A_WheelRcStateMono m_toAffect;
    public bool m_useLeftStick = true;
    public bool m_useRightStick = false;



    public void SetWith(I_DualStickRcStateGet dualStick)
    {

        

        if (m_toAffect == null)
            return;

        if (dualStick == null)
            return;

       
        dualStick.GetJoystickLeftVertical(out float percentLeftV);
        dualStick.GetJoystickLeftHorizontal(out float percentLeftH);
        dualStick.GetJoystickRightVertical(out float percentRight);
        dualStick.GetJoystickRightHorizontal(out float percentRightH);

        if (m_useLeftStick) { 
            m_toAffect.SetWheelLeftRight(percentLeftH);
            m_toAffect.SetTriggerBackForward(percentLeftV);
        }
        if (m_useRightStick) {
            m_toAffect.SetWheelLeftRight(percentRightH);
            m_toAffect.SetTriggerBackForward(percentRight);
        }



    }

    public void SetWithJoystickLeftVertical(float value)
    {

        if (m_toAffect == null)
            return;

        if (m_useLeftStick)
            m_toAffect.SetTriggerBackForward(value);
    }
    public void SetWithJoystickLeftHorizontal(float value)
    {

        if (m_toAffect == null)
            return;

        if (m_useLeftStick)
            m_toAffect.SetWheelLeftRight(value);
    }

    public void SetWithJoystickRightVertical(float value)
    {

        if (m_toAffect == null)
            return;

        if (m_useRightStick)
            m_toAffect.SetTriggerBackForward(value);
    }

    public void SetWithJoystickRightHorizontal(float value)
    {

        if (m_toAffect == null)
            return;

        if (m_useRightStick)
            m_toAffect.SetWheelLeftRight(value);
    }
}
