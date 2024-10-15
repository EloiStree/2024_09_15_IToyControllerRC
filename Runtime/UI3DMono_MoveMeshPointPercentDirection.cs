using System;
using UnityEngine;

public class UI3DMono_MoveMeshPointPercentDirection : MonoBehaviour
{

    [Range(0f,1f)]
    public float m_percentPression =0f;
    public Transform m_startPoint;
    public Transform m_toPoint;
    public Transform m_toMovePoint;


    [ContextMenu("Auto Link")]
    public void AutoLink() {

        m_startPoint = transform;
        if (m_startPoint.childCount > 0)
        {
            m_toPoint = m_startPoint.GetChild(0);
        }
       
    }

    private void Reset()
    {
        AutoLink();
    
    }
    void Update()
    {
        Refresh();
    }

    private void Refresh()
    {
        if(m_toMovePoint==null)
            return;
        if( m_startPoint==null)
            return;
        if( m_toPoint==null)
            return;

        m_toMovePoint.position= Vector3.Lerp(m_startPoint.position, m_toPoint.position, m_percentPression);
    }
}
