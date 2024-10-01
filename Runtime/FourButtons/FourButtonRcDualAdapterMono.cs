using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourButtonRcDualAdapterMono : MonoBehaviour, I_CanBeSetWithDualSticks
{

    public A_FourButtonsRcStateMono m_toAffect;
    public float m_absoluteValueToBeOnOnAxis = 0.2f;



    public void SetWith(I_DualStickRcStateGet dualStick) { 
    
        if(m_absoluteValueToBeOnOnAxis<0f)
            m_absoluteValueToBeOnOnAxis = -m_absoluteValueToBeOnOnAxis;

        if(m_toAffect == null)
            return;
        
        if(dualStick == null)
            return;
        
        dualStick.GetJoystickLeftVertical(out float percentLeft);
        dualStick.GetJoystickRightVertical(out float percentRight);

        m_toAffect.SetLeftUpButtonAsDown(percentLeft>m_absoluteValueToBeOnOnAxis);
        m_toAffect.SetLeftDownButtonAsDown(percentLeft<-m_absoluteValueToBeOnOnAxis);
        m_toAffect.SetRightUpButtonAsDown(percentRight>m_absoluteValueToBeOnOnAxis);
        m_toAffect.SetRightDownButtonAsDown(percentRight<-m_absoluteValueToBeOnOnAxis);
    }

    public void SetWithJoystickLeftVertical(float value) { 
    
        if(m_absoluteValueToBeOnOnAxis<0f)
            m_absoluteValueToBeOnOnAxis = -m_absoluteValueToBeOnOnAxis;

        if(m_toAffect == null)
            return;
        
        m_toAffect.SetLeftUpButtonAsDown(value>m_absoluteValueToBeOnOnAxis);
        m_toAffect.SetLeftDownButtonAsDown(value<-m_absoluteValueToBeOnOnAxis);
    }

    public void SetWithJoystickRightVertical(float value) { 
    
        if(m_absoluteValueToBeOnOnAxis<0f)
            m_absoluteValueToBeOnOnAxis = -m_absoluteValueToBeOnOnAxis;

        if(m_toAffect == null)
            return;
        
        m_toAffect.SetRightUpButtonAsDown(value>m_absoluteValueToBeOnOnAxis);
        m_toAffect.SetRightDownButtonAsDown(value<-m_absoluteValueToBeOnOnAxis);
    }
}
