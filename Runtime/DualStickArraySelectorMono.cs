using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualStickArraySelectorMono : DualStickRcStateWithEventMono
{

    public A_DualStickRcStateMono[] m_dualSticksGroup;
    public int m_index = 0;

    [ContextMenu("Next")]
    public void Next()
    {
        m_index++;
        if (m_index >= m_dualSticksGroup.Length)
        {
            m_index = 0;
        }
    }
    [ContextMenu("Previous")]
    public void Previous()
    {
        m_index--;
        if (m_index < 0)
        {
            m_index = m_dualSticksGroup.Length - 1;
        }
    }


       
    public override void SetJoystickLeftHorizontal(float percent11)
    {
        if (!IsExistingAndInRange())return;
        m_dualSticksGroup[m_index].SetJoystickLeftHorizontal(percent11);
        base.SetJoystickLeftHorizontal(percent11);
    }
    public override void SetJoystickLeftVertical(float percent11)
    {
        if (!IsExistingAndInRange())return;
        m_dualSticksGroup[m_index].SetJoystickLeftVertical(percent11);
        base.SetJoystickLeftVertical(percent11);
    }
    public override void SetJoystickRightHorizontal(float percent11)
    {
        if (!IsExistingAndInRange())return;
        m_dualSticksGroup[m_index].SetJoystickRightHorizontal(percent11);
        base.SetJoystickRightHorizontal(percent11);
    }
    public override void SetJoystickRightVertical(float percent11)
    {
        if (!IsExistingAndInRange())return;
        m_dualSticksGroup[m_index].SetJoystickRightVertical(percent11);
        base.SetJoystickRightVertical(percent11);
    }

    public override void SetKillSwitchAsActive(bool killSwitch)
    {
        if (!IsExistingAndInRange())return;
        m_dualSticksGroup[m_index].SetKillSwitchAsActive(killSwitch);
        base.SetKillSwitchAsActive(killSwitch);
    }

    public override void GetJoystickLeftHorizontal(out float percent11)
    {
        percent11 = 0;
        if (!IsExistingAndInRange())return;
        m_dualSticksGroup[m_index].GetJoystickLeftHorizontal(out percent11);
    }
    public override void GetJoystickLeftVertical(out float percent11)
    {
        percent11 = 0;
        if (!IsExistingAndInRange())return;
        m_dualSticksGroup[m_index].GetJoystickLeftVertical(out percent11);
    }
    public override void GetJoystickRightHorizontal(out float percent11)
    {
        percent11 = 0;
        if (!IsExistingAndInRange())return;
        m_dualSticksGroup[m_index].GetJoystickRightHorizontal(out percent11);
    }
    public override void GetJoystickRightVertical(out float percent11)
    {
        percent11 = 0;
        if (!IsExistingAndInRange())return;
        m_dualSticksGroup[m_index].GetJoystickRightVertical(out percent11);
    }

    public override void IsKillSwitchActive(out bool killSwitch)
    {
        killSwitch = false;
        if (!IsExistingAndInRange())return;
        m_dualSticksGroup[m_index].IsKillSwitchActive(out killSwitch);
    }



    private bool IsExistingAndInRange()
    {
        return m_dualSticksGroup.Length>= 0 && m_index>-1 && m_index< m_dualSticksGroup.Length && m_dualSticksGroup[m_index] != null ;

    }



}
