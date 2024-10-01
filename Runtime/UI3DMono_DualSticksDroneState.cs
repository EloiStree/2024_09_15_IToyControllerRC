using UnityEngine;

public class UI3DMono_DualSticksDroneState : MonoBehaviour
{
    public UI3DMono_StickDroneState m_left;
    public UI3DMono_StickDroneState m_right;


    public void SetWith(I_DualStickRcStateGet source)
    {
        source.GetJoystickLeftHorizontal(out float joystickLeftHorizontal);
        source.GetJoystickLeftVertical(out float joystickLeftVertical);
        source.GetJoystickRightHorizontal(out float joystickRightHorizontal);
        source.GetJoystickRightVertical(out float joystickRightVertical);
        source.IsKillSwitchActive(out bool killSwitch);
        SetLeftHorizontal(joystickLeftHorizontal);
        SetLeftVertical(joystickLeftVertical);
        SetRightHorizontal(joystickRightHorizontal);
        SetRightVertical(joystickRightVertical);

    }

    public void SetFromDualStickVector2(Vector2 left, Vector2 rigth)
    {
        m_left.SetFromDualStickVector2Left(left, rigth);
        m_right.SetFromDualStickVector2Right(left, rigth);
    }

    public void SetLeftFromStickVector2(Vector2 left)
    {
        m_left.SetPercentHorizontal(left.x);
        m_left.SetPercentVertical(left.y);
    }
    public void SetRightFromStickVector2(Vector2 right)
    {
        m_right.SetPercentHorizontal(right.x);
        m_right.SetPercentVertical(right.y);
    }

    [ContextMenu("Set Random State")]
    public void SetRandomState()
    {
        m_left.SetRandomState();
        m_right.SetRandomState();
    }

    public void SetLeftHorizontal(float percent11)
    {
        m_left.SetPercentHorizontal(percent11);
    }
    public void SetLeftVertical(float percent11)
    {
        m_left.SetPercentVertical(percent11);
    }
    public void SetRightHorizontal(float percent11)
    {
        m_right.SetPercentHorizontal(percent11);
    }
    public void SetRightVertical(float percent11)
    {
        m_right.SetPercentVertical(percent11);
    }


}

