using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToyRcMono_UpdateTick : MonoBehaviour
{

    public UnityEvent m_onUpdateTick;

    
    void Update()
    {
        m_onUpdateTick.Invoke();
        
    }
}
