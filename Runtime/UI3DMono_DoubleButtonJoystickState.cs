using UnityEngine;

public class UI3DMono_DoubleButtonJoystickState : MonoBehaviour
{

    public Transform m_rotateVertical;
    public Vector3 m_rotateAxisVertical = Vector3.right;

    public float m_maxRotateAngleVertical = 35;


    [Range(-1, 1)]
    public float m_verticalStatePercent11 = 0.0f;


    public bool m_useUpdateToRefreshUI = true;

    [ContextMenu("Set Random State")]
    public void SetRandomState() { 
    
        SetPercentVertical(Random.Range(-1.0f, 1.0f));
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
}


