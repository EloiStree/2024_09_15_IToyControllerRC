using UnityEngine;

public class UI3DMono_DoubleButtonJoystickState : MonoBehaviour
{

    public Transform m_rotateVertical;
    public Vector3 m_rotateAxisVertical = Vector3.right;

    public float m_maxRotateAngleVertical = 35;

    [Range(-1, 1)]
    public float m_verticalStatePercent11 = 0.0f;

    public bool m_useUpdateToRefreshUI = true;

    public float m_buttonHeightOn = 0.2f;
    public float m_buttonHeightOff = 0.5f;

    public Transform m_buttonUp;
    public Transform m_buttonDown;

    public bool m_buttonUpIsOn = false;
    public bool m_buttonDownIsOn = false;

    public Vector3 m_buttonLocalDirection = Vector3.up;


    [ContextMenu("Set Random State")]
    public void SetRandomState() { 
    
        SetPercentVertical(Random.Range(-1.0f, 1.0f));
        RefreshUI();
    }

    public void SetJosytickFloatFromButtons() { 
    
        SetPercentVertical(m_buttonUpIsOn ? 1 : m_buttonDownIsOn ? -1 : 0);

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
        m_rotateVertical.localRotation = Quaternion.identity;
        m_rotateVertical.Rotate(m_rotateAxisVertical, m_maxRotateAngleVertical * m_verticalStatePercent11, Space.Self);

    }


    public void SetFromDualStickVector2Left(Vector2 left, Vector2 rigth) { 
             SetPercentVertical(left.y);
    }
    public void SetFromDualStickVector2Right(Vector2 left, Vector2 rigth)
    {
         SetPercentVertical(rigth.y);
    }

    public void SetDoubleButtons(bool leftUp, bool leftDown)
    {
        m_buttonUpIsOn = leftUp;
        m_buttonDownIsOn = leftDown;
        m_buttonUp.localPosition = m_buttonLocalDirection * (leftUp ? m_buttonHeightOn : m_buttonHeightOff);
        m_buttonDown.localPosition = m_buttonLocalDirection * (leftDown ? m_buttonHeightOn : m_buttonHeightOff);
    }
}


