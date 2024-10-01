using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualStickArraySelectorMono : DualStickRcStateWithEventMono
{
    [Header("Must have components of I_CanBeSetWithDualSticks")]
    public GameObject [] m_dualSticksGroup;
    public List<I_CanBeSetWithDualSticks> m_compatiableList= new List<I_CanBeSetWithDualSticks>();
    public int m_compatiableCount=0;

    public int m_index = 0;

    private void Awake()
    {
        RefreshList();
    }

    private void RefreshList()
    {
        m_compatiableList.Clear();
        foreach(var item in m_dualSticksGroup)
            {
            if (item == null)
                continue;
            var list = item.GetComponents<I_CanBeSetWithDualSticks>();

            if (list == null)
                continue;

            if(list.Length==0)
                list= item.GetComponentsInChildren<I_CanBeSetWithDualSticks>();

            if(list.Length == 0)
                continue;

            foreach (var item2 in list)
            {
                if (item2 == null)
                    continue;
                m_compatiableList.Add(item2);

            }
        }
        m_compatiableCount = m_compatiableList.Count;
    }

    [ContextMenu("Next")]
    public void Next()
    {
        m_index++;
        if (m_index >= m_compatiableList.Count)
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
            m_index = m_compatiableList.Count - 1;
        }
    }

       
    public new void SetJoystickLeftHorizontal(float percent11)
    {
        if (!IsExistingAndInRange())return;
        base.SetJoystickLeftHorizontal(percent11);
        m_compatiableList[m_index].SetWith(this);
    }
    public new void SetJoystickLeftVertical(float percent11)
    {
        if (!IsExistingAndInRange())return;
        base.SetJoystickLeftVertical(percent11);
        m_compatiableList[m_index].SetWith(this);
    }
    public new void SetJoystickRightHorizontal(float percent11)
    {
        if (!IsExistingAndInRange()) return;
        base.SetJoystickRightHorizontal(percent11);
        m_compatiableList[m_index].SetWith(this);
    }
    public new void SetJoystickRightVertical(float percent11)
    {
        if (!IsExistingAndInRange())return;
        base.SetJoystickRightVertical(percent11);
        m_compatiableList[m_index].SetWith(this);
    }

    public new void SetKillSwitchAsActive(bool killSwitch)
    {
        if (!IsExistingAndInRange())return;
        base.SetKillSwitchAsActive(killSwitch);
        m_compatiableList[m_index].SetWith(this);

    }

    public new void GetJoystickLeftHorizontal(out float percent11)
    {
        percent11 = 0;
        if (!IsExistingAndInRange())return;
        base.GetJoystickLeftHorizontal(out percent11);
    }
    public new void GetJoystickLeftVertical(out float percent11)
    {
        percent11 = 0;
        if (!IsExistingAndInRange())return;
        base.GetJoystickLeftVertical(out percent11);
    }
    public new void GetJoystickRightHorizontal(out float percent11)
    {
        percent11 = 0;
        if (!IsExistingAndInRange())return;
        GetJoystickRightHorizontal(out percent11);
    }
    public new void GetJoystickRightVertical(out float percent11)
    {
        percent11 = 0;
        if (!IsExistingAndInRange())return;
        GetJoystickRightVertical(out percent11);
    }

    public new void IsKillSwitchActive(out bool killSwitch)
    {
        killSwitch = false;
        if (!IsExistingAndInRange())return;
        IsKillSwitchActive(out killSwitch);
    }



    private bool IsExistingAndInRange()
    {
        return m_compatiableList.Count>= 0
            && m_index>-1 
            && m_index< m_compatiableList.Count 
            && m_compatiableList[m_index] != null ;

    }



}
