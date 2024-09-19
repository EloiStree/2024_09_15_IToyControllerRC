using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI3DMono_StickDroneState : MonoBehaviour
{

    public Transform m_rotateHorizontal;
    public Vector3 m_rotateAxisHorizontal = Vector3.forward;
    public Transform m_rotateVertical;
    public Vector3 m_rotateAxisVertical = Vector3.right;

    public float m_maxRotateAngleHorizontal= 30;
    public float m_maxRotateAngleVertical = 35;

    [Range(-1,1)]
    public float m_horizontalStatePercent11 = 0.0f;


    [Range(-1, 1)]
    public float m_verticalStatePercent11 = 0.0f;


    public bool m_useUpdateToRefreshUI = true;

    [ContextMenu("Set Random State")]
    public void SetRandomState() { 
    
        SetPercentHorizontal(Random.Range(-1.0f, 1.0f));
        SetPercentVertical(Random.Range(-1.0f, 1.0f));
        RefreshUI();
    }

    

    public void SetPercentHorizontal(float percent11)
    {
        m_horizontalStatePercent11 = percent11; 
        RefreshUI();
    }
    public void SetPercentVertical(float percent11)
    {
        m_verticalStatePercent11 = percent11;
        RefreshUI();
    }

    void Update()
    {
        if(m_useUpdateToRefreshUI)
            RefreshUI();
    }

    [ContextMenu("Resfresh UI")]
    private void RefreshUI()
    {
        m_rotateHorizontal.localRotation = Quaternion.identity;
        m_rotateVertical.localRotation = Quaternion.identity;
        m_rotateHorizontal.Rotate(m_rotateAxisHorizontal, -m_maxRotateAngleHorizontal * m_horizontalStatePercent11, Space.Self);
        m_rotateVertical.Rotate(m_rotateAxisVertical, m_maxRotateAngleVertical * m_verticalStatePercent11, Space.Self);

    }
}


