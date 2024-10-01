using UnityEngine;

public class UI3DMono_FourButtonJoystickState : MonoBehaviour
{

    public UI3DMono_DoubleButtonJoystickState m_leftJoystick;
    public UI3DMono_DoubleButtonJoystickState m_rightJoystick;

    public float m_percentAxisToButtonisOn = 0.8f;

    public void SetLeftRightAxis(float left, float right)
    {
        m_leftJoystick.SetPercentVertical(left);
        m_rightJoystick.SetPercentVertical(right);
    }
    public void SetLeftAxis(float left)
    {
        m_leftJoystick.SetPercentVertical(left);
        if(left<-m_percentAxisToButtonisOn)
            m_leftJoystick.SetDoubleButtons(false, true);
        else if(left> m_percentAxisToButtonisOn)
            m_leftJoystick.SetDoubleButtons(true, false);
        else
            m_leftJoystick.SetDoubleButtons(false, false);
    }
    public void SetRightAxis(float right)
    {
        m_rightJoystick.SetPercentVertical(right);
        if (right < -m_percentAxisToButtonisOn)
            m_rightJoystick.SetDoubleButtons(false, true);
        else if (right > m_percentAxisToButtonisOn)
            m_rightJoystick.SetDoubleButtons(true, false);
        else
            m_rightJoystick.SetDoubleButtons(false, false);
    }

    public void SetFourButtons(bool leftUp, bool leftDown, bool rightUp, bool rightDown)
    {
        m_leftJoystick.SetPercentVertical(leftUp ? 1 : leftDown ? -1 : 0);
        m_rightJoystick.SetPercentVertical(rightUp ? 1 : rightDown ? -1 : 0);
        m_leftJoystick.SetDoubleButtons(leftUp, leftDown);
        m_rightJoystick.SetDoubleButtons(rightUp, rightDown);
    }


    public void SetLeftUpButton(bool isOn)
    {
        m_leftJoystick.SetDoubleButtons(isOn, !isOn);
        m_leftJoystick.SetPercentVertical(isOn ? 1 : 0);
        
    }
    public void SetLeftDownButton(bool isOn)
    {
        m_leftJoystick.SetDoubleButtons(!isOn, isOn);
        m_leftJoystick.SetPercentVertical(isOn ? -1 : 0);
    }
    public void SetRightUpButton(bool isOn)
    {
        m_rightJoystick.SetDoubleButtons(isOn, !isOn);
        m_rightJoystick.SetPercentVertical(isOn ? 1 : 0);
    }
    public void SetRightDownButton(bool isOn)
    {
        m_rightJoystick.SetDoubleButtons(!isOn, isOn);
        m_rightJoystick.SetPercentVertical(isOn ? -1 : 0);
    }


    public void SetWith(I_FourButtonsRcStateGet source)
    {
        source.GetLeftUpButtonAsDown(out bool leftUp);
        source.GetLeftDownButtonAsDown(out bool leftDown);
        source.GetRightUpButtonAsDown(out bool rightUp);
        source.GetRightDownButtonAsDown(out bool rightDown);

        SetFourButtons(leftUp, leftDown, rightUp, rightDown);
    }
}


