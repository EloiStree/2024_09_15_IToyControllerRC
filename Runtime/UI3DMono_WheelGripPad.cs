using UnityEngine;

public class UI3DMono_WheelGripPad : MonoBehaviour
{

    public Transform m_gripForwardDirection;
    public Transform m_wheelAnchor;
    public Transform m_triggerAnchor;

    public float m_wheelAllowRotationAngle = 140;

    public float m_triggerPressAngle = 7;
    public float m_triggerPushAngle = -10;

    [Range(-1, 1)]
    public float m_wheelStatePercent11 = 0.0f;
    [Range(-1, 1)]
    public float m_triggerStatePercent11 = 0.0f;


    public bool m_useUpdateToRefreshUI = true;

    [ContextMenu("Set Random State")]
    public void SetRandomState()
    {

        SetWheelPercentState(Random.Range(-1.0f, 1.0f));
        SetTriggerPercentState(Random.Range(-1.0f, 1.0f));
        RefreshUI();
    }



    public void SetWheelPercentState(float percent11)
    {
        m_wheelStatePercent11 = percent11;
        RefreshUI();
    }
    public void SetTriggerPercentState(float percent11)
    {
        m_triggerStatePercent11 = percent11;
        RefreshUI();
    }

    void Update()
    {
        if (m_useUpdateToRefreshUI)
            RefreshUI();
    }

    [ContextMenu("Resfresh UI")]
    private void RefreshUI()
    {
        m_wheelAnchor.rotation = m_gripForwardDirection.rotation;
        m_triggerAnchor.rotation = m_gripForwardDirection.rotation;
        m_wheelAnchor.Rotate(Vector3.forward, -m_wheelAllowRotationAngle * m_wheelStatePercent11, Space.Self);
        m_triggerAnchor.Rotate(Vector3.forward, -m_triggerPressAngle + (m_triggerPushAngle - m_triggerPressAngle) * m_triggerStatePercent11, Space.Self);
       
    }

    
    public void SetWith(I_WheelRcStateGet source) { 
    
        source.GetWheelLeftRight(out float wheelLeftRight);
        source.GetTriggerBackForward(out float triggerBackForward);
        SetWheelPercentState(wheelLeftRight);
        SetTriggerPercentState(triggerBackForward);
    }

    public void SetJoystickWithVector2(Vector2 value)
    {
        SetWheelPercentState(value.x);
        SetTriggerPercentState(value.y);
    }
    public void SetJoystickWithVector2Left(Vector2 left, Vector2 right)
    {
        SetWheelPercentState(left.x);
        SetTriggerPercentState(left.y);
    }
    public void SetJoystickWithVector2Right(Vector2 left, Vector2 right)
    {
        SetWheelPercentState(right.x);
        SetTriggerPercentState(right.y);
    }
}
