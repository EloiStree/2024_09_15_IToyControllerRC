using UnityEngine;

public class UI3DMono_BlueSubmarinePad : MonoBehaviour
{

    [Range(-1f,1f)]
    public float m_leftToRightRotatePercent = 0.0f;
    [Range(-1f, 1f)]
    public float m_backToForwradMovePercent = 0.0f;
    [Range(-1f, 1f)]
    public float m_downToUpMovePercent = 0.0f;

    public float m_pressPercent = 0.8f;

    public UI3DMono_MoveMeshPointPercentDirection m_up;
    public UI3DMono_MoveMeshPointPercentDirection m_down;
    public UI3DMono_MoveMeshPointPercentDirection m_left;
    public UI3DMono_MoveMeshPointPercentDirection m_right;
    public UI3DMono_MoveMeshPointPercentDirection m_forward;
    public UI3DMono_MoveMeshPointPercentDirection m_back;


    public void SetRotationLeftRigh(float percent)
    {
        m_leftToRightRotatePercent = percent;
        RefreshWithAxis();
    }
    public void SetMoveBackForward(float percent)
    {
        m_backToForwradMovePercent = percent;
        RefreshWithAxis();
    }
    public void SetMoveDownUp(float percent)
    {
        m_downToUpMovePercent = percent;
        RefreshWithAxis();
    }
    public void SetWithDualJoystick(Vector2 left, Vector2 right)
    {

        m_downToUpMovePercent = left.y;
        m_leftToRightRotatePercent = left.x;
        m_backToForwradMovePercent = right.y;
        RefreshWithAxis();

    }

    private void Update()
    {
        RefreshWithAxis();
    }


    public bool m_useOnOff= false;

    [ContextMenu("Refresh UI from Axis")]
    public void RefreshWithAxis()
    {
        if (m_useOnOff)
        {
            if (m_left) m_left.m_percentPression = m_leftToRightRotatePercent < -m_pressPercent ? 1f : 0f;
            if (m_right) m_right.m_percentPression = m_leftToRightRotatePercent > m_pressPercent ? 1f : 0f;
            if (m_back) m_back.m_percentPression = m_backToForwradMovePercent < -m_pressPercent ? 1f : 0f;
            if (m_forward) m_forward.m_percentPression = m_backToForwradMovePercent > m_pressPercent ? 1f : 0f;
            if (m_down) m_down.m_percentPression = m_downToUpMovePercent < -m_pressPercent ? 1f : 0f;
            if (m_up) m_up.m_percentPression = m_downToUpMovePercent > m_pressPercent ? 1f : 0f;
        }
        else { 
        
            if (m_left) m_left.m_percentPression =Mathf.Clamp01( -m_leftToRightRotatePercent);
            if (m_right) m_right.m_percentPression = Mathf.Clamp01(m_leftToRightRotatePercent);
            if (m_back) m_back.m_percentPression = Mathf.Clamp01(-m_backToForwradMovePercent);
            if (m_forward) m_forward.m_percentPression = Mathf.Clamp01(m_backToForwradMovePercent);
            if (m_down) m_down.m_percentPression = Mathf.Clamp01(-m_downToUpMovePercent);
            if (m_up) m_up.m_percentPression = Mathf.Clamp01(m_downToUpMovePercent);
        }
    }

    [ContextMenu("Reset to Zero")]
    public void ResetToZero() { 
    
        m_leftToRightRotatePercent = 0.0f;
        m_backToForwradMovePercent = 0.0f;
        m_downToUpMovePercent = 0.0f;
        RefreshWithAxis();
    }

    [ContextMenu("Up")]
    public void SetToUp() { m_downToUpMovePercent = 1.0f; RefreshWithAxis(); }
    [ContextMenu("Down")]
    public void SetToDown() { m_downToUpMovePercent = -1.0f; RefreshWithAxis(); }
    [ContextMenu("Left")]
    public void SetToLeft() { m_leftToRightRotatePercent = -1.0f; RefreshWithAxis(); }
    [ContextMenu("Right")]
    public void SetToRight() { m_leftToRightRotatePercent = 1.0f; RefreshWithAxis(); }
    [ContextMenu("Forward")]
    public void SetToForward() { m_backToForwradMovePercent = 1.0f; RefreshWithAxis(); }
    [ContextMenu("Backward")]
    public void SetToBack() { m_backToForwradMovePercent = -1.0f; RefreshWithAxis(); }



}
